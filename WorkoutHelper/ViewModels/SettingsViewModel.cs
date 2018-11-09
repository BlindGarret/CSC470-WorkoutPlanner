using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using SQLite;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class SettingsViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Settings";
        public ObservableUser User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    RaisePropertyChanged(nameof(User));
                }
            }
        }
        private ObservableUser _user;
        #endregion

        #region SaveCommand
        private readonly IConfigurationDataService _config;
        public DelegateCommand<User> SaveCommand { get; set; }
        private void SaveCommandOnExecute(User saveUser)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                connection.Update(saveUser);
            }
        }
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
            var newName = $"{Path.GetFileNameWithoutExtension(file)}-{User.FirstName}-{User.LastName}-{User.Id}{Path.GetExtension(file)}";
            var newPath = Path.Combine(imagesDir, newName);
            Directory.CreateDirectory(imagesDir);
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            File.Copy(file, newPath);

            //todo: SAVE NEW PATH IN USER!
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;


        public SettingsViewModel(IDataService dataService, ISessionService sessionService)
        {
            _dataService = dataService;
            _sessionService = sessionService;

            SaveCommand = new DelegateCommand<User>(SaveCommandOnExecute);
            SaveImageCommand = new DelegateCommand<DragEventArgs>(SaveImageCommandOnExecute);
        }

        public void TabLoaded()
        {
            User = new ObservableUser(_dataService.GetUser(_sessionService.UserId));
        }
    }
}
