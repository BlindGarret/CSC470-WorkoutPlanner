using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class LoginViewModel : BindableBase, IPageViewComponent
    {

        #region Properties

        public ObservableCollection<ObservableUser> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    RaisePropertyChanged(nameof(Users));
                }
            }
        }

        private ObservableCollection<ObservableUser> _users;

        #endregion

        #region AddUserCommand

        public DelegateCommand AddUserCommand { get; set; }

        private void AddUserCommandOnExecute()
        {
            _eventAggregator.GetEvent<AddUserRequestedEvent>().Publish();
        }

        #endregion

        #region LoginCommand

        public DelegateCommand<ObservableUser> LoginCommand { get; set; }

        private void LoginCommandOnExecute(ObservableUser user)
        {
            _eventAggregator.GetEvent<LoginRequestEvent>().Publish(user.Id);
        }

        #endregion

        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService _dataService;

        public LoginViewModel(IEventAggregator eventAggregator, IDataService dataService)
        {
            _eventAggregator = eventAggregator;
            _dataService = dataService;

            LoginCommand = new DelegateCommand<ObservableUser>(LoginCommandOnExecute);
            AddUserCommand = new DelegateCommand(AddUserCommandOnExecute);
        }

        public void Rendered()
        {
            Users = new ObservableCollection<ObservableUser>(_dataService.GetUsers().Select(x => new ObservableUser(x)));
        }
    }
}
