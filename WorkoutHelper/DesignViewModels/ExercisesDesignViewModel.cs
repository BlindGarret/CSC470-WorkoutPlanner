﻿using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class ExercisesDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; }

        public ObservableCollection<Exercise> Exercises { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<Exercise> EnableExerciseCommand { get; set; }

        public DelegateCommand<Exercise> DisableExerciseCommand { get; set; }

        #endregion
    }
}
