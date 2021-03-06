﻿using SpotLightUWP.Services.Base;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System.UserProfile;

namespace SpotLightUWP.Services
{
    public class WallpaperService : IWallpaperService
    {
        public async Task PickAndSetWallpaper()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                await SetAsAsync(image: file);
            }
        }

        public async Task<bool> SetAsAsync(string Uri = null, StorageFile image = null, SetAs setAs = SetAs.Wallpaper)
        {
            bool success = false;
            StorageFile file;
            if (UserProfilePersonalizationSettings.IsSupported())
            {
                try
                {
                    file = image ?? await StorageFile.GetFileFromPathAsync(Uri) ?? throw new ArgumentNullException(nameof(image));
                }
                catch (Exception)
                {
                    throw;
                }

                var wallpaperPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Wallpaper");
                if (!Directory.Exists(wallpaperPath))
                {
                    Directory.CreateDirectory(wallpaperPath);
                }

                IStorageFolder wallpaperFolder = await StorageFolder.GetFolderFromPathAsync(wallpaperPath);
                var copiedFile = await file.CopyAsync(wallpaperFolder, file.Name, NameCollisionOption.ReplaceExisting);
                UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                if (setAs == SetAs.Wallpaper)
                {
                    success = await profileSettings.TrySetWallpaperImageAsync(copiedFile);
                }
                else
                {
                    success = await profileSettings.TrySetLockScreenImageAsync(copiedFile);
                }
            }
            return success;
        }
    }

    public enum SetAs
    {
        Wallpaper,
        Lockscreen
    }
}
