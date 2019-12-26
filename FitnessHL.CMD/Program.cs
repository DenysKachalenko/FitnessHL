using FitnessHL.BL.Controller;
using FitnessHL.BL.Model;
using System;

namespace FitnessHL.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are welcomed by the applications - FitnessHL");

            Console.WriteLine("Enter your user name: ");
            string name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("growth");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What you want to do?");
            Console.WriteLine("E - enter a meal food");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\r{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("\nEnter name product: ");
            var food = Console.ReadLine();
            var weight = ParseDouble("the portion weight");
            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your birth date (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong birth date format!");
                }
            }

            return birthDate;
        }

        public static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format!");
                }             
            }
        }
    }
}
