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

        public double Weight { get; set; } = 200.0;

        public string CurrentDate
        {
            get => DateTime.Today.ToLongDateString();
        }

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion

    }
}
