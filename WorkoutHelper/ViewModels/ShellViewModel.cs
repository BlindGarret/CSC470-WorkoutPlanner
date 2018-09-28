using System;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

//This is the Viewmodel for the main shell page. It acts as the binding layer between most models, services, and the view.
// Review MVVM and WPF to read more about how it functions, but it's fairly straight forward.

namespace WorkoutHelper.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// Visible counter for Shell Page
        /// </summary>
        public int Counter
        {
            get => _counter;
            set
            {
                if (_counter != value)
                {
                    _counter = value;
                    RaisePropertyChanged(nameof(Counter));
                }
            }
        }

        private int _counter;

        /// <summary>
        /// The Example Data Model from our Dataset
        /// </summary>
        public ExampleDataModel ExampleDataModel
        {
            get => _exampleDataModel;
            set
            {
                if (_exampleDataModel != value)
                {
                    _exampleDataModel = value;
                    RaisePropertyChanged(nameof(ExampleDataModel));
                }
            }
        }

        private ExampleDataModel _exampleDataModel;

        /// <summary>
        /// Does the Saved Data from the Dataset Exist?
        /// </summary>
        public bool SavedDataExists
        {
            get => _savedDataExists;
            set
            {
                if (_savedDataExists != value)
                {
                    _savedDataExists = value;
                    RaisePropertyChanged(nameof(SavedDataExists));
                }
            }
        }

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
