using FitnessHL.BL.Controller;
using FitnessHL.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessHL.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var culture = CultureInfo.CreateSpecificCulture("ua-UA");
            //var resourceManager = new ResourceManager("FitnessHL.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine("You are welcomed by the applications - FitnessHL");

            Console.WriteLine("Enter your user name: ");
            string name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("birth date");
                var weight = ParseDouble("weight");
                var height = ParseDouble("growth");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What you want to do?");
                Console.WriteLine("E - enter a meal food");
                Console.WriteLine("A - enter a sport activity");
                Console.WriteLine("Q - exit");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\r{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exer = EnterExercise();
                        exerciseController.Add(exer.Activity, exer.Begin, exer.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\r{item.Activity} with {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }

        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("\nEnter name exercise: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("consumption energy per minute");
            var begin = ParseDateTime("start exercise");
            var end = ParseDateTime("finish exercise");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter your {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.Write($"Wrong {value} format!");
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
