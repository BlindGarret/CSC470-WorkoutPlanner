using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class TabbedViewModel: BindableBase, IPageViewComponent
    {
        #region Properties

        public ITabViewComponent SelectedView
        {
            get => _selectedView;
            set
            {
                if (_selectedView != value)
                {
                    _selectedView = value;
                    RaisePropertyChanged(nameof(SelectedView));
                }
            }
        }

        private ITabViewComponent _selectedView;

        public IReadOnlyList<ITabViewComponent> Views
        {
            get => _views;
            set
            {
                if (!Equals(_views, value))
                {
                    _views = value;
                    RaisePropertyChanged(nameof(Views));
                }
            }
        }

        private IReadOnlyList<ITabViewComponent> _views;

        public string Avatar
        {
            get => _avatar;
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;
                    RaisePropertyChanged(nameof(Avatar));
                }
            }
        }

        private string _avatar;

        public string DisplayName
        {
            get => _displayName;
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    RaisePropertyChanged(nameof(DisplayName));
                }
            }
        }

        private string _displayName;

        #endregion

        #region SelectViewCommand

        public DelegateCommand<ITabViewComponent> SelectViewCommand { get; set; }

        private void SelectViewCommandOnExecute(ITabViewComponent component)
        {
            component.TabLoaded();
            SelectedView = component;
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;

        public TabbedViewModel(IUnityContainer container, IDataService dataService, ISessionService sessionService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _sessionService = sessionService;

            SelectViewCommand = new DelegateCommand<ITabViewComponent>(SelectViewCommandOnExecute);

            eventAggregator.GetEvent<SettingsChangedEvent>().Subscribe(Rendered);

            LoadViews(container);
        }

        public void Rendered()
        {
            var user = _dataService.GetUser(_sessionService.UserId);
            Avatar = user.Avatar;
            DisplayName = $"{user.FirstName} {user.LastName}";
        }

        private void LoadViews(IUnityContainer container)
        {
            SelectedView = container.Resolve<DashboardViewModel>();
            Views = new List<ITabViewComponent>
            {
                SelectedView,
                container.Resolve<WorkoutViewModel>(),
                container.Resolve<ExercisesViewModel>(),
                container.Resolve<PlanningViewModel>(),
                container.Resolve<WeighInViewModel>(),
                container.Resolve<SettingsViewModel>(),
            };
        }
    }
}
