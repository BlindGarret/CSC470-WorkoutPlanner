﻿using System.Collections.Generic;
using Prism.Commands;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.DesignViewModels
{
    class TabbedDesignViewModel
    {
        #region Properties

        public ITabViewComponent SelectedView { get; set; } = new MockViewComponent("Dashboard");

        public IReadOnlyList<ITabViewComponent> Views { get; set; } = new List<ITabViewComponent>()
        {
            new MockViewComponent("Dashboard"),
            new MockViewComponent("Workout"),
            new MockViewComponent("Exercises"),
            new MockViewComponent("Planning"),
            new MockViewComponent("Weigh In"),
            new MockViewComponent("Settings")
        };

        public string Avatar { get; set; }

        public string DisplayName { get; set; } = "Herp A Derp";

        #endregion

        #region Commands

        public DelegateCommand<ITabViewComponent> SelectViewCommand { get; set; }

        public DelegateCommand<ITabViewComponent> LogoutCommand { get; set; }
        
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
