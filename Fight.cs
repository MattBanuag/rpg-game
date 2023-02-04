using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Fight
    {
        #region Fields and Properties
        private int _heroTurn;
        private int _monsterTurn;
        private int _win;
        private int _lose;
        #endregion

        #region Constructor
        public Fight(bool heroTurn, Hero hero, Monster monster)
        {
            while (monster.CurrentHealth > 0 || hero.CurrentHealth > 0)
            {
                if (heroTurn)
                {
                    _heroTurn = monster.Defense - hero.BaseStrength + hero.EquippedWeapon.Power;
                    monster.CurrentHealth = monster.CurrentHealth - _heroTurn;
                    Console.WriteLine($"\n{hero.Name} Attacks.... {_heroTurn} damage was dealt.");
                    Console.WriteLine($"{monster.Name} = {monster.CurrentHealth} HP");
                }
                else
                {
                    _monsterTurn = hero.EquippedArmour.Power + hero.BaseStrength - monster.Strength;
                    hero.CurrentHealth = hero.CurrentHealth - _monsterTurn;
                    Console.WriteLine($"\n{monster.Name} Attacks.... {_monsterTurn} damage was dealt.");
                    Console.WriteLine($"{hero.Name} = {hero.CurrentHealth} HP");
                }

                if (hero.CurrentHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Died.....");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    break;
                } else if (monster.CurrentHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monster.Name} has died.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
        #endregion
    }
}
