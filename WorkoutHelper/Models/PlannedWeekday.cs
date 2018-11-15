using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Models
{
    public class PlannedWeekday
    {
        public string Name { get; set; }

        public List<PlannedGroup> Groups { get; set; } = new List<PlannedGroup>();

        public bool Enabled { get; set; }
    }
}
