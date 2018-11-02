using System;
using System.Collections.Generic;

namespace WorkoutHelper.Models
{
    public class WorkoutDay
    {
        public DateTimeOffset Date { get; set; }
        
        public IReadOnlyList<WorkoutGroup> Groups { get; set; }
    }
}
