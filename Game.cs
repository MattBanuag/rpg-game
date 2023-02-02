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
                    Console.Write("Are you the promised hero they speak of? What do they call you? ");
                    string heroName = Console.ReadLine();
                    newHero = new Hero(heroName);

                    Console.WriteLine($"\nI see.... Greetings {heroName}!");
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
        public static void Start()
        {
            bool gameStart = true;
            PlayIntroduction();
            GetHeroName();
        }
        #endregion
    }
}
