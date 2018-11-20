using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Extensions;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class DashboardDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; } = "Dashboard";

        public ObservableCollection<WorkoutDay> WorkoutDays { get; set; } = new ObservableCollection<WorkoutDay>(new[]
        {
            new WorkoutDay
            {
                Date = DateTime.Now,
                Groups = new List<WorkoutGroup>(new []
                {
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    },
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    }
                })
            },
            new WorkoutDay
            {
                Date = DateTime.Now.AddDays(2),
                Groups = new List<WorkoutGroup>(new []
                {
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    },
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    }
                })
            },
            new WorkoutDay
            {
                Date = DateTime.Now.AddDays(4),
                Groups = new List<WorkoutGroup>(new []
                {
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    },
                    new WorkoutGroup
                    {
                        Workouts = new List<Workout>(new []
                        {
                            new Workout
                            {
                                RepetitionCount = 20,
                                Exercise =  new Exercise
                                {
                                    Name = "Pushups"
                                }
                            },
                            new Workout
                            {
                                RepetitionCount = 30,
                                Exercise =  new Exercise
                                {
                                    Name = "Situps"
                                }
                            },
                        })
                    }
                })
            }
        });

        public ObservableCollection<WeighIn> WeighIns { get; set; }

        #endregion

        #region ReplanWorkoutsCommand

        public DelegateCommand ReplanWorkoutsCommand { get; set; }

        #endregion

        public DashboardDesignViewModel()
        {
            WeighIns = new ObservableCollection<WeighIn>(new[]
            {
                new WeighIn
                {
                    Date = DateTime.Now,
                    Value = 1
                },
                new WeighIn
                {
                    Date = DateTime.Now.AddDays(1),
                    Value = 2
                },
                new WeighIn
                {
                    Date = DateTime.Now.AddDays(2),
                    Value = 3
                },
                new WeighIn
                {
                    Date = DateTime.Now.AddDays(3),
                    Value = 4
                },
                new WeighIn
                {
                    Date = DateTime.Now.AddDays(4),
                    Value = 5
                },
                new WeighIn
                {
                    Date = DateTime.Now.AddDays(5),
                    Value = 6
                },
            });
        }
    }
}
