using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Properties

        public BindableBase SelectedView
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

        private BindableBase _selectedView;


        public IReadOnlyList<BindableBase> Views { get; set; }

        private bool _savedDataExists;

        #endregion

        #region IncrementCommand

        /// <summary>
        /// Command for incrementing the counter.
        /// </summary>
        public DelegateCommand IncrementCommand { get; set; }

        private void IncrementCommandOnExecute()
        {
            Counter++;
        }

        #endregion

        #region LoadCommand

        /// <summary>
        /// Loads the data from our dataset.
        /// </summary>
        public DelegateCommand LoadCommand { get; set; }

        private void LoadCommandOnExecute()
        {
            var data = _exampleDataService.Load();
            ExampleDataModel = data;
            SavedDataExists = data != null;
            if (data != null)
            {
                Counter = data.Value;
            }
        }

        #endregion

        #region SaveCommand

        /// <summary>
        /// Saves the data to our dataset.
        /// </summary>
        public DelegateCommand SaveCommand { get; set; }

        private void SaveCommandOnExecute()
        {
            _exampleDataService.Save(new ExampleDataModel
            {
                DateTime = DateTimeOffset.Now.ToString(),
                Value = Counter
            });
        }

        #endregion

        private readonly IExampleDataService _exampleDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exampleDataService">Data service for connecting to our data set.</param>
        public ShellViewModel(IExampleDataService exampleDataService)
        {
            _exampleDataService = exampleDataService;

            // Checkout WPF and PRISM DelegateCommands and Command patterns for this. It's basically
            // a set of functions you can bind to with buttons on the view.
            IncrementCommand = new DelegateCommand(IncrementCommandOnExecute);
            LoadCommand = new DelegateCommand(LoadCommandOnExecute);
            SaveCommand = new DelegateCommand(SaveCommandOnExecute);
        }
    }
}
