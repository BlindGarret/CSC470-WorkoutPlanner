using System;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class WeighInViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Weigh In";

        #endregion

        public void TabLoaded()
        {
            
        }
    }
}
