using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class SettingsDesignViewModel : BindableBase
    {

        #region Properties

        public string PageName { get; set; }

        public User User { get; set; }

        public WeighIn WeighIn { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
