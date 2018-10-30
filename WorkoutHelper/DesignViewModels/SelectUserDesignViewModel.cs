using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class SelectUserDesignViewModel : BindableBase
    {

        #region Properties

        public ObservableCollection<User> Users { get; set; }

        #endregion

        #region Commands
        
        public DelegateCommand<User> SelectUserCommand { get; set; }

        public DelegateCommand<User> AddUserCommand { get; set; }

        #endregion
    }
}
