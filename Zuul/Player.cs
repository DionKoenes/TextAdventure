using System;

namespace Zuul
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        private int health;
        public Inventory inventory;
        public Player()
        {
            CurrentRoom = null;
            health = 100;
            inventory = new Inventory(50);
        }
        public void Status()
        {
            Console.WriteLine("Your current life points are: " + health + " out of 100");
        }
        public void Inventory()
        {
            Console.WriteLine(inventory.CheckInvItems());
        }
        public bool TakeFromChest(string itemName)
        {
            Item item = CurrentRoom.Chest.Get(itemName);
            if (item == null)
            {
                Console.WriteLine(itemName + " is nowhere to be seen");
                return false;
            }

            if (inventory.Put(itemName, item))
            {
                Console.WriteLine(itemName + " has been picked up and stored in your backpack");
                return true;
            }

            CurrentRoom.Chest.Put(itemName, item);
            Console.WriteLine(itemName + " Does not fit, your backpack is full. You put the " + itemName + " back where you found it");
            return false;
        }
        public bool DropToChest(string itemName)
        {
            Item item = inventory.Get(itemName);
            if (item == null)
            {
                Console.WriteLine(itemName + " is not in your backpack");
                return false;
            }

            if (CurrentRoom.Chest.Put(itemName, item))
            {
                Console.WriteLine(itemName + " has been take out from your backpack and placed in a suitable spot");
                return true;
            }

            inventory.Put(itemName, item);
            Console.WriteLine(itemName + " Does not fit, the room is full. You put the " + itemName + " back in your backpack");
            return false;
        }

        public string Use(Command command)
        {
            string itemName = command.GetSecondWord();
            Item item = inventory.Get(itemName);
            if(item == null)
            {
                Console.WriteLine("You couldn't find " + itemName + " in your backpack");
                return "";
            }
            //NEEDLE
            if(itemName == "needle")
            {
                Damage(20);
                Console.WriteLine("You used your " + itemName + " and lost 20 life poinst due to an allergic reaction");
                return "";
            }
            //BASEMENT KEY
            if(itemName == "basement_key")
            {
                string exitstring = command.GetThirdWord();
                Room next = CurrentRoom.GetExit(exitstring);
                next.UnlockDoor();
                Console.WriteLine("You used your " + itemName + " and opened the basement door");
                return "";
            }
            return "";
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