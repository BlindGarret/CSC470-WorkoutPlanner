using System.Configuration;
using System.Linq;
using SQLite;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

// Here is an example of a service. These can be as simple as tiny layers between IO and the project, to as complicated
// as giant eventing systems. They always exist behind an interface. Often called Managers, and often (in other languages) setup
// as static singletons.

namespace WorkoutHelper.Services
{
    /// <summary>
    /// SQLite implementation of data service.
    /// </summary>
    public class ExampleDataService: IExampleDataService
    {
        //connecting should not be done here, nor is this code in anyway safe, it's just a quick example.
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString;

        /// <inheritdoc />
        public ExampleDataModel Load()
        {
            // Using is a protection against memory leaks, if you aren't familiar with C# IDisposable it's worth looking up.
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Table<ExampleDataModel>().OrderBy(x => x.DateTime).LastOrDefault();
            }
        }

        /// <inheritdoc />
        public void Save(ExampleDataModel model)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }
    }
}
