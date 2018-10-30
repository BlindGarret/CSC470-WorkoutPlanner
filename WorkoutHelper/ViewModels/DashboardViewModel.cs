using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class DashboardViewModel: BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Dashboard";
    }
}
