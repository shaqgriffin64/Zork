using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace InventoryManager.Data
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }

        //Despite being private, this list will become a json property
        [JsonProperty(PropertyName = "Inventory")]
        private List<string> InventoryNames { get; set; }

        //Don't deserialize / can't deserialize strings in this context
        [JsonIgnore]
        //The ACTUAL inventory property
        public List<Item> Inventory { get; set; }

        public Player()
        {
            InventoryNames = new List<string>();
            Inventory = new List<Item>();    
        }

        public void BuildInventoryFromNames(List<Item> items)
        {
            Inventory = (from itemName in InventoryNames
                         let item = items.Find(i => i.Name.Equals(itemName, System.StringComparison.InvariantCultureIgnoreCase))
                         where item != null
                         select item).ToList();
        }

        public override string ToString() => Name;

    }
}
