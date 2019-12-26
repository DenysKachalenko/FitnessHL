using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessHL.BL.Model
{
    [Serializable]
    /// <summary>
    /// Eating food.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Meal time.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// List taken food.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// User who ate.
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Null or empty!", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
