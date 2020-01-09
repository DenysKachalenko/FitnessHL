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
        public int Id { get; set; }
        /// <summary>
        /// Meal time.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// List taken food.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// User who ate.
        /// </summary>
        public virtual User User { get; set; }

        public Eating() { }
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
