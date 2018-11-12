using System.Collections.Generic;
using SQLite;

namespace WorkoutHelper.Models
{
    [Table("PlannedGroups")]
    public class PlannedGroup
    {
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("DayOfWeek")]
        public string DayOfWeek { get; set; }

        [Column("Order")]
        public int Order { get; set; }

        [Ignore]
        public List<PlannedExercise> Exercises { get; set; }
    }
}
