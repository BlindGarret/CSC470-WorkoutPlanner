using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.DesignViewModels
{
    public class LoginDesignViewModel: BindableBase
    {
        public ObservableCollection<ObservableUser> Users { get; set; } = new ObservableCollection<ObservableUser>(new []
        {
            new ObservableUser(new User() { FirstName = "Herp", LastName = "Derp", Height = 100, Weight = 101.2, Id = 1}),
            new ObservableUser(new User() { FirstName = "Derp", LastName = "Derp", Height = 100, Weight = 101.2, Id = 2}),
            new ObservableUser(new User() { FirstName = "Merp", LastName = "Derp", Height = 100, Weight = 101.2, Id = 3}),
        });

        public DelegateCommand<ObservableUser> LoginCommand { get; set; }

        public DelegateCommand AddUserCommand { get; set; }
    }
}
