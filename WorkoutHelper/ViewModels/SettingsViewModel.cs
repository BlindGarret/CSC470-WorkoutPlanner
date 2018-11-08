using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class SettingsViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Settings";
        public User Settings
        {
            get => _settings;
            set
            {
                if (_settings != value)
                {
                    _settings = value;
                    RaisePropertyChanged(nameof(Settings));
                }
            }
        }
        private User _settings;
        #endregion

        #region SaveImageCommand

        public DelegateCommand<DragEventArgs> SaveImageCommand { get; set; }

        private void SaveImageCommandOnExecute(DragEventArgs args)
        {
            var imageExtensions = new [] { ".JPG", ".JPE", ".JPEG", ".BMP",  ".PNG" };

            var files = (string[]) args.Data.GetData((DataFormats.FileDrop));
            if (files == null || files.Length < 1)
            {
                return;
            }

            var file = files.First();
            if (file == null || !imageExtensions.Contains(Path.GetExtension(file)?.ToUpperInvariant()))
            {
                return;
            }

            var imagesDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "imgs");
            var newPath = Path.Combine(imagesDir, Path.GetFileName(file));
            Directory.CreateDirectory(imagesDir);
            Console.WriteLine(newPath);
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            File.Copy(file, newPath);

            //todo: SAVE NEW PATH IN USER!
        }

        #endregion

        private readonly IDataService _dataService;
        public SettingsViewModel(IDataService dataService)
        {
            _dataService = dataService;

            SaveImageCommand = new DelegateCommand<DragEventArgs>(SaveImageCommandOnExecute);
        }
        public void TabLoaded()
        {
            //todo: get actual user id
            Settings = _dataService.GetSettings(1);
        }
    }
}
