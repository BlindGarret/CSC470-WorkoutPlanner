using System;
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
        /// Save a user.
        /// </summary>
        /// <param name="user">User to store in data set</param>
        void SaveUser(User user);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="user">User to delete from the data set</param>
        void DeleteUser(User user);

        /// <summary>
        /// Get today's date.
        /// </summary>
        /// <returns>DateTime</returns>
        DateTime GetDate();

        /// <summary>
        /// Get current user's current weight.
        /// </summary>
        /// <param name="userId">ID of the current user requesting their weight</param>
        /// <returns>Double</returns>
        double GetWeight(int userId);

        /// <summary>
        /// Save the user's weigh in information
        /// </summary>
        /// <param name="weighIn">ObservableWeighIn to be stored</param>
        /// <param name="userId">The Id of the user</param>
        void SaveWeighIn(WeighIn weighIn, int userId);

        /// <summary>
        /// Gets saved weigh ins.
        /// </summary>
        /// <param name="userId">The id of the user in question</param>
        /// <returns>a set of <see cref="WeighIn"/></returns>
        IEnumerable<WeighIn> GetWeighIns(int userId);

        /// <summary>
        /// Update's a user object's weight
        /// </summary>
        /// <param name="user">ID of the current user</param>
        /// <param name="newWeight">New weight to be stored</param>
        void SaveWeight(User user, double newWeight);


        /// <summary>
        /// Adds a User to the Data Set
        /// </summary>
        /// <param name="user">User to Add</param>
        /// <returns>ID of created user</returns>
        int AddUser(User user);

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

        /// <summary>
        /// Gets the current weekday plans for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user to query</param>
        /// <returns>a set of <see cref="PlannedWeekday"/></returns>
        IEnumerable<PlannedWeekday> GetPlans(int userId);

        /// <summary>
        /// Saves a set of plans for a given user.
        /// </summary>
        /// <param name="weekdays">A set of <see cref="PlannedWeekday"/>.</param>
        /// <param name="userId">The Id of the User.</param>
        void SavePlans(IEnumerable<PlannedWeekday> weekdays, int userId);

        /// <summary>
        /// Gets the planned workouts from the data set.
        /// </summary>
        /// <param name="userId">The Id of the user to get workouts for</param>
        /// <returns>a set of <see cref="WorkoutDay"/></returns>
        IEnumerable<WorkoutDay> GetWorkouts(int userId);

        /// <summary>
        /// Saves a set of planned workouts while invalidating previous workouts.
        /// </summary>
        /// <param name="days">Days planned</param>
        /// <param name="userId">Id of user</param>
        void SaveWorkouts(IEnumerable<WorkoutDay> days, int userId);

        /// <summary>
        /// Completes a workout
        /// </summary>
        /// <param name="day">The workout day to complete</param>
        /// <param name="userId">The user to complete it for</param>
        void CompleteWorkout(WorkoutDay day, int userId);

        /// <summary>
        /// Gets a set of completion data for a workout hash
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <param name="hash">hash of the workout</param>
        /// <returns>a set of <see cref="CompletionData"/></returns>
        IEnumerable<CompletionData> GetCompletionData(int userId, string hash);

        /// <summary>
        /// Saves an instance of completion data for a user.
        /// </summary>
        /// <param name="data">The completion data</param>
        /// <param name="userId">Id of the user to save the data for.</param>
        void SaveCompletionData(CompletionData data, int userId);
    }
}