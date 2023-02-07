using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentalsFinalProject
{
    public class Potion
    {
        #region Fields and Properties
        private string _code;
        public string Code { get { return _code; } }

        private string _name;
        public string Name { get { return _name; } }

        private string _description;
        public string Description { get { return _description; } }

        private int _boostValue;
        public int BoostValue { get { return _boostValue; } }
        #endregion

        #region Constructor
        public Potion(string code, string name, string description, int boostValue) 
        {
            _code = code;
            _name = name;
            _description = description; 
            _boostValue = boostValue;
        }
        #endregion
    }
}
