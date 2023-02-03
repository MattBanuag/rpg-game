using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public static class Game
    {
        #region Methods
        public static void PlayIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to HavenBorne!");
        }
        public static Hero GetHeroName()
        {
            bool isValid = false;
            Hero newHero = null;
            while (!isValid)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Are you the promised hero they speak of? What do they call you? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string heroName = Console.ReadLine();
                    newHero = new Hero(heroName);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nI see.... Greetings {newHero.Name}!");
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }

            return newHero;
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("\nPrepare yourself for the fight ahead or explore around. Up to you.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1 - Stats");
            Console.WriteLine("2 - Inventory");
            Console.WriteLine("3 - Fight!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nSo what'll it be? ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string userChoice = Console.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if(userChoice == "1" || userChoice == "2" || userChoice == "3")
                {
                    isValid = true;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize, but this option does not exist.");
                    Console.ResetColor();
                    Console.Write("\nSo what'll it be? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userChoice = Console.ReadLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Stats Selected");
                    break;
                case "2":
                    Console.WriteLine("Inventory Selected");
                    break;
                case "3":
                    Console.WriteLine("Fight Selected");
                    break;
            }
        }
        public static void Start()
        {
            bool gameStart = true;
            PlayIntroduction();
            GetHeroName();
            ShowMainMenu();
        }
        #endregion
    }
}
