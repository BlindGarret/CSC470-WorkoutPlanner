using Prism.Mvvm;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class SettingsViewModel : BindableBase, ITabViewComponent
    {
        public string PageName { get; set; } = "Settings";
        public void TabLoaded()
        {
        }
    }
}
