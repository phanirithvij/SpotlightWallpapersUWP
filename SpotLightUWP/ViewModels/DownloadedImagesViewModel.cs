﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
using SpotLightUWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SpotLightUWP.ViewModels
{
    public class DownloadedImagesViewModel : ViewModelBase
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;

        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";
        public const string ImageGalleryAnimationOpen = "ImageGallery_AnimationOpen";
        public const string ImageGalleryAnimationClose = "ImageGallery_AnimationClose";
        private DataService _dataService;
        private object _selected;
        private bool _isLoaded;
        private IOManager _iOManager => Locator.IOManager;
        private HTTPService _httpService => Locator.HTTPService;
        private static string _downloadPath;
        private static string _templatePath;
        private ObservableCollection<ImageDTO> _source;
        private int[] _lastInterval;
        private int _count;

        private GridView _imagesGridView;

        public DownloadedImagesViewModel()
        {
            IsLoaded = false;
            _lastInterval = new int[] { 1, 10 };
            _downloadPath = _iOManager.DownloadPath;
            _templatePath = _iOManager.TemplatePath;
            DataService = new DataService();
        }

        public ICommand ItemSelectedCommand => new RelayCommand<ItemClickEventArgs>(OnsItemSelected);

        public ICommand EraseImages => new RelayCommand(async () => {
            IsLoaded = false;
            await EraseDownloaded();
        });

        public ICommand ToLeft => new RelayCommand(async () => await MoveLeftAsync());

        public ICommand ToRight => new RelayCommand(async () => await MoveRightAsync());

        public async Task InitializeAsync(GridView imagesGridView)
        {
            if (Source == null || Source?.Count == 0)
            {
                await UpdateSourceAsync(_lastInterval);
                _count = _httpService.GetCount();
            }
            _imagesGridView = imagesGridView;
            IsLoaded = true;
        }

        public async Task LoadAnimationAsync()
        {
            var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGallerySelectedIdKey);
            if (selectedImageId != null)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryAnimationClose);
                if (animation != null)
                {
                    var item = _imagesGridView.Items.FirstOrDefault(i => ((ImageDTO)i).Id == selectedImageId);
                    _imagesGridView.ScrollIntoView(item);
                    await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage");
                }

                ApplicationData.Current.LocalSettings.SaveString(ImageGallerySelectedIdKey, string.Empty);
            }
        }

        private async Task UpdateSourceAsync(int[] interval)
        {
            Source = await DataService.GetGalleryDataAsync(interval, false);
        }

        private async Task EraseDownloaded()
        {
            DirectoryInfo templateDir = new DirectoryInfo(_templatePath);
            foreach (var file in templateDir.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo downloadDir = new DirectoryInfo(_downloadPath);
            foreach (var file in downloadDir.GetFiles())
            {
                file.Delete();
            }

            await UpdateSourceAsync(_lastInterval);
            IsLoaded = true;
        }

        private async Task MoveLeftAsync()
        {
            if (_lastInterval[0] > 1)
            {
                IsLoaded = false;
                _lastInterval[0] -= 10;
                _lastInterval[1] -= 10;

                await UpdateSourceAsync(_lastInterval);
                IsLoaded = true;
            }
        }

        private async Task MoveRightAsync()
        {
            if (_lastInterval[1] <= _count)
            {
                IsLoaded = false;
                _lastInterval[0] += 10;
                _lastInterval[1] += 10;

                await UpdateSourceAsync(_lastInterval);
                IsLoaded = true;
            }
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ImageDTO;
            _imagesGridView.PrepareConnectedAnimation(ImageGalleryAnimationOpen, selected, "galleryImage");
            NavigationService.Navigate(typeof(ImageGalleryDetailViewModel).FullName, new ImageDetailNavigationParams(Source, selected.Id));
        }

        public NavigationServiceEx NavigationService
        {
            get
            {
                return CommonServiceLocator.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            }
        }

        public object Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public DataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set
            {
                _isLoaded = value;
                RaisePropertyChanged(nameof(IsLoaded));
            }
        }
    }
}