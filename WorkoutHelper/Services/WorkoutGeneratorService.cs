using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutHelper.Extensions;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;

namespace WorkoutHelper.Services
{
    public class WorkoutGeneratorService : IWorkoutGenerator
    {
        public IEnumerable<WorkoutDay> GenerateWorkouts(List<DateTime> dates, List<Exercise> availableExercises, List<PlannedWeekday> plans)
        {
            var workoutDays = new List<WorkoutDay>();
            var planIndex = plans.ToDictionary(x => x.Name);
            foreach (var date in dates)
            {
                var weekdayLabel = date.DayOfWeek.ToString();
                if (!planIndex[weekdayLabel].Enabled)
                {
                    continue;
                }

                var day = new WorkoutDay { Date = date, Groups = new List<WorkoutGroup>(), Completed = false};
                foreach (var plannedGroup in planIndex[weekdayLabel].Groups)
                {
                    var exercises = new List<Workout>();
                    foreach (var exercise in plannedGroup.Exercises)
                    {
                        var possibleExercises = availableExercises.Where(x =>
                            (!x.NeedsFreeWeights || x.NeedsFreeWeights && exercise.AllowFreeWeights) &&
                            (!x.NeedsMachine || x.NeedsMachine && exercise.AllowMachines) && 
                            x.MuscleGroup == exercise.MuscleGroup).ToList();
                        if (!possibleExercises.Any())
                        {
                            continue;
                        }

                        var chosenExercise = possibleExercises.Random();
                        exercises.Add(new Workout { Exercise = chosenExercise, RepetitionCount = chosenExercise.BaseRepititions * exercise.Difficulty });
                    }
                    day.Groups.Add(new WorkoutGroup { Workouts = exercises });
                }

                workoutDays.Add(day);
            }

            return workoutDays;
        }

        public string GenerateWorkoutHash(WorkoutDay day)
        {
            //is this a perfectly unique solution? No, but it's certainly unique enough for our needs.
            var builder = new StringBuilder();
            foreach (var group in day.Groups)
            {
                foreach (var workout in group.Workouts)
                {
                    builder.Append(workout.Exercise.Name);
                    builder.Append(workout.RepetitionCount);
                }
            }

            return builder.ToString().GetHashCode().ToString();
        }
    }
}
