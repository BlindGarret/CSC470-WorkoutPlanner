using System.Collections.ObjectModel;

namespace WorkoutHelper.Models
{
    public class PlannedGroup
    {
        public int Order { get; set; }

        public ObservableCollection<PlannedExercise> Exercises { get; set; }

    }
}
