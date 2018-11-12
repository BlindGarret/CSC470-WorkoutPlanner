using SQLite;

// A serializable Data model. Anything we intend to put into the database should be setup like this.
// note the Table and column names attributes applied to the properties.

namespace WorkoutHelper.Models
{
    /// <summary>
    /// Example Data Model for Serialization.
    /// </summary>
    [Table("values")]
    public class ExampleDataModel
    {
        /// <summary>
        /// The value to store.
        /// </summary>
        [Column("value")]
        public int Value { get; set; }


        /// <summary>
        /// The Time we are saving this data.
        /// </summary>
        [Column("date_time")]
        public string DateTime { get; set; } //SQLite is VERY limited in typing. We're going to have to work around this
    }
}
