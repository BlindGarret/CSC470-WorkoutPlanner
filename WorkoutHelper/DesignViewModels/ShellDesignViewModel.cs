using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

//This is not a class which really ships with the product. This is basically a stub for building UIs.

//What you do is stub in a the properties and commands from your real view model, with static values.
// This allows you to use the visual preview of your form in VS with values, and gives you intellisense when typing out WPF

//No need to DOC comment these members.

namespace WorkoutHelper.DesignViewModels
{
    public class ShellDesignViewModel : BindableBase
    {
        #region Properties

        public ITabViewComponent SelectedView { get; set; } = new MockViewComponent("Dashboard");

        public IReadOnlyList<ITabViewComponent> Views { get; set; } = new List<ITabViewComponent>() { new MockViewComponent("Dashboard"), new MockViewComponent("Another"), new MockViewComponent("And Another"), };

        #endregion

        #region Commands

        public DelegateCommand<ITabViewComponent> SelectViewCommand { get; set; }

        #endregion

        private class MockViewComponent : ITabViewComponent
        {
            public string PageName { get; }
            public void TabLoaded()
            {
            }

            public MockViewComponent(string name)
            {
                PageName = name;
            }
        }
    }
}
