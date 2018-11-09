using System.Configuration;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.Services
{
    public class ConfigurationDataService : IConfigurationDataService
    {
        public string DatabaseConnectionString { get; set; } =
            ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString;
    }
}
