using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Properties

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

        public DelegateCommand IncrementCommand { get; set; }

        private void IncrementCommandOnExecute()
        {
            Counter++;
        }

        #endregion

        #region LoadCommand

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

        public ShellViewModel(IExampleDataService exampleDataService)
        {
            _exampleDataService = exampleDataService;

            IncrementCommand = new DelegateCommand(IncrementCommandOnExecute);
            LoadCommand = new DelegateCommand(LoadCommandOnExecute);
            SaveCommand = new DelegateCommand(SaveCommandOnExecute);
        }
    }
}
