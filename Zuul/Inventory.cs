using System;
using System.Collections.Generic;

namespace Zuul
{
    public class Inventory
    {
        private int maxWeight;
        private Dictionary<string,Item> items;
        public Inventory(int maxWeight)
        {
            this.maxWeight = maxWeight;
            this.items = new Dictionary<string, Item>();
        }
        public int CurrentWeight()
        {
            int totalWeight = 0;
            foreach (KeyValuePair<string, Item> entry in items)
            {
                totalWeight += entry.Value.Weight;
            }
            return totalWeight;
        }
        public bool Put(string itemName, Item item)
        {
            if (CurrentWeight() + item.Weight <= maxWeight)
            {
                items.Add(itemName, item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Item Get(string itemName)
        {
            if (items.ContainsKey(itemName))
            {
                Item item = items[itemName];
                items.Remove(itemName);
                return item;
            }
            return null;
        }
        public string CheckRoomItems()
        {
            foreach (KeyValuePair<string, Item> entry in items)
            {
                return ("These items are in the room: " + entry.Key);
            }
            return ("There are no items in this room.");
        }
        public string CheckInvItems()
        {
            foreach (KeyValuePair<string, Item> entry in items)
            {
                return ("These items are in your inventory: " + entry.Key);
            }
            return ("There are no items in your inventory.");
        }

    }
}
