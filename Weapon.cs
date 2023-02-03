using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Weapon
    {
        #region Fields and Properties
        private string _name;
        private int _power;
        #endregion

        #region Constructor
        public Weapon(string name, int power)
        {
            _name = name;
            _power = power;
        }
        #endregion
    }
}
