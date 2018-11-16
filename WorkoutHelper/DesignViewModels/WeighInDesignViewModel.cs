using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace WorkoutHelper.DesignViewModels
{
    public class WeighInDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; }

        public string CurrentDate { get; set; }

        public double Weight { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
