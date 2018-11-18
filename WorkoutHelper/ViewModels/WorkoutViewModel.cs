using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class WorkoutViewModel : BindableBase, ITabViewComponent
    {
        #region Properties
        public string PageName { get; set; } = "Workout";

        public WorkoutDay WorkoutDay
        {
            get => _workoutDay;
            set
            {
                if (_workoutDay != value)
                {
                    _workoutDay = value;
                    RaisePropertyChanged(nameof(WorkoutDay));
                }
            }
        }

        private WorkoutDay _workoutDay;

        public CompletionData CurrentCompletion
        {
            get => _currentCompletion;
            set
            {
                if (_currentCompletion != value)
                {
                    _currentCompletion = value;
                    RaisePropertyChanged(nameof(CurrentCompletion));
                }
            }
        }

        private CompletionData _currentCompletion;

        public CompletionData LastCompletion
        {
            get => _lastCompletion;
            set
            {
                if (_lastCompletion != value)
                {
                    _lastCompletion = value;
                    RaisePropertyChanged(nameof(LastCompletion));
                }
            }
        }

        private CompletionData _lastCompletion;

        public bool IsRecord
        {
            get => _isRecord;
            set
            {
                if (_isRecord != value)
                {
                    _isRecord = value;
                    RaisePropertyChanged(nameof(IsRecord));
                }
            }
        }

        private bool _isRecord;

        #endregion

        #region CompleteExerciseCommand

        public DelegateCommand CompleteExerciseCommand { get; set; }

        private void CompleteExerciseCommandOnExecute()
        {
            _dataService.CompleteWorkout(WorkoutDay, _sessionService.UserId);
            _dataService.SaveCompletionData(CurrentCompletion, _sessionService.UserId);
            TabLoaded();
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;
        private readonly IWorkoutGenerator _workoutGenerator;

        public WorkoutViewModel(IDataService dataService, ISessionService sessionService, IWorkoutGenerator workoutGenerator)
        {
            _dataService = dataService;
            _sessionService = sessionService;
            _workoutGenerator = workoutGenerator;

            CompleteExerciseCommand = new DelegateCommand(CompleteExerciseCommandOnExecute);
        }

        public void TabLoaded()
        {
            var today = DateTime.Now.Date;
            var workout = _dataService.GetWorkouts(_sessionService.UserId).FirstOrDefault(x => x.Date.Date == today);
            if (workout == null)
            {
                //no workout today
                WorkoutDay = new WorkoutDay
                {
                    Completed = true,
                    Date = today,
                    Groups = new List<WorkoutGroup>()
                };
                CurrentCompletion = new CompletionData {Time = TimeSpan.Zero};
                return;
            }

            WorkoutDay = workout;

            var previousCompletions = _dataService
                .GetCompletionData(_sessionService.UserId, _workoutGenerator.GenerateWorkoutHash(workout))
                .OrderByDescending(x => x.Id)
                .ToList();
            var sortedByTime = previousCompletions.OrderBy(x => x.Time).ToList();

            if (workout.Completed)
            {
                CurrentCompletion = previousCompletions.FirstOrDefault() ?? new CompletionData
                {
                    Hash = _workoutGenerator.GenerateWorkoutHash(workout),
                    Time = TimeSpan.Zero
                };
                if (previousCompletions.Count > 1)
                {
                    LastCompletion = previousCompletions[1];
                }

                IsRecord = sortedByTime.FirstOrDefault() == CurrentCompletion;
                return;
            }

            LastCompletion = previousCompletions.FirstOrDefault();

            CurrentCompletion = new CompletionData
            {
                Hash = _workoutGenerator.GenerateWorkoutHash(workout),
                Time = TimeSpan.Zero
            };
        }
    }
}
