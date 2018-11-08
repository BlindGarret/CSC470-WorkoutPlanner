using SQLite;

namespace WorkoutHelper.Models
{
    [Table("DisabledExercises")]
    public class DisabledExercise
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Column("UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Exercise Id
        /// </summary>
        [Column("ExerciseId")]
        public int ExerciseId { get; set; }
    }
}
