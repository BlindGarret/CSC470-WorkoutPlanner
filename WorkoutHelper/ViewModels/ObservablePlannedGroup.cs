using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservablePlannedGroup : BindableBase
    {
        #region Properties

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        private int _id;

        public string DayOfWeek
        {
            get => _dayOfWeek;
            set
            {
                if (_dayOfWeek != value)
                {
                    _dayOfWeek = value;
                    RaisePropertyChanged(nameof(DayOfWeek));
                }
            }
        }

        private string _dayOfWeek;

        public int Order
        {
            get => _order;
            set
            {
                if (_order != value)
                {
                    _order = value;
                    RaisePropertyChanged(nameof(Order));
                }
            }
        }

        private int _order;

        public ObservableCollection<ObservablePlannedExercise> Exercises
        {
            get => _exercise;
            set
            {
                if (_exercise != value)
                {
                    _exercise = value;
                    RaisePropertyChanged(nameof(Exercise));
                }
            }
        }

        private ObservableCollection<ObservablePlannedExercise> _exercise;

        #endregion

        public ObservablePlannedGroup(PlannedGroup group)
        {
            Id = group.Id;
            DayOfWeek = group.DayOfWeek;
            Order = group.Order;
            Exercises = new ObservableCollection<ObservablePlannedExercise>(group.Exercises.Select(x => new ObservablePlannedExercise(x)));
        }

        public PlannedGroup ToModel()
        {
            return new PlannedGroup
            {
                Id = Id,
                DayOfWeek = DayOfWeek,
                Order = Order,
                Exercises = Exercises.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
