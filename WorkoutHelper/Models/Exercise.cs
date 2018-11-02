using System.Collections.Generic;

namespace WorkoutHelper.Models
{
    public class Exercise
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int BaseRepititions { get; set; }

        public string MuscleGroup { get; set; }

        public bool NeedsFreeWeights { get; set; }

        public bool NeedsMachine { get; set; }
    }
}
