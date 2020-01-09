using System;

namespace FitnessHL.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories for 100 gram product.
        /// </summary>
        public double Calories { get; set; }

        public Food() { }

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
