using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.DesignViewModels
{
    class TabbedDesignViewModel
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
