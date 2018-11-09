using System;
using System.IO;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class AddUserViewModel : BindableBase, IPageViewComponent
    {
        #region Properties

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

        #region SaveImageCommand

        public DelegateCommand<DragEventArgs> SaveImageCommand { get; set; }

        private void SaveImageCommandOnExecute(DragEventArgs args)
        {
            var imageExtensions = new[] { ".JPG", ".JPE", ".JPEG", ".BMP", ".PNG" };

            var files = (string[])args.Data.GetData((DataFormats.FileDrop));
            if (files == null || files.Length < 1)
            {
                return;
            }

            var file = files.First();
            if (file == null || !imageExtensions.Contains(Path.GetExtension(file)?.ToUpperInvariant()))
            {
                return;
            }

            var imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imgs");
            var newName = $"{Path.GetFileNameWithoutExtension(file)}-{User.FirstName}-{User.LastName}-{User.Id}{Path.GetExtension(file)}";
            var newPath = Path.Combine(imagesDir, newName);
            Directory.CreateDirectory(imagesDir);
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            File.Copy(file, newPath);

            User.Avatar = newPath;
        }

        #endregion

        #region AddUserCommand

        public DelegateCommand AddUserCommand { get; set; }

        private void AddUserCommandOnExecute()
        {
            var id = _dataService.AddUser(User.ToModel());
            _eventAggregator.GetEvent<LoginRequestEvent>().Publish(id);
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly IEventAggregator _eventAggregator;

        public AddUserViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            SaveImageCommand = new DelegateCommand<DragEventArgs>(SaveImageCommandOnExecute);
            AddUserCommand = new DelegateCommand(AddUserCommandOnExecute);
        }

        public void Rendered()
        {
            User = new ObservableUser(new User());
        }
    }
}
