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

        private int _baseStrength;
        private int _baseDefence;
        private int originalHealth;
        private int _currentHealth;
        private Weapon _equippedWeapon;
        private Armour _equippedArmour;
        #endregion;

        #region Methods
        private void _formatHeroName(string heroName)
        {
            heroName.ToCharArray();
            char firstLetter = heroName[0];
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
        #endregion

        #region Constructor
        public Hero(string heroName)
        {
            _setUpHeroName(heroName);
        }
        #endregion
    }
}
