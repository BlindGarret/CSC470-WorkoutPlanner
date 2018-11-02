using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class WeighInViewModel : BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Weigh In";
        public void TabLoaded()
        {
        }
    }
}
