using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

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

        #region AddExerciseCommand

        public DelegateCommand<ObservablePlannedGroup> AddExerciseCommand { get; set; }

        private void AddExerciseCommandOnExecute(ObservablePlannedGroup group)
        {
            group.Exercises.Add(new ObservablePlannedExercise(new PlannedExercise()));
        }

        #endregion

        #region AddGroupCommand

        public DelegateCommand<ObservablePlannedWeekday> AddGroupCommand { get; set; }

        private void AddGroupCommandOnExecute(ObservablePlannedWeekday weekday)
        {
            weekday.Groups.Add(new ObservablePlannedGroup(new PlannedGroup {Order = weekday.Groups.Count > 0 ? weekday.Groups.Max(x => x.Order) + 1 : 1}));
        }

        #endregion

        #region SaveCommand

        public DelegateCommand SaveCommand { get; set; }

        private void SaveCommandOnExecute()
        {
            _dataService.SavePlans(Plans.Select(x => x.ToModel()), _sessionService.UserId);
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;

        public PlanningViewModel(IDataService dataService, ISessionService sessionService)
        {
            _dataService = dataService;
            _sessionService = sessionService;

            AddExerciseCommand = new DelegateCommand<ObservablePlannedGroup>(AddExerciseCommandOnExecute);
            AddGroupCommand = new DelegateCommand<ObservablePlannedWeekday>(AddGroupCommandOnExecute);
            SaveCommand = new DelegateCommand(SaveCommandOnExecute);
        }

        public void TabLoaded()
        {
            Plans = new ObservableCollection<ObservablePlannedWeekday>(_dataService.GetPlans(_sessionService.UserId).Select(x => new ObservablePlannedWeekday(x)));
        }
    }
}
