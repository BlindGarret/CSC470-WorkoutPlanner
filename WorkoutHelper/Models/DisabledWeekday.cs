using SQLite;

namespace WorkoutHelper.Models
{
    [Table("DisableWeekday")]
    public class DisabledWeekday
    {
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Day")]
        public string Day { get; set; }
    }
}
