using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Models
{
    public class Plan
    {
        public string Weekday { get; set; }

        public ObservableCollection<PlannedGroup> Groups { get; set; }

        public bool Enabled { get; set; }
    }
}
