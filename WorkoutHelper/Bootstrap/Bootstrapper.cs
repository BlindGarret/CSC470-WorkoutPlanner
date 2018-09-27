using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Services;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Bootstrap
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shellView = Container.Resolve<ShellView>();
            var viewModel = Container.Resolve<ShellViewModel>();
            shellView.DataContext = viewModel;
            return shellView;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow?.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //This is a registration of a type, the lifetime manager makes it a singleton type so any call to resolve will return the same class.
            Container.RegisterType<IExampleDataService, ExampleDataService>(new ContainerControlledLifetimeManager());
        }
    }
}
