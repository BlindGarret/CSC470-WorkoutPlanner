﻿using Prism.Mvvm;
using WorkoutHelper.Interfaces;

//This is not a class which really ships with the product. This is basically a stub for building UIs.

//What you do is stub in a the properties and commands from your real view model, with static values.
// This allows you to use the visual preview of your form in VS with values, and gives you intellisense when typing out WPF

//No need to DOC comment these members.

namespace WorkoutHelper.DesignViewModels
{
    public class ShellDesignViewModel : BindableBase
    {
        public IPageViewComponent SelectedView { get; set; } = new MockViewComponent();

        private class MockViewComponent : IPageViewComponent
        {
            public void Rendered()
            {
            }
        }
    }
}
