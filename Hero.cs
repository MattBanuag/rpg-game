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

        private int _baseStrength = 30;
        public int BaseStrength { get { return _baseStrength; } }

        private int _baseDefence = 30;
        public int BaseDefence { get { return _baseDefence; } }

        private int _originalHealth = 300;
        public int OriginalHealth { get { return _originalHealth; } set { _originalHealth = value; } }

        private int _currentHealth = 300;
        public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }

        private Weapon? _equippedWeapon;
        public Weapon? EquippedWeapon { get { return _equippedWeapon; } }

        private Armour? _equippedArmour;
        public Armour? EquippedArmour { get { return _equippedArmour; } }
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
                Console.WriteLine($"Armour: {EquippedArmour.Name} - {EquippedArmour.Power} POWER\n");
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
        #endregion

        #region Constructor
        public Hero(string heroName)
        {
            _setUpHeroName(heroName);
        }
        #endregion
    }
}
