using System.Windows;
using Prism.Commands;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.DesignViewModels
{
    public class AddUserDesignViewModel
    {
        #region Properties
        
        public ObservableUser User { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddUserCommand { get; set; }

        public DelegateCommand<DragEventArgs> SaveImageCommand { get; set; }

        #endregion
    }
}
