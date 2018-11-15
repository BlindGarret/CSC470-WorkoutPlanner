using System.Collections.Generic;
using System.Linq;
using SQLite;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

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
        public void SaveUser(User user)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                connection.Update(user);
            }
        }

        /// <inheritdoc/>
        public User GetUser(int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                var user = connection.Table<User>().FirstOrDefault(x => x.Id == userId);
                return user;
            }
        }

        /// <inheritdoc/>
        public int AddUser(User user)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                var lastId = connection.Table<User>().OrderBy(x => x.Id).LastOrDefault();
                user.Id = lastId?.Id + 1 ?? 1;
                connection.Insert(user);
                return user.Id;
            }
        }

        /// <inheritdoc />
        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                return connection.Table<User>().ToList();
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
                connection.Insert(new DisabledExercise() { ExerciseId = exerciseId, UserId = userId });
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

        public IEnumerable<PlannedWeekday> GetPlans(int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                var weekdays = new[]
                {
                    new PlannedWeekday() { Name = "Sunday"},
                    new PlannedWeekday() { Name = "Monday"},
                    new PlannedWeekday() { Name = "Tuesday"},
                    new PlannedWeekday() { Name = "Wednesday"},
                    new PlannedWeekday() { Name = "Thursday"},
                    new PlannedWeekday() { Name = "Friday"},
                    new PlannedWeekday() { Name = "Saturday"},
                };
                var groups = connection.Table<PlannedGroup>().Where(x => x.UserId == userId).ToList();
                var exercises = connection.Table<PlannedExercise>().Where(x => x.UserId == userId).ToList();
                var disabledDays = connection.Table<DisabledWeekday>().Where(x => x.UserId == userId).ToList();

                foreach (var plannedGroup in groups)
                {
                    plannedGroup.Exercises = new List<PlannedExercise>(exercises.Where(x => x.GroupId == plannedGroup.Id));
                }

                foreach (var plannedWeekday in weekdays)
                {
                    plannedWeekday.Groups =
                        new List<PlannedGroup>(groups.Where(x => x.DayOfWeek == plannedWeekday.Name)
                            .OrderBy(x => x.Order));
                    plannedWeekday.Enabled = disabledDays.All(x => x.Day != plannedWeekday.Name);
                }

                return weekdays;
            }
        }

        public void SavePlans(IEnumerable<PlannedWeekday> weekdays, int userId)
        {
            using (var connection = new SQLiteConnection(_config.DatabaseConnectionString))
            {
                //clear previous disabled flags as we're not tracking for updates:
                connection.Table<DisabledExercise>().Where(x => x.UserId == userId).Delete();

                foreach (var plannedWeekday in weekdays)
                {

                    if (!plannedWeekday.Enabled)
                    {
                        connection.Insert(new DisabledWeekday
                        {
                            Day = plannedWeekday.Name,
                            UserId = userId
                        });
                    }

                    foreach (var plannedWeekdayGroup in plannedWeekday.Groups)
                    {
                        plannedWeekdayGroup.DayOfWeek = plannedWeekday.Name;
                        plannedWeekdayGroup.UserId = userId;
                        if (plannedWeekdayGroup.Id < 1)
                        {
                            //0 is our tell for new objects
                            connection.Insert(plannedWeekdayGroup);
                        }
                        else
                        {
                            connection.Update(plannedWeekdayGroup);
                        }


                        foreach (var plannedExercise in plannedWeekdayGroup.Exercises)
                        {
                            plannedExercise.GroupId = plannedWeekdayGroup.Id;
                            plannedExercise.UserId = userId;
                            if (plannedExercise.Id < 1)
                            {
                                //0 is our tell for new objects
                                connection.Insert(plannedExercise);
                                continue;
                            }

                            connection.Update(plannedExercise);
                        }

                    }
                }
            }
        }
    }
}
