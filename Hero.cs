﻿using OOPFundamentalsFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Hero
    {
        #region Fields and Properties
        private string _name;
        public string Name { get { return _name; } }

        private int _baseStrength = 200;
        public int BaseStrength { get { return _baseStrength; } set { _baseStrength = value; } }

        private int _baseDefence = 500;
        public int BaseDefence { get { return _baseDefence; } set { _baseDefence = value; } }

        private int _originalHealth = 1000;
        public int OriginalHealth { get { return _originalHealth; } set { _originalHealth = value; } }

        private int _currentHealth = 1000;
        public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }

        private Weapon? _equippedWeapon;
        public Weapon? EquippedWeapon { get { return _equippedWeapon; } }

        private Armour? _equippedArmour;
        public Armour? EquippedArmour { get { return _equippedArmour; } }

        private Potion? _equippedPotion;
        public Potion? EquippedPotion { get { return _equippedPotion; } }
        #endregion;

        #region Methods
        private void _formatHeroName(string heroName)
        {
            heroName.ToCharArray();
            char firstLetter = char.ToUpper(heroName[0]);
            string restOfName = heroName.Substring(1);
            string formattedName = $"{firstLetter}{restOfName}";

            _name = formattedName;
        }
        private void _setUpHeroName(string heroName)
        {
            if(heroName.Length < 2)
            {
                throw new Exception("\nI apologize but legends say that your name was at least 2 characters long.");
            } else if (!heroName.All(c => char.IsLetterOrDigit(c)))
            {
                throw new Exception("\nI apologize but legends say that your name was said to only contain letters and/or numbers.");
            }

            _formatHeroName(heroName);
        }
        public void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{Name}'s Stats: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Base Strength = {BaseStrength}");
            Console.WriteLine($"Base Defence = {BaseDefence}");
            Console.WriteLine($"Original Health = {OriginalHealth}");
            Console.WriteLine($"Current Health = {CurrentHealth}");
            Game.GetGameStats();
        }
        public void GetInventory()
        {
            if (EquippedWeapon == null || EquippedArmour == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have no weapon and/or armour equipped.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Don't forget to prepare yourself for the battle ahead.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{Name}'s Inventory: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Weapon: {EquippedWeapon.Name} - {EquippedWeapon.Power} POWER");
                Console.WriteLine($"Armour: {EquippedArmour.Name} - {EquippedArmour.Power} POWER");
                Console.WriteLine($"Potion: {EquippedPotion.Name} - {EquippedPotion.Description}\n");
                Console.WriteLine("Feeling prepared? ");
            }
        }
        public void EquipWeapon(Weapon weaponChoice)
        {
            _equippedWeapon = weaponChoice;
        }
        public void EquipArmour(Armour armourChoice)
        {
            _equippedArmour = armourChoice;
        }
        public void EquipPotion(Potion potionChoice)
        {
            _equippedPotion = potionChoice;

            switch (potionChoice.Code)
            {
                case "1":
                    BaseDefence = BaseDefence + potionChoice.BoostValue;
                    break;
                case "2":
                    BaseStrength = BaseStrength + potionChoice.BoostValue;
                    break;
                case "3":
                    CurrentHealth = 1000;
                    break;
            }
        }
        #endregion

        #region Constructor
        public Hero(string heroName)
        {
            _setUpHeroName(heroName);
        }
        #endregion
    }
}
