using SQLite;

namespace WorkoutHelper.Models
{
    [Table("Workouts")]
    public class Workout
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

        [Column("RepetitionCount")]
        public int RepetitionCount { get; set; }

        [Column("ExerciseId")]
        public int ExerciseId { get; set; }

        [Ignore]
        public Exercise Exercise { get; set; }
    }
}
