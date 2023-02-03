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
        #region Data Collections
        public static HashSet<Monster> Monsters = new HashSet<Monster>();   
        public static HashSet<Weapon> Weapons = new HashSet<Weapon>();  
        public static HashSet<Armour> Armours = new HashSet<Armour>();
        #endregion

        #region Methods
        public static void SpawnMonsters()
        {
            Monster Goblin = new Monster("Robin the Goblin", 100, 80, 200);
            Monster Orc = new Monster("Rourke the Orc", 200, 160, 400);
            Monster Gargoyle = new Monster("Droil the Gargoyle", 300, 240, 600);
            Monster Serpent = new Monster("Clement the Serpent", 400, 320, 800);
            Monster Dragon = new Monster("Sargon the Dragon", 2000, 500, 1500);

            Monsters.Add(Goblin);
            Monsters.Add(Orc);
            Monsters.Add(Gargoyle);
            Monsters.Add(Serpent);
            Monsters.Add(Dragon);
        }
        public static void SpawnWeapons()
        {
            Weapon Sword = new Weapon("1", "Sword", 50);
            Weapon Spear = new Weapon("2", "Spear", 150);
            Weapon BattleAxe = new Weapon("3", "BattleAxe", 250);
            Weapon Mace = new Weapon("4", "Mace", 350);
            Weapon BoneCrusher = new Weapon("5", "BoneCrusher", 500);

            Weapons.Add(Sword);
            Weapons.Add(Spear);
            Weapons.Add(BattleAxe);
            Weapons.Add(Mace);
            Weapons.Add(BoneCrusher);
        }
        public static void SpawnArmour()
        {
            Armour Leather = new Armour("1", "Leather Armour", 100);
            Armour ChainMail = new Armour("2", "ChainMail Armour", 200);
            Armour Copper = new Armour("3", "Copper Armour", 300);
            Armour Steel = new Armour("4", "Steel", 400);
            Armour Kevlar = new Armour("5", "Kevlar", 600);

            Armours.Add(Leather);
            Armours.Add(ChainMail);
            Armours.Add(Copper);
            Armours.Add(Steel);
            Armours.Add(Kevlar);
        }
        public static Weapon GetHeroWeapon()
        {
            Weapon heroWeapon = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nWhat is your weapon of choice? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string weaponChoice = Console.ReadLine();

                foreach (Weapon w in Weapons)
                {
                    if (w.Code == weaponChoice)
                    {
                        heroWeapon = w;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nAh.... the {heroWeapon.Name}. A mighty fine choice.");
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize but we do not have this kind of weapon.");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
            }

            return heroWeapon;
        }
        public static Armour GetHeroArmour()
        {
            Armour heroArmour = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nWhat is your Armour of choice? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string armourChoice = Console.ReadLine();

                foreach (Armour a in Armours)
                {
                    if (a.Code == armourChoice)
                    {
                        heroArmour = a;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nAh.... {heroArmour.Name}. Another mighty fine choice.");
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize but we do not have this kind of armour.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return heroArmour;
        }
        public static void DisplayAvailableInventory()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nInventory? Smart choice. Preparation is a must!");
            Console.WriteLine("\nAvailable weapons: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Weapon w in Weapons)
            {
                Console.WriteLine($"{w.Code} - {w.Name} : {w.Power} Power");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAvailable armour: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Armour a in Armours)
            {
                Console.WriteLine($"{a.Code} - {a.Name} : {a.Power} Power");
            }

            GetHeroWeapon();
            GetHeroArmour();
            ShowMainMenu();
        }
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
            Console.WriteLine("\nPrepare yourself for the fight ahead or explore around. It's up to you.");
            Console.WriteLine("Select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nSo what'll it be? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userChoice = Console.ReadLine();
                }
            }

            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Stats Selected");
                    break;
                case "2":
                    DisplayAvailableInventory();
                    break;
                case "3":
                    Console.WriteLine("Fight Selected");
                    break;
            }
        }
        public static void Start()
        {
            bool gameStart = true;
            SpawnMonsters();
            SpawnWeapons();
            SpawnArmour();
            PlayIntroduction();
            GetHeroName();
            ShowMainMenu();

        }
        #endregion
    }
}
