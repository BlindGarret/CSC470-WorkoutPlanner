using System.Collections.Generic;

namespace WorkoutHelper.Models
{
    public class WorkoutGroup
    {
        public string RepititionType { get; set; }

        public IReadOnlyList<Workout> Workouts { get; set; }
    }
}
