using System;

namespace FitnessHL.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name{ get; }
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Null or empty", nameof(name));
            }
            if (caloriesPerMinute < 0)
            {
                throw new ArgumentException("Calories per minute can not be less than zero", nameof(caloriesPerMinute));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
