using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Properties

        public IPageViewComponent SelectedView
        {
            get => _selectedView;
            set
            {
                if (_selectedView != value)
                {
                    _selectedView = value;
                    RaisePropertyChanged(nameof(SelectedView));
                }
            }
        }

        private IPageViewComponent _selectedView;

        #endregion

        //Due to how Event Aggregators weak referencing works these are required.
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IPageViewComponent _tabbedPage;
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IPageViewComponent _addUserPage;
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IPageViewComponent _loginPage;

        public ShellViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _tabbedPage = container.Resolve<TabbedViewModel>();
            _loginPage = container.Resolve<LoginViewModel>();
            //todo: fix this
            _addUserPage = container.Resolve<TabbedViewModel>();
            
            RenderPage(_loginPage);

            eventAggregator.GetEvent<LoginEvent>().Subscribe(id =>
            {
                RenderPage(_tabbedPage);
            });
            eventAggregator.GetEvent<AddUserRequestedEvent>().Subscribe(() => RenderPage(_addUserPage));
            eventAggregator.GetEvent<LogoutEvent>().Subscribe(() => RenderPage(_loginPage));
        }

        private void RenderPage(IPageViewComponent page)
        {
            SelectedView = page;
            page.Rendered();
        }
    }
}
