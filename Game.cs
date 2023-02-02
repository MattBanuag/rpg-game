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

            int userChoice = 0;
            bool isValid = int.TryParse(Console.ReadLine(), out userChoice);

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("I apologize, but this option does not exist.");
                Console.ResetColor();
                Console.WriteLine("\nSo what'll it be? ");
                userChoice = 0;
                isValid = int.TryParse(Console.ReadLine(), out userChoice);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nOption selected was successful.");
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
