using System.Collections.ObjectModel;
using System.Security.Claims;
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
            //todo: get actual user id
            _dataService.EnableExercise(exercise.Id, 1);
        }

        #endregion

        #region DisableExerciseCommand

        public DelegateCommand<Exercise> DisableExerciseCommand { get; set; }

        private void DisableExerciseCommandOnExecute(Exercise exercise)
        {
            //todo: get actual user id
            _dataService.DisableExercise(exercise.Id, 1);
        }

        #endregion

        private readonly IDataService _dataService;

        public ExercisesViewModel(IDataService dataService)
        {
            _dataService = dataService;

            EnableExerciseCommand = new DelegateCommand<Exercise>(EnableExerciseCommandOnExecute);
            DisableExerciseCommand = new DelegateCommand<Exercise>(DisableExerciseCommandOnExecute);

            //todo: get actual user id
            Exercises = new ObservableCollection<Exercise>(_dataService.GetExercises(1));
        }
        
        public void TabLoaded()
        {
            //todo: get actual user id
            Exercises = new ObservableCollection<Exercise>(_dataService.GetExercises(1));
        }
    }
}
