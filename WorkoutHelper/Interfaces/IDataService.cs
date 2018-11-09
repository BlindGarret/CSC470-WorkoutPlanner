using System.Collections.Generic;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

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
        /// Get user by ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User object</returns>
        User GetUser(int userId);

        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns>User object</returns>
        IEnumerable<User> GetUsers();

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