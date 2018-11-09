using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Services;
using WorkoutHelper.ViewModels;
using WorkoutHelper.Views;

//This is our bootstrapper. It allows us to intercept the normal startup of the program, with a couple of small changes in App.xaml
// and App.xaml.cs, and change how we control visuals. For a number of reasons we do not want visuals (views) to control how our app functions.
// There really aren't many times where it is a good practice to allow C# code to interact directly with XAML code, without using bindings. However,
// before we realized this WPF made it standard for View to control where there Datacontexts (view models) came from. This code allows us to invert this,
// so we can pass viewmodels into bindings and have that generate views for us. The difference will become more obvious as we begin to use multiple different views.

// This also acts as the entry point to our app, and as such the implementation point of our IOC container. All resolvable services will be registered to there interfaces
// in this class so they can be resolved by them later. See Inversion of Control and Unity Containers on google.

namespace WorkoutHelper.Bootstrap
{
    /// <summary>
    /// Our Derived Unity Bootstrapper class from PRISM.
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {
        /// <inheritdoc />
        protected override DependencyObject CreateShell()
        {
            // We tell our initial view (the shell) how to find it's view model here.
            var shellView = Container.Resolve<ShellView>();
            var viewModel = Container.Resolve<ShellViewModel>();
            shellView.DataContext = viewModel;
            return shellView;
        }

        /// <inheritdoc />
        protected override void InitializeShell()
        {
            //Given that we removed the original code which showed the initial page, we need to tell it what to show here.
            // Now we have control over how our view models are resolved.
            base.InitializeShell();
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow?.Show();
        }

        /// <inheritdoc />
        protected override void ConfigureContainer()
        {
            // Here we configure our unity container with our services.
            base.ConfigureContainer();

            Container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISessionService, SessionService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IConfigurationDataService, ConfigurationDataService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
        }
    }
}
