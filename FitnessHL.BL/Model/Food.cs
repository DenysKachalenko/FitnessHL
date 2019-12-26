using System;

namespace FitnessHL.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories for 100 gram product.
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this (name, 0, 0, 0, 0){}

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Null or empty!", nameof(name));
            }
            if (calories < 0)
            {
                throw new ArgumentNullException("Calories cannot be negative!", nameof(calories));
            }
            if (proteins < 0)
            {
                throw new ArgumentNullException("Proteins cannot be negative!", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentNullException("Fats cannot be negative!", nameof(fats));
            }
            if (carbohydrates < 0)
            {
                throw new ArgumentNullException("Carbohydrates cannot be negative!", nameof(carbohydrates));
            }

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
