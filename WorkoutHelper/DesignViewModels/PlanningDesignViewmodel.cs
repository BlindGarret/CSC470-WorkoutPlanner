using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class PlanningDesignViewModel : BindableBase
    {

        #region Properties

        public string PageName { get; set; }

        public ObservableCollection<Plan> Plans { get; set; }

        public Plan SelectedPlan { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<WorkoutGroup> AddExercise { get; set; }

        public DelegateCommand AddGroup { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
