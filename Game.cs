using OOPFundamentalsFinalProject;
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
        public static HashSet<Potion> Potions = new HashSet<Potion>();
        public static Fight NewFight = new Fight();
        public static Hero NewHero;
        public static Monster RandomMonster;
        private static Random _random = new Random();
        #endregion

        #region Methods
        public static void SpawnMonsters()
        {
            Monster Goblin = new Monster("Robin the Goblin", 100, 80, 20);
            Monster Orc = new Monster("Rourke the Orc", 200, 160, 40);
            Monster Gargoyle = new Monster("Droil the Gargoyle", 300, 240, 60);
            Monster Serpent = new Monster("Clement the Serpent", 400, 320, 80);
            Monster Dragon = new Monster("Sargon the Dragon", 2000, 500, 150);

            Monsters.Add(Goblin);
            Monsters.Add(Orc);
            Monsters.Add(Gargoyle);
            Monsters.Add(Serpent);
            Monsters.Add(Dragon);
        }
        public static int MonsterRandomizer()
        {
            int monsterSelector = _random.Next(Monsters.Count);
            return monsterSelector;
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
            Armour Steel = new Armour("4", "Steel Armour", 400);
            Armour Kevlar = new Armour("5", "Kevlar Armour", 600);

            Armours.Add(Leather);
            Armours.Add(ChainMail);
            Armours.Add(Copper);
            Armours.Add(Steel);
            Armours.Add(Kevlar);
        }
        public static void SpawnPotion()
        {
            Potion DefensePotion = new Potion("1", "Defense Booster", "Boosts base defence by 400.", 400);
            Potion StrengthPotion = new Potion("2", "Strength Booster", "Boosts base strength by 300.", 300);
            Potion RevivePotion = new Potion("3", "Revive", "Revives hero at full health", 1000);

            Potions.Add(DefensePotion);
            Potions.Add(StrengthPotion);
            Potions.Add(RevivePotion);
        }
        public static void RemoveMonster(Monster monster)
        {
            Monsters.Remove(monster);
        }
        public static void CheckHeroHealth()
        {
            bool hasHealth = true;
            while (hasHealth)
            {
                if(NewHero.CurrentHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nI apologize, but you have {NewHero.CurrentHealth}HP left.");
                    Console.WriteLine("I recommend healing up before going on adventures.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Head to \"Prepare\" and pick up some potions.");
                    ShowMainMenu();
                    hasHealth = false;
                } else
                {
                    SetFightScene();
                }
            }
        }
        public static void GetGameStats()
        {
            Console.WriteLine($"Games Played = {NewFight.GamesPlayed}");
            Console.WriteLine($"Wins = {NewFight.Win}");
            Console.WriteLine($"Losses = {NewFight.Lose}\n");
        }
        public static void GetHeroWeapon()
        {
            Weapon heroWeapon = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n~ What is your Weapon of choice? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string weaponChoice = Console.ReadLine();

                foreach (Weapon w in Weapons)
                {
                    if (w.Code == weaponChoice)
                    {
                        heroWeapon = w;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nAh.... the {heroWeapon.Name}. A mighty fine choice.");
                        NewHero.EquipWeapon(heroWeapon);
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize, but we do not have this kind of weapon.");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
            }
        }
        public static void GetHeroArmour()
        {
            Armour heroArmour = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n~ What is your Armour of choice? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string armourChoice = Console.ReadLine();

                foreach (Armour a in Armours)
                {
                    if (a.Code == armourChoice)
                    {
                        heroArmour = a;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nOoooohhhhh.... {heroArmour.Name}. Another mighty fine choice.");
                        NewHero.EquipArmour(heroArmour);
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize, but we do not have this kind of armour.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static void GetHeroPotion()
        {
            Potion heroPotion = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n~ What is your Potion of choice? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string potionChoice = Console.ReadLine();

                foreach (Potion p in Potions)
                {
                    if (p.Code == potionChoice)
                    {
                        heroPotion = p;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nGreat choice.... {heroPotion.Name}. This will be of great use.");
                        NewHero.EquipPotion(heroPotion);
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize, but we do not have this kind of potion.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static void SetFightScene()
        {
            if (Monsters.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nALL MONSTERS HAVE BEEN SLAYED!!! THANK YOU {NewHero.Name}, YOU HAVE SAVED HAVENBORNE!!!");
                Console.WriteLine($"THE END.....");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }

            if (NewHero.EquippedWeapon == null || NewHero.EquippedArmour == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Woah! Hold your horses valiant hero. You have no weapon or armour in hand.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDon't forget to prepare yourself for the battle ahead.");
                ShowMainMenu();
            } else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nI wish you the best of luck {NewHero.Name}...");
                Console.WriteLine($"May you strike down your foe mightily and true.");

                int index = MonsterRandomizer();
                RandomMonster = Monsters.ElementAt(index);

                Console.WriteLine("\n\"WALKING THROUGH THE DARK FOREST OF HAVENBORNE........\"");
                Console.WriteLine($"\"{RandomMonster.Name} APPEARS!\"");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n{RandomMonster.Name}'s Stats");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Health = {RandomMonster.OriginalHealth}");
                Console.WriteLine($"Strength = {RandomMonster.Strength}");
                Console.WriteLine($"Defense = {RandomMonster.Defense}");
                
                Console.WriteLine("\nOptions: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 - Slay the Beast");
                Console.WriteLine("2 - Escape");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n~ What shall you do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string userChoice = Console.ReadLine();

                bool isValid = false;
                while (!isValid)
                {
                    if (userChoice == "1" || userChoice == "2")
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"This option is not available. {RandomMonster.Name} smells your hesitation...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"\n~ What shall you do? ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        userChoice = Console.ReadLine();
                    }
                }

                switch (userChoice)
                {
                    case "1":
                        FightMonster();
                        break;
                    case "2":
                        index = MonsterRandomizer();
                        RandomMonster = Monsters.ElementAt(index);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\"YOU BARELY ESCAPED....\"");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nAhhh... So you have returned. Welcome back {NewHero.Name}");    
                        ShowMainMenu();
                        break;
                }

            }
        }
        public static void FightMonster()
        {
            bool heroTurn = _random.Next(2) == 1;
            NewFight.StartFight(heroTurn, NewHero, RandomMonster);
        }
        public static void DisplayAvailableItems()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSmart choice. Preparation is a must!");
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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAvailable potions: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Potion p in Potions)
            {
                Console.WriteLine($"{p.Code} - {p.Name} : {p.Description}");
            }

            GetHeroWeapon();
            GetHeroArmour();
            GetHeroPotion();
            Console.WriteLine("\nFeeling prepared? ");
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
            NewHero = null;
            while (!isValid)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Are you the promised hero they speak of? What do they call you? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string heroName = Console.ReadLine();
                    NewHero = new Hero(heroName);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nI see.... Greetings {NewHero.Name}!");
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }

            return NewHero;
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("Adventure awaits!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Stats");
            Console.WriteLine("2 - Prepare");
            Console.WriteLine("3 - Inventory");
            Console.WriteLine("4 - Fight!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n~ What would you like to do? ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string userChoice = Console.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if(userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4")
                {
                    isValid = true;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I apologize, but this option does not exist.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n~ What would you like to do? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userChoice = Console.ReadLine();
                }
            }

            switch (userChoice)
            {
                case "1":
                    NewHero.GetStats();
                    ShowMainMenu();
                    break;
                case "2":
                    DisplayAvailableItems();
                    break;
                case "3":
                    NewHero.GetInventory();
                    ShowMainMenu();
                    break;
                case "4":
                    CheckHeroHealth();
                    break;
            }
        }
        public static void Start()
        {
            bool gameStart = true;
            SpawnMonsters();
            SpawnWeapons();
            SpawnArmour();
            SpawnPotion();
            PlayIntroduction();
            GetHeroName();
            ShowMainMenu();

        }
        #endregion
    }
}
