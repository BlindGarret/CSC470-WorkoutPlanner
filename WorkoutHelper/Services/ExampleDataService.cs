using System;
using System.Configuration;
using System.Linq;
using SQLite;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.Services
{
    public class ExampleDataService: IExampleDataService
    {
        //connecting should not be done here, nor is this code in anyway safe, it's just a quick example.
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString;

        public ExampleDataService()
        {
        }

        public ExampleDataModel Load()
        {
            // Using is a protection against memory leaks, if you aren't familiar with C# IDisposable it's worth looking up.
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Table<ExampleDataModel>().OrderBy(x => x.DateTime).LastOrDefault();
            }
        }

        public void Save(ExampleDataModel model)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }
    }
}
