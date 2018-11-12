using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.DesignViewModels
{
    public class PlanningDesignViewModel : BindableBase
    {

        #region Properties

        public string PageName { get; set; }

        public ObservableCollection<ObservablePlannedWeekday> Plans { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<WorkoutGroup> AddExercise { get; set; }

        public DelegateCommand AddGroup { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
