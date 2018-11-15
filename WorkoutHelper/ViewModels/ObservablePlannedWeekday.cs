using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservablePlannedWeekday : BindableBase
    {
        #region Properties
        
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        private string _name;

        public ObservableCollection<ObservablePlannedGroup> Groups
        {
            get => _groups;
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    RaisePropertyChanged(nameof(Groups));
                }
            }
        }

        private ObservableCollection<ObservablePlannedGroup> _groups;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    RaisePropertyChanged(nameof(Enabled));
                }
            }
        }

        private bool _enabled;

        #endregion

        public ObservablePlannedWeekday(PlannedWeekday weekday)
        {
            Name = weekday.Name;
            Groups = new ObservableCollection<ObservablePlannedGroup>(weekday.Groups.Select(x => new ObservablePlannedGroup(x)));
            Enabled = weekday.Enabled;
        }

        public PlannedWeekday ToModel()
        {
            return new PlannedWeekday
            {
                Name = Name,
                Groups = Groups.Select(x => x.ToModel()).ToList(),
                Enabled = Enabled
            };
        }
    }
}
