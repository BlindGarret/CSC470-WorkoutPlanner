using System;
using SQLite;

namespace WorkoutHelper.Models
{
    [Table("CompletionData")]
    public class CompletionData
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Hash")]
        public string Hash { get; set; }

        [Column("Time")]
        public TimeSpan Time { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }
    }
}
