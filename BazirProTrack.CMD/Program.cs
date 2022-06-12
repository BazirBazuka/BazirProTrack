using System;
using BazirProTrack.BL.Controller;

namespace BazirProTrack.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the alpha version of the program " + "BazirProTrack");

            Console.Clear();



            Console.WriteLine("First of all let's get acquainted!\n\nEnter your name: " + " ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();

                DateTime birthDate = ParseDateTime("Birthdate");
                double weight = ParseDouble("Weight");
                double height = ParseDouble("Height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurentUser);

        }

        private static DateTime ParseDateTime(string name)
        {
            DateTime birthDate;
            while (true)
            {

                Console.WriteLine($"Enter youre {name}");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR! Wrong date format. ");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {

                Console.WriteLine($"Enter youre {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

                else
                {
                    Console.WriteLine($"ERROR! Wrong {name} format. ");
                }
            }
        }
    }
}
