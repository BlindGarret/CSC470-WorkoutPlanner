using SQLite;

namespace WorkoutHelper.Models
{
    [Table("DisabledWeekdays")]
    public class DisabledWeekday
    {
        [Column("Id")]
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Day")]
        public string Day { get; set; }
    }
}
