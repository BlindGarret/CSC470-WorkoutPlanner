using System;
using Prism.Commands;
using Prism.Mvvm;
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

        public int Counter { get; set; } = 0;

        public ExampleDataModel ExampleDataModel { get; set; } = new ExampleDataModel(){DateTime = DateTimeOffset.Now.ToString(), Value = 3};

        public bool SavedDataExists { get; set; } = true;

        #endregion

        #region Commands

        public DelegateCommand IncrementCommand { get; set; }

        public DelegateCommand LoadCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion

    }
}
