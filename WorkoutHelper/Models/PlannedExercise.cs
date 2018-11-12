using System.Collections.Generic;

namespace WorkoutHelper.Models
{
    public class PlannedExercise
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public string MuscleGroup { get; set; }

        public int Difficulty { get; set; }

        public bool AllowFreeWeights { get; set; }

        public bool AllowMachines { get; set; }
    }
}
