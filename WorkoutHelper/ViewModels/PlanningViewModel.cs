using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class PlanningViewModel : BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Planning";
    }
}
