using FitnessHL.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessHL.BL.Controller
{
    public class EatingController : ControllerBass
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
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
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }                   
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
