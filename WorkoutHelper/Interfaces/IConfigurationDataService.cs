using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Interfaces
{
    public interface IConfigurationDataService
    {
        string DatabaseConnectionString { get; set; }
    }
}
