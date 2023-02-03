using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Monster
    {
        #region Fields and Properties
        private string _name;
        public string Name { get { return _name; } }

        private int _strength;
        public int Strength { get { return _strength; } }

        private int _defense;
        public int Defense { get { return _defense; } }

        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } }

        private int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
        #endregion

        #region Constructor
        public Monster(string name, int strength, int defense, int originalHealth)
        {
            _name = name;
            _strength = strength;
            _defense = defense;
            _originalHealth = originalHealth;
        }
        #endregion
    }
}
