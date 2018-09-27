using System;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.DesignViewModels
{
    public class ShellDesignViewModel : BindableBase
    {
        #region Properties

        public int Counter { get; set; } = 0;

        public ExampleDataModel ExampleDataModel { get; set; } = new ExampleDataModel(){DateTime = DateTimeOffset.Now.ToString(), Value = 3};

        public bool SavedDataExists { get; set; } = true;

        #endregion

        #region IncrementCommand

        public DelegateCommand IncrementCommand { get; set; }

        #endregion

        #region LoadCommand

        public DelegateCommand LoadCommand { get; set; }

        #endregion

        #region SaveCommand

        public DelegateCommand SaveCommand { get; set; }

        #endregion


    }
}
