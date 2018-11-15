using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.DesignViewModels
{
    public class PlanningDesignViewModel : BindableBase
    {

        #region Properties

        public string PageName { get; set; }

        public ObservableCollection<ObservablePlannedWeekday> Plans { get; set; }

        public ObservablePlannedWeekday SelectedDay { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<ObservablePlannedGroup> AddExerciseCommand { get; set; }

        public DelegateCommand<ObservablePlannedWeekday> AddGroupCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion

        public PlanningDesignViewModel()
        {
            Plans = MockPlan();
            SelectedDay = Plans[0];
        }

        private static ObservableCollection<ObservablePlannedWeekday> MockPlan()
        {
            var exerciseSetOne = new[]
            {
                new PlannedExercise
                {
                    AllowFreeWeights = false,
                    AllowMachines = true,
                    Difficulty = 10,
                    MuscleGroup = "A Muscle Group"
                },
                new PlannedExercise
                {
                    AllowFreeWeights = true,
                    AllowMachines = true,
                    Difficulty = 2,
                    MuscleGroup = "A Muscle Group"
                }
            };

            var exerciseSetTwo = new[]
            {
                new PlannedExercise
                {
                    AllowFreeWeights = true,
                    AllowMachines = false,
                    Difficulty = 3,
                    MuscleGroup = "Another Muscle Group"
                }
            };

            var groups = new[]
            {
                new PlannedGroup()
                {
                    DayOfWeek = "Sunday",
                    Exercises = new List<PlannedExercise>(exerciseSetTwo),
                    Order = 1,
                    Id = 1
                },
                new PlannedGroup()
                {
                    DayOfWeek = "Sunday",
                    Exercises = new List<PlannedExercise>(exerciseSetTwo),
                    Order = 2,
                    Id = 2
                }
            };

            var weekDays = new[]
            {
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Sunday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Monday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Tuesday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Wednesday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Thursday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Friday"
                },
                new PlannedWeekday
                {
                    Enabled = true,
                    Groups = new List<PlannedGroup>(groups),
                    Name = "Sat"
                },
            };
            return new ObservableCollection<ObservablePlannedWeekday>(weekDays.Select(x => new ObservablePlannedWeekday(x)));
        }
    }
}
