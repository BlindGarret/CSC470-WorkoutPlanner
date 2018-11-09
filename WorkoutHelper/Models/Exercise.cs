using SQLite;

namespace WorkoutHelper.Models
{
    /// <summary>
    /// Data representation of an exercise.
    /// </summary>
    [Table("Exercises")]
    public class Exercise
    {
        /// <summary>
        /// Exercise Id
        /// </summary>
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the exercise
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of how to do the exercise
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Path to the descriptive image of the exercise
        /// </summary>
        [Column("ImagePath")]
        public string ImagePath { get; set; }

        /// <summary>
        /// The base repitition value for the given exercise.
        /// </summary>
        [Column("BaseRepititions")]
        public int BaseRepititions { get; set; }

        /// <summary>
        /// The musclegroup that the exercise belongs to.
        /// </summary>
        [Column("MuscleGroup")]
        public string MuscleGroup { get; set; }

        /// <summary>
        /// Flag for whether the exercise requires free weights.
        /// </summary>
        [Column("NeedsFreeWeights")]
        public bool NeedsFreeWeights { get; set; }

        /// <summary>
        /// Flag for whether the exercise requires a gym machine.
        /// </summary>
        [Column("NeedsMachine")]
        public bool NeedsMachine { get; set; }

        public bool Enabled { get; set; }
    }
}
