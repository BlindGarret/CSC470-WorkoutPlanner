namespace WorkoutHelper.Interfaces
{
    /// <summary>
    /// Service for keeping track of Session information.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Current ID for logged in user.
        /// </summary>
        int UserId { get; set; }
    }
}
