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

        private readonly IDataService _dataService;
        public SettingsViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void TabLoaded()
        {
            //todo: get actual user id
            User = _dataService.GetSettings(1);
        }
    }
}
