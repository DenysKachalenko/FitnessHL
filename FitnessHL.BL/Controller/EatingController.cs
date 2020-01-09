using FitnessHL.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessHL.BL.Controller
{
    public class EatingController : ControllerBass
    {
        /// <summary>
        /// User.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// List food.
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// List a meal foods.
        /// </summary>
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Null or empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(product, weight);
            }
            Save();
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save<Food>(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
