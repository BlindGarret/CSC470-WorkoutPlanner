using System;
using System.Collections.Generic;
using WorkoutHelper.Models;

namespace WorkoutHelper.Interfaces
{
    public interface IWorkoutGenerator
    {
        IEnumerable<WorkoutDay> GenerateWorkouts(List<DateTime> dates, List<Exercise> availableExercises, List<PlannedWeekday> plans);

        string GenerateWorkoutHash(WorkoutDay day);
    }
}
