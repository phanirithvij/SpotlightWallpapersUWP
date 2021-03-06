﻿using SpotLightUWP.Core.Helpers;
using SpotLightUWP.Core.Models;
using SpotLightUWP.Services.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace SpotLightUWP.Services
{
    public class IOManager : IIOManager
    {
        private string _downloadPath;
        private string _templatePath;
        public string _downloadedfolder;
        private string _templateFolder;
        private string _settingsPath;
        private bool isinitialized;
        public string DailyWallpaperFolderPath { get; set; }

        public IOManager()
        {
            isinitialized = false;
        }

        public void Initialize(IOManagerParams @params = IOManagerParams.SpotLight)
        {
            if (!isinitialized)
            {
                var appdata = ApplicationData.Current.LocalFolder;

                if (@params == IOManagerParams.SpotLight)
                {
                    _downloadedfolder = "DownloadedFolder";
                    _templateFolder = "Templates";
                }
                else if (@params == IOManagerParams.Bing)
                {
                    _downloadedfolder = "BingDownloaded";
                    _templateFolder = "BingTemplates";
                }
                else
                {
                    _downloadedfolder = "LocalDownloaded";
                    _templateFolder = "LocalTemplates";
                }
                SettingsPath = Path.Combine(appdata.Path, "Configs.json");

                DownloadPath = Path.Combine(appdata.Path, _downloadedfolder);
                TemplatePath = Path.Combine(appdata.Path, _templateFolder);
                DailyWallpaperFolderPath = Path.Combine(appdata.Path, "DailyWallpaperFolderPath");

                if (!Directory.Exists(DownloadPath))
                {
                    Directory.CreateDirectory(DownloadPath);
                }
                if (!Directory.Exists(TemplatePath))
                {
                    Directory.CreateDirectory(TemplatePath);
                }
                if (!Directory.Exists(DailyWallpaperFolderPath))
                {
                    Directory.CreateDirectory(DailyWallpaperFolderPath);
                }

                if (!File.Exists(SettingsPath))
                {
                    var file = File.Create(SettingsPath);
                    file.Dispose();
                }
                isinitialized = true;
            }
        }

        public async Task DownloadImages(List<ImageDTO> imageDTOs, int page, bool AsTemplate = true)
        {
            string downloadFolder;
            if (AsTemplate)
            {
                downloadFolder = Path.Combine(TemplatePath, page.ToString());
                foreach (var imagedto in imageDTOs)
                {
                    await DownloadImage(imagedto.TemplateUri, imagedto.Id, imagedto.Name, downloadFolder);
                }
            }
            else
            {
                downloadFolder = Path.Combine(DownloadPath, page.ToString());
                foreach (var imagedto in imageDTOs)
                {
                    await DownloadImage(imagedto.URI, imagedto.Id ?? null, imagedto.Name, downloadFolder);
                }
            }
        }

        public async Task DownloadImage(string Url, string id = null, string name = null, string Path = null)
        {
            string _path = Path ?? DownloadPath;
            var newName = name.Replace(" ", string.Empty).Replace("'", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
            using (WebClient client = new WebClient())
            {
                var path = ImageNameManager.ResultPathGenerator(Url, _path, id, newName);
                if (!File.Exists(path))
                {
                    if (!Directory.Exists(new FileInfo(path).Directory.FullName))
                    {
                        Directory.CreateDirectory(new FileInfo(path).Directory.FullName);
                    }
                    try
                    {
                        await client.DownloadFileTaskAsync(new Uri(Url), path);
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception("couldnt download Image",ex);
                    }
                }
            }
        }

        public string GetSavedDTOS()
        {
            return File.ReadAllText(SettingsPath);
        }

        public void SaveConfigsToFile(string content)
        {
            File.WriteAllText(SettingsPath, content);
        }

        public string GetSavedConfigs()
        {
            string text = File.ReadAllText(SettingsPath);

            return text;
        }

        public async Task SaveImageAs(string imageUri)
        {
            StorageFile currentImage = await StorageFile.GetFileFromPathAsync(imageUri);
            byte[] buffer;
            Stream stream = await currentImage.OpenStreamForReadAsync();
            buffer = new byte[stream.Length];
            await stream.ReadAsync(buffer, 0, (int)stream.Length);
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("JPEG-Image", new List<string>() { ".jpg" });
            savePicker.FileTypeChoices.Add("PNG-Image", new List<string>() { ".png" });
            savePicker.SuggestedSaveFile = currentImage;
            savePicker.SuggestedFileName = currentImage.Name;
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                CachedFileManager.DeferUpdates(file);
                await FileIO.WriteBytesAsync(file, buffer);
                await CachedFileManager.CompleteUpdatesAsync(file);
            }
        }

        public void EraseDownloaded()
        {
            var foldersToErase = new[] { "DownloadedFolder", "Templates", "BingDownloaded" };
            var appdata = ApplicationData.Current.LocalFolder;

            foreach (var folderName in foldersToErase)
            {
                var folder = Path.Combine(appdata.Path, folderName);
                DirectoryInfo Dir = new DirectoryInfo(folder);
                foreach (var file in Dir.GetFiles())
                {
                    file.Delete();
                }
                foreach (var dir in Dir.GetDirectories())
                {
                    foreach (var item in dir.GetFiles())
                    {
                        item.Delete();
                    }
                    dir.Delete();
                }
            }
        }

        public string DownloadPath
        {
            get { return _downloadPath; }
            set { _downloadPath = value; }
        }

        public string SettingsPath
        {
            get { return _settingsPath; }
            set { _settingsPath = value; }
        }

        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }
    }
}
