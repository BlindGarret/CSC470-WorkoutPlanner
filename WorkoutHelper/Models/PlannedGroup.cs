using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WorkoutHelper.Models
{
    public class PlannedGroup
    {
        public int Id { get; set; }

        public string DayOfWeek { get; set; }

        public int Order { get; set; }

        public List<PlannedExercise> Exercises { get; set; }

    }
}
