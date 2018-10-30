using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class PlanningDesignViewmodel : BindableBase
    {

        #region Properties

        public ObservableCollection<Plan> Plans { get; set; }

        public Plan SelectedPlan { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<WorkoutGroup> AddExercise { get; set; }

        public DelegateCommand AddGroup { get; set; }

        #endregion
    }
}
