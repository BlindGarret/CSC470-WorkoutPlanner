using System;
using SQLite;

namespace WorkoutHelper.Models
{
    /// <summary>
    /// Data representation of a weigh in
    /// </summary>
    [Table("WeighIns")]
    public class WeighIn
    {
        /// <summary>
        /// Weigh in ID
        /// </summary>
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [Column("UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Weight value
        /// </summary>
        [Column("Value")]
        public double Value { get; set; }

        /// <summary>
        /// Date of the weigh in
        /// </summary>
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
