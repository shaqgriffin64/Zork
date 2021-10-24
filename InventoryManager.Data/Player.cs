using System.Collections.Generic;

namespace InventoryManager.Data
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }

        public List<Item> Inventory { get; set; }
    }
}
