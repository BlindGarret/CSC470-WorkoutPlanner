using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ExercisesViewModel : BindableBase, ITabViewComponent
    {
        #region Properties
        public string PageName { get; set; } = "Exercises";

        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set
            {
                if (_exercises != value)
                {
                    _exercises = value;
                    RaisePropertyChanged(nameof(Exercises));
                }
            }
        }

        private ObservableCollection<Exercise> _exercises;
        #endregion
        
        #region EnableExerciseCommand

        public DelegateCommand<Exercise> EnableExerciseCommand { get; set; }

        private void EnableExerciseCommandOnExecute(Exercise exercise)
        {
            _dataService.EnableExercise(exercise.Id, _sessionService.UserId);
        }

        #endregion

        #region DisableExerciseCommand

        public DelegateCommand<Exercise> DisableExerciseCommand { get; set; }

        private void DisableExerciseCommandOnExecute(Exercise exercise)
        {
            _dataService.DisableExercise(exercise.Id, _sessionService.UserId);
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;

        public ExercisesViewModel(IDataService dataService, ISessionService sessionService)
        {
            _dataService = dataService;
            _sessionService = sessionService;

            EnableExerciseCommand = new DelegateCommand<Exercise>(EnableExerciseCommandOnExecute);
            DisableExerciseCommand = new DelegateCommand<Exercise>(DisableExerciseCommandOnExecute);
        }
        
        public void TabLoaded()
        {
            Exercises = new ObservableCollection<Exercise>(_dataService.GetExercises(_sessionService.UserId).OrderBy(x => x.Name));
        }
    }
}
