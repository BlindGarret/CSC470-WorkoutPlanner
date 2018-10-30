using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class SettingsDesignViewmodel : BindableBase
    {

        #region Properties
        
        public User User { get; set; }

        public WeighIn WeighIn { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
