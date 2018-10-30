using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Models
{
    public class PlannedExercise
    {
        public string MuscleGroup { get; set; }

        public int Difficulty { get; set; }

        public IReadOnlyList<EquipmentCategory> EquipmentCategory { get; set; }
    }
}
