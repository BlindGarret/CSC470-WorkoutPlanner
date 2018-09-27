using System;
using SQLite;

namespace WorkoutHelper.Models
{
    [Table("values")]
    public class ExampleDataModel
    {
        [Column("value")]
        public int Value { get; set; }

        //sqlite is VERY limited in typing. We're going to have to work around this
        [Column("date_time")]
        public string DateTime { get; set; }
    }
}
