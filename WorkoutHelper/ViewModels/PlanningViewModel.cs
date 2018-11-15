using System;
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

        public ObservablePlannedWeekday SelectedDay
        {
            get => _selectedDay;
            set
            {
                if (_selectedDay != value)
                {
                    _selectedDay = value;
                    RaisePropertyChanged(nameof(SelectedDay));
                }
            }
        }

        private ObservablePlannedWeekday _selectedDay;

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
            var today = DateTime.Now;
            var dates = Enumerable.Range(0, 30)
                .Select(offset => today.AddDays(offset))
                .ToList();
            var exercises = _dataService.GetExercises(_sessionService.UserId).Where(x => x.Enabled).ToList();
            var workouts = _workoutGenerator.GenerateWorkouts(dates, exercises,
                _dataService.GetPlans(_sessionService.UserId).ToList());
            _dataService.SaveWorkouts(workouts, _sessionService.UserId);
            TabLoaded();
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;
        private readonly IWorkoutGenerator _workoutGenerator;

        public PlanningViewModel(IDataService dataService, ISessionService sessionService, IWorkoutGenerator workoutGenerator)
        {
            _dataService = dataService;
            _sessionService = sessionService;
            _workoutGenerator = workoutGenerator;

            AddExerciseCommand = new DelegateCommand<ObservablePlannedGroup>(AddExerciseCommandOnExecute);
            AddGroupCommand = new DelegateCommand<ObservablePlannedWeekday>(AddGroupCommandOnExecute);
            SaveCommand = new DelegateCommand(SaveCommandOnExecute);
        }

        public void TabLoaded()
        {
            Plans = new ObservableCollection<ObservablePlannedWeekday>(_dataService.GetPlans(_sessionService.UserId).Select(x => new ObservablePlannedWeekday(x)));
            if (SelectedDay == null)
            {
                SelectedDay = Plans.First();
                return;
            }

            SelectedDay = Plans.FirstOrDefault(x => x.Name == SelectedDay.Name);
        }
    }
}
