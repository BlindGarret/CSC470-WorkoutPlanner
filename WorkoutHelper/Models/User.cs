using SQLite;

namespace WorkoutHelper.Models
{
    /// <summary>
    /// Data representation of a user
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// Exercise Id
        /// </summary>
        [Column("Id")]
        public int UserId { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [Column("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        [Column("LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// User's height
        /// </summary>
        [Column("Height")]
        public int Height { get; set; }

        /// <summary>
        /// User's weight
        /// </summary>
        [Column("Weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Path to the user's avatar
        /// </summary>
        [Column("Avatar")]
        public string Avatar { get; set; }
    }
}
