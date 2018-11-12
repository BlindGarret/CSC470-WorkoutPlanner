using System;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservableWeighIn : BindableBase
    {
        #region Properties

        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    RaisePropertyChanged(nameof(Value));
                }
            }
        }

        private double _value;

        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    RaisePropertyChanged(nameof(Date));
                }
            }
        }

        private DateTime _date;

        #endregion

        public ObservableWeighIn(WeighIn model)
        {
            Value = model.Value;
            Date = model.Date;
        }

        public WeighIn ToModel()
        {
            return new WeighIn
            {
                Value = Value,
                Date = Date
            };
        }
    }
}
