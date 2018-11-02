using System.Collections.ObjectModel;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class DashboardDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; }

        public ObservableCollection<WorkoutDay> WorkoutDays { get; set; }

        public ObservableCollection<WeighIn> WeighIns { get; set; }

        #endregion

    }
}
