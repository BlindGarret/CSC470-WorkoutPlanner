using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservablePlannedExercise : BindableBase
    {
        #region Propeties

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        private int _id;

        public string MuscleGroup
        {
            get => _muscleGroup;
            set
            {
                if (_muscleGroup != value)
                {
                    _muscleGroup = value;
                    RaisePropertyChanged(nameof(MuscleGroup));
                }
            }
        }

        private string _muscleGroup;

        public int Difficulty
        {
            get => _difficulty;
            set
            {
                if (_difficulty != value)
                {
                    _difficulty = value;
                    RaisePropertyChanged(nameof(Difficulty));
                }
            }
        }

        private int _difficulty;

        public bool AllowFreeWeights
        {
            get => _allowFreeWeights;
            set
            {
                if (_allowFreeWeights != value)
                {
                    _allowFreeWeights = value;
                    RaisePropertyChanged(nameof(AllowFreeWeights));
                }
            }
        }

        private bool _allowFreeWeights;

        public bool AllowMachines
        {
            get => _allowMachines;
            set
            {
                if (_allowMachines != value)
                {
                    _allowMachines = value;
                    RaisePropertyChanged(nameof(AllowMachines));
                }
            }
        }

        private bool _allowMachines;

        #endregion

        public ObservablePlannedExercise(PlannedExercise exercise)
        {
            Id = exercise.Id;
            MuscleGroup = exercise.MuscleGroup;
            Difficulty = exercise.Difficulty;
            AllowFreeWeights = exercise.AllowFreeWeights;
            AllowMachines = exercise.AllowMachines;
        }

        public PlannedExercise ToModel()
        {
            return new PlannedExercise
            {
                Id = Id,
                MuscleGroup = MuscleGroup,
                Difficulty = Difficulty,
                AllowFreeWeights = AllowFreeWeights,
                AllowMachines = AllowMachines
            };
        }
    }
}
