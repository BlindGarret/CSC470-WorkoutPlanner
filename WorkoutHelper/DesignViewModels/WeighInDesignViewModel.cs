using Prism.Commands;
using Prism.Mvvm;

namespace WorkoutHelper.DesignViewModels
{
    public class WeighInDesignViewModel : BindableBase
    {
        #region Properties

        public string PageName { get; set; }

        public double Weight { get; set; } = 200.0; //Somehow prepopulate with previous weight?

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion

    }
}
