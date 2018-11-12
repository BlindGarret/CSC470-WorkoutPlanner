using System;
using System.IO;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SQLite;
using WorkoutHelper.Events;
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
        public DelegateCommand<ObservableUser> SaveCommand { get; set; }

        private void SaveCommandOnExecute(ObservableUser saveUser)
        {
            _dataService.SaveUser(saveUser.ToModel());
            _eventAggregator.GetEvent<SettingsChangedEvent>().Publish();
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
            var newName = $"{Guid.NewGuid()}{Path.GetExtension(file)}";
            var newPath = Path.Combine(imagesDir, newName);
            Directory.CreateDirectory(imagesDir);
            File.Copy(file, newPath);

            User.Avatar = newPath;
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;
        private readonly IEventAggregator _eventAggregator;


        public SettingsViewModel(IDataService dataService, ISessionService sessionService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _sessionService = sessionService;
            _eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand<ObservableUser>(SaveCommandOnExecute);
            SaveImageCommand = new DelegateCommand<DragEventArgs>(SaveImageCommandOnExecute);
        }

        public void TabLoaded()
        {
            User = new ObservableUser(_dataService.GetUser(_sessionService.UserId));
        }
    }
}
