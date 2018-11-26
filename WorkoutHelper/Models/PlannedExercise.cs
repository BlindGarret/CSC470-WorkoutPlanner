using SQLite;

namespace WorkoutHelper.Models
{
    [Table("PlannedExercises")]
    public class PlannedExercise
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

        [Column("MuscleGroup")]
        public string MuscleGroup { get; set; }

        [Column("Difficulty")]
        public int Difficulty { get; set; } = 1;

        [Column("AllowFreeWeights")]
        public bool AllowFreeWeights { get; set; }

        [Column("AllowMachines")]
        public bool AllowMachines { get; set; }
    }
}
