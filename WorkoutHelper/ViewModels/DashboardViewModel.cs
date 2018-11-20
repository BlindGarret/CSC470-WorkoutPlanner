using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using InteractiveDataDisplay.WPF;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Extensions;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class DashboardViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Dashboard";

        public LineGraph LineGraph { get; set; }

        public ObservableCollection<WorkoutDay> WorkoutDays
        {
            get => _workoutDays;
            set
            {
                if (_workoutDays != value)
                {
                    _workoutDays = value;
                    RaisePropertyChanged(nameof(WorkoutDays));
                }
            }
        }

        private ObservableCollection<WorkoutDay> _workoutDays;

        #endregion

        #region ReplanWorkoutsCommand

        public DelegateCommand ReplanWorkoutsCommand { get; set; }

        private void ReplanWorkoutsCommandOnExecute()
        {
            var today = DateTime.Now;
            var plans = _dataService.GetPlans(_sessionService.UserId).ToList();
            var dates = Enumerable.Range(0, 14)
                .Select(offset => today.AddDays(offset))
                .ToList();
            var exercises = _dataService.GetExercises(_sessionService.UserId).Where(x => x.Enabled).ToList();
            var workouts = _workoutGenerator.GenerateWorkouts(dates, exercises, plans);
            _dataService.SaveWorkouts(workouts, _sessionService.UserId);
            TabLoaded();
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;
        private readonly IWorkoutGenerator _workoutGenerator;

        public DashboardViewModel(IDataService dataService, ISessionService sessionService, IWorkoutGenerator workoutGenerator)
        {
            _dataService = dataService;
            _sessionService = sessionService;
            _workoutGenerator = workoutGenerator;

            ReplanWorkoutsCommand = new DelegateCommand(ReplanWorkoutsCommandOnExecute);
        }

        public void TabLoaded()
        {
            var weights = _dataService.GetWeighIns(_sessionService.UserId).OrderByDescending(x => x.Date).Take(30).OrderBy(x => x.Date).ToList();
            var workouts = _dataService.GetWorkouts(_sessionService.UserId);
            WorkoutDays = new ObservableCollection<WorkoutDay>(workouts.OrderBy(x => x.Date).Take(3));
            var today = DateTime.Now;
            var daysAgo = weights.Select(x => today.Subtract(x.Date).Days * -1);
            LineGraph?.Plot(daysAgo, weights.Select(x => x.Value));
        }
    }
}
