﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Services
{
    public class DataService : IDataService
    {
        private readonly IConfigurationDataService _config; 
        public DataService(IConfigurationDataService config)
        {
            _config = config;
        }


        /// <inheritdoc/>
        public ObservableUser GetSettings(int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                ObservableUser currentUser;
                currentUser.FirstName = connection.
                currentUser.LastName = connection.
                currentUser.Height = connection.
                currentUser.Weight = connection.
                currentUser.Avatar = connecton.
                return currentUser;
            }
        }

        /// <inheritdoc />
        public IEnumerable<Exercise> GetExercises(int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                //First we need to get all of the exercises from the Exercise Table.
                var exercises = connection.Table<Exercise>().ToList();

                //Now we use our user id to get a list of disabled exercises
                var disabledExercises = connection.Table<DisabledExercise>().Where(x => x.UserId == userId).ToList();

                //we're going to throw the disabled exercises into a Hashset just to make the data merge O(n) time.
                var lookupSet = new HashSet<int>(disabledExercises.Select(x => x.ExerciseId));
                foreach (var exercise in exercises)
                {
                    exercise.Enabled = !lookupSet.Contains(exercise.Id);
                }

                //Now we have a fully filled exercise set for returning.
                return exercises;
            }
        }

        /// <inheritdoc />
        public void DisableExercise(int exerciseId, int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                connection.Insert(new DisabledExercise() {ExerciseId = exerciseId, UserId = userId});
            }
        }

        /// <inheritdoc />
        public void EnableExercise(int exerciseId, int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                connection.Table<DisabledExercise>().Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                    .Delete();
            }
        }
    }
}
