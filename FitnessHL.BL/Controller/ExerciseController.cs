using FitnessHL.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessHL.BL.Controller
{
    [Serializable]
    [System.Runtime.InteropServices.Guid("5B3B25D0-B53E-48C1-9F0F-667C1E70B56D")]
    public class ExerciseController : ControllerBass
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a  => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Exercise> GetAllExercises() => Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        private List<Activity> GetAllActivities() => Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        private void Save() { Save(EXERCISES_FILE_NAME, Exercises); Save(ACTIVITIES_FILE_NAME, Activities); }

    }
}
