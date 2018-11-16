﻿using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class WeighInViewModel : BindableBase, ITabViewComponent
    {
        #region Properties

        public string PageName { get; set; } = "Weigh In";

        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                if (_currentDate != value)
                {
                    _currentDate = value;
                    RaisePropertyChanged(nameof(CurrentDate));
                }
            }
        }

        private string _currentDate;

        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    RaisePropertyChanged(nameof(Weight));
                }
            }
        }

        private double _weight;

        #endregion

        #region SaveCommand

        public DelegateCommand SaveCommand { get; set; }

        private void SaveCommandOnExecute()
        {
            _dataService.SaveWeight(_sessionService.UserId, Weight);
            _dataService.SaveWeighIn(_sessionService.UserId, new ObservableWeighIn(new WeighIn() { Date = _dataService.GetDate(), Value = Weight }));
        }

        #endregion

        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;

        public WeighInViewModel(IDataService dataService, ISessionService sessionService)
        {
            _dataService = dataService;
            _sessionService = sessionService;

            SaveCommand = new DelegateCommand(SaveCommandOnExecute);
        }

        public void TabLoaded()
        {
            _weight =_dataService.GetWeight(_sessionService.UserId);
            _currentDate = _dataService.GetDate().ToLongDateString();
        }
    }
}
