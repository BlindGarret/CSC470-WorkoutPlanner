using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class WorkoutViewModel : BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Workout";
    }
}
