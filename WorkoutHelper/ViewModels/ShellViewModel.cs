using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class ShellViewModel : BindableBase
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

        #endregion

        #region SelectViewCommand

        public DelegateCommand<ITabViewComponent> SelectViewCommand { get; set; }

        private void SelectViewCommandOnExecute(ITabViewComponent component)
        {
            SelectedView = component;
        }

        #endregion
        
        public ShellViewModel(IUnityContainer container)
        {
            SelectViewCommand = new DelegateCommand<ITabViewComponent>(SelectViewCommandOnExecute);
            LoadViews(container);
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
