using System.Collections.Generic;
using WorkoutHelper.Models;

namespace WorkoutHelper.Interfaces
{
    /// <summary>
    /// Data access service interface.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Get exercise list.
        /// </summary>
        /// <param name="userId">ID of the user requesting the exercise list</param>
        /// <returns>Collection of <see cref="Exercise"/></returns>
        IEnumerable<Exercise> GetExercises(int userId);

        /// <summary>
        /// Disables a given exercise for a given user.
        /// </summary>
        /// <param name="exerciseId">The ID of the exercise</param>
        /// <param name="userId">The ID of the User.</param>
        void DisableExercise(int exerciseId, int userId);

        /// <summary>
        /// Enables a given exercise for a given user.
        /// </summary>
        /// <param name="exerciseId">The ID of the exercise</param>
        /// <param name="userId">The ID of the User.</param>
        void EnableExercise(int exerciseId, int userId);
    }
}