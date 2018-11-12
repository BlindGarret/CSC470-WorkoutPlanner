using System.Collections.ObjectModel;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class PlanningViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Planning";

        public ObservableCollection<ObservablePlannedWeekday> Plans
        {
            get => _plans;
            set
            {
                if (_plans != value)
                {
                    _plans = value;
                    RaisePropertyChanged(nameof(Plans));
                }
            }
        }

        private ObservableCollection<ObservablePlannedWeekday> _plans;

        #endregion

        public void TabLoaded()
        {
        }
    }
}
