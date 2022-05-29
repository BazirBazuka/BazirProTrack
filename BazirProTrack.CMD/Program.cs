using System;
using BazirProTrack.BL.Controller;

namespace BazirProTrack.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the alpha version of the program " + "BazirProTrack");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();

            Console.WriteLine("Version a01h");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("All rights reserved");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("First of all let's get acquainted!\n\nEnter your name: " + " ");
            var name = Console.ReadLine();

            Console.WriteLine("\n\nEnter your gender: " + " ");
            var gender = Console.ReadLine();

            Console.WriteLine("\n\nEnter your birthday: " + " ");
            var birthDay = DateTime.Parse(Console.ReadLine());//TODO Try pars

            Console.WriteLine("\n\nEnter your weight: " + " ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("\n\nEnter your height: " + " ");
            var height = double.Parse(Console.ReadLine()); ;

            var userController = new UserController(name, gender, birthDay, weight, height);
            userController.Save();

        }
    }
}
