using System.ComponentModel;

namespace InventoryManager.Data
{
    public class Item : INotifyPropertyChanged
    {
        //Basically the same as a variable being given a value via the inspector in Unity instead of in script
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
    }
}
