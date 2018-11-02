using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class ExercisesViewModel : BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Exercises";
    }
}
