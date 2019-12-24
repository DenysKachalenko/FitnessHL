using FitnessHL.BL.Controller;
using System;

namespace FitnessHL.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are welcomed by the applications - FitnessHL");

            Console.WriteLine("Enter your username: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your gender: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine()); //TODO:

            Console.WriteLine("Enter your weight: ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your growth: ");
            double height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
