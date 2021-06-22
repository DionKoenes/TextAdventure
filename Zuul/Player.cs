using System;

namespace Zuul
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        private int health;
        private bool isAlive;
        public Player()
        {
            CurrentRoom = null;
            health = 100;
        }

        public int Damage(int amount)
        {
            health = health - amount;
            return amount;
        }

        public int Heal(int amount)
        {
            health = health + amount;
            return amount;
        }

        public bool PlayerAlive()
        {
            if (health < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
            return isAlive;
        }
    }
}