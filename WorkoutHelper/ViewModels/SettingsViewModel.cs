using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
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

        private readonly IDataService _dataService;
        public SettingsViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void TabLoaded()
        {
            //todo: get actual user id
            Settings = _dataService.GetSettings(1);
        }
    }
}
