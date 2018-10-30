using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Models
{
    public class PlannedGroup
    {
        public int Order { get; set; }

        public ObservableCollection<PlannedExercise> Exercises { get; set; }

    }
}
