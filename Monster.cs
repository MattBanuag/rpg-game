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
        private int _strength;
        private int _defense;
        private int _originalHealth;
        private int _currentHealth;
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
