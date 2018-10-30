using System;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class ShellDesignViewModel : BindableBase
    {
        #region Properties

        public double Weight { get; set; } = 200.0; //Somehow prepopulate with previous weight?

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion

    }
}
