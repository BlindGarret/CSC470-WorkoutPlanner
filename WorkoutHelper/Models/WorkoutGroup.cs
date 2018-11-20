using System.Collections.Generic;
using SQLite;

namespace WorkoutHelper.Models
{
    [Table("WorkoutGroups")]
    public class WorkoutGroup
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DayId")]
        public int DayId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Ignore]
        public List<Workout> Workouts { get; set; }
    }
}
