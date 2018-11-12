using System.Collections.Generic;

namespace WorkoutHelper.Models
{
    public class PlannedExercise
    {
        public string MuscleGroup { get; set; }

        public int Difficulty { get; set; }

        public IReadOnlyList<EquipmentCategory> EquipmentCategory { get; set; }
    }
}
