using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.Services
{
    public class ConfigurationDataService : IConfigurationDataService
    {
        public string DatabaseConnectionString { get; set; } =
            ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString;
    }
}
