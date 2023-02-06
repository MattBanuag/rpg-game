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
            if (heroTurn)
            {
                while (monster.CurrentHealth > 0 || hero.CurrentHealth > 0)
                {
                    // HERO ATTACKS
                    Console.ForegroundColor = ConsoleColor.Green;
                    _heroTurn = hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;

                    // IF DAMAGE IS 0 OR LESS NOTHING WILL HAPPEN
                    if (_heroTurn <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{hero.Name} Attacks.... but {monster.Name}'s defense prevents the damage!");
                        Console.WriteLine($"{monster.Name} = {monster.CurrentHealth} HP");
                        monster.Defense = monster.Defense - hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        monster.CurrentHealth = monster.CurrentHealth - _heroTurn;
                        Console.WriteLine($"\n{hero.Name} Attacks.... {_heroTurn} damage was dealt.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{monster.Name} = {monster.CurrentHealth} HP");
                        monster.Defense = hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;
                    }

                    // CHECKING IF HERO OR MONSTER HEALTH IS 0 OR LESS
                    if (hero.CurrentHealth <= 0)
                    {
                        _lose += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou Died.....");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nCan you hear me?? Oh good..... one of our scouts saw you fall in battle...");
                        Game.ShowMainMenu();
                        break;
                    }
                    else if (monster.CurrentHealth <= 0)
                    {
                        _win += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n{monster.Name} has died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nOur saviour has returned!!! The fall of {monster.Name} will be a story for the ages!!!");
                        Console.Write("Monsters left: ");
                        Game.Monsters.Remove(monster);
                        Game.ShowMainMenu();
                        break;
                    }

                    // MONSTER ATTACKS
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    _monsterTurn =  monster.Strength - hero.EquippedArmour.Power;

                    // IF DAMAGE IS 0 OR LESS, NOTHING WILL HAPPEN
                    if (_monsterTurn <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{monster.Name} Attacks.... but {hero.Name}'s armour prevents the damage!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{hero.Name} = {hero.CurrentHealth} HP");
                        hero.EquippedArmour.Power = hero.EquippedArmour.Power - monster.Strength;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        hero.CurrentHealth = hero.CurrentHealth - _monsterTurn;
                        Console.WriteLine($"\n{monster.Name} Attacks.... {_monsterTurn} damage was dealt.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{hero.Name} = {hero.CurrentHealth} HP");
                        hero.EquippedArmour.Power = hero.EquippedArmour.Power - monster.Strength;
                    }

                    // CHECKING IF HERO OR MONSTER HEALTH IS 0 OR LESS
                    if (hero.CurrentHealth <= 0)
                    {
                        _lose += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou Died.....");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nCan you hear me?? Oh good..... one of our scouts saw you fall in battle...");
                        Game.ShowMainMenu();
                        break;
                    }
                    else if (monster.CurrentHealth <= 0)
                    {
                        _win += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n{monster.Name} has died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nOur saviour has returned!!! The fall of {monster.Name} will be a story for the ages!!!");
                        Game.Monsters.Remove(monster);
                        Game.ShowMainMenu();
                        break;
                    }
                }
            }
            else
            {
                while (monster.CurrentHealth > 0 || hero.CurrentHealth > 0)
                {
                    // MONSTER ATTACKS
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    _monsterTurn = monster.Strength - hero.EquippedArmour.Power;

                    // IF DAMAGE IS 0 OR LESS, NOTHING WILL HAPPEN
                    if(_monsterTurn <= 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{monster.Name} Attacks.... but {hero.Name}'s armour prevents the damage!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{hero.Name} = {hero.CurrentHealth} HP");
                        hero.EquippedArmour.Power = hero.EquippedArmour.Power - monster.Strength;
                    } else
                    {
                        hero.CurrentHealth = hero.CurrentHealth - _monsterTurn;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{monster.Name} Attacks.... {_monsterTurn} damage was dealt.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{hero.Name} = {hero.CurrentHealth} HP");
                        hero.EquippedArmour.Power = hero.EquippedArmour.Power - monster.Strength;
                    }

                    // CHECKING IF HERO OR MONSTER HEALTH IS 0 OR LESS
                    if (hero.CurrentHealth <= 0)
                    {
                        _lose += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou Died.....");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nCan you hear me?? Oh good..... one of our scouts saw you fall in battle...");
                        Game.ShowMainMenu();
                        break;
                    }
                    else if (monster.CurrentHealth <= 0)
                    {
                        _win += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n{monster.Name} has died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nOur saviour has returned!!! The fall of {monster.Name} will be a story for the ages!!!");
                        Game.Monsters.Remove(monster);
                        Game.ShowMainMenu();
                        break;
                    }

                    // HERO ATTACKS
                    Console.ForegroundColor = ConsoleColor.Green;
                    _heroTurn = hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;

                    // IF DAMAGE IS 0 OR LESS NOTHING WILL HAPPEN
                    if (_heroTurn <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{hero.Name} Attacks.... but {monster.Name}'s defense prevents the damage!");
                        Console.WriteLine($"{monster.Name} = {monster.CurrentHealth} HP");
                        monster.Defense = monster.Defense - hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        monster.CurrentHealth = monster.CurrentHealth - _heroTurn;
                        Console.WriteLine($"\n{hero.Name} Attacks.... {_heroTurn} damage was dealt.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{monster.Name} = {monster.CurrentHealth} HP");
                        monster.Defense = monster.Defense - hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defense;
                    }

                    // CHECKING IF HERO OR MONSTER HEALTH IS 0 OR LESS
                    if (hero.CurrentHealth <= 0)
                    {
                        _lose += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou Died.....");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nCan you hear me?? Oh good..... one of our scouts saw you fall in battle...");
                        Game.ShowMainMenu();
                        break;
                    }
                    else if (monster.CurrentHealth <= 0)
                    {
                        _win += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n{monster.Name} has died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nOur saviour has returned!!! The fall of {monster.Name} will be a story for the ages!!!");
                        Game.Monsters.Remove(monster);
                        Game.ShowMainMenu();
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
