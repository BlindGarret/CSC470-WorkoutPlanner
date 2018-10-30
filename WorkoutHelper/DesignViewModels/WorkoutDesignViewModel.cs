using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class WorkoutDesignViewModel : BindableBase
    {
        #region Properties

        public WorkoutDay WorkoutDay { get; set; }

        public CompletionData CurrentCompletion { get; set; }

        public CompletionData LastCompletion { get; set; }

        public bool IsRecord { get; set; }

        #endregion

        #region Commands
        
        public DelegateCommand CompleteExerciseCommand { get; set; }

        #endregion
    }
}
