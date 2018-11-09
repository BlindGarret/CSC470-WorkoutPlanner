using System.Collections.ObjectModel;

namespace WorkoutHelper.Models
{
    public class Plan
    {
        public string Weekday { get; set; }

        public ObservableCollection<PlannedGroup> Groups { get; set; }

        public bool Enabled { get; set; }
    }
}
