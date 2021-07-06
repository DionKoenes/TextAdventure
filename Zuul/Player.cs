using System;

namespace Zuul
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        private int health;
        private Inventory inventory;
        public Player()
        {
            CurrentRoom = null;
            health = 100;
            inventory = new Inventory(50);
        }
        public bool TakeFromChest(string itemName)
        {
            Item item = CurrentRoom.Chest.Get(itemName);
            if (item == null)
            {
                Console.WriteLine(item + " is nowhere to be seen");
                return false;
            }

            if (inventory.Put(itemName, item))
            {
                Console.WriteLine(item + " has been picked up and stored in your backpack");
                return true;
            }

            CurrentRoom.Chest.Put(itemName, item);
            Console.WriteLine(item + " Does not fit, your backpack is full. You put the " + item + " back where you found it");
            return false;
        }
        public bool DropToChest(string itemName)
        {
            Item item = inventory.Get(itemName);
            if (item == null)
            {
                Console.WriteLine(item + " is not in your backpack");
                return false;
            }

            if (CurrentRoom.Chest.Put(itemName, item))
            {
                Console.WriteLine(item + " has been take out from your backpack and placed in a suitable spot");
                return true;
            }

            inventory.Put(itemName, item);
            Console.WriteLine(item + " Does not fit, the room is full. You put the " + item + " back in your backpack");
            return false;
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
            return health > 0;
        }
    }
}