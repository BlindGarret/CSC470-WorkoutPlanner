using System;
using System.Collections.Generic;
using SQLite;

namespace WorkoutHelper.Models
{
    [Table("WorkoutDays")]
    public class WorkoutDay
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Ignore]
        public List<WorkoutGroup> Groups { get; set; }
    }
}
