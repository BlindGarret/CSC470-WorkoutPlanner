using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class WorkoutDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; } = "Workout";

        public WorkoutDay WorkoutDay { get; set; } = new WorkoutDay
        {
            Completed = true,
            Date = DateTime.Now,
            Groups = new List<WorkoutGroup>(new[] {
                new WorkoutGroup
                {
                    Workouts = new List<Workout>(new []
                    {
                        new Workout
                        {
                            RepetitionCount = 10,
                            Exercise = new Exercise
                            {
                                Name = "Situps",
                                Description = "A Description"
                            }
                        },
                        new Workout
                        {
                            RepetitionCount = 20,
                            Exercise = new Exercise
                            {
                                Name = "Situps",
                                Description = "A Description\r\n yep \r\n yep"
                            }
                        }
                    })
                },
                new WorkoutGroup
                {
                    Workouts = new List<Workout>(new []
                    {
                        new Workout
                        {
                            RepetitionCount = 30,
                            Exercise = new Exercise
                            {
                                Name = "Herp Derps",
                                Description = "A Description"
                            }
                        },
                        new Workout
                        {
                            RepetitionCount = 40,
                            Exercise = new Exercise
                            {
                                Name = "A REALLY LONG NAME FOR A WORKOUT",
                                Description = "A Description"
                            }
                        }
                    })
                }
            })
        };

        public CompletionData CurrentCompletion { get; set; } = new CompletionData
        {
            Notes = "Some notes!",
            Time = TimeSpan.FromSeconds(3000)
        };


        public CompletionData LastCompletion { get; set; } = new CompletionData
        {
            Notes = "Some notes!",
            Time = TimeSpan.FromSeconds(3000)
        };

        public bool IsRecord { get; set; } = true;

        #endregion

        #region Commands

        public DelegateCommand CompleteExerciseCommand { get; set; }

        #endregion
    }
}
