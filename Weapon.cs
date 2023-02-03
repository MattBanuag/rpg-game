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
        private string _code;
        private string _name;
        private int _power;

        public string Code { get { return _code; } }
        public string Name { get { return _name; } }
        public int Power { get { return _power; } }
        #endregion

        #region Constructor
        public Weapon(string code, string name, int power)
        {
            _code = code;
            _name = name;
            _power = power;
        }
        #endregion
    }
}
