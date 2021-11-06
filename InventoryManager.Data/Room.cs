using System.ComponentModel;

namespace InventoryManager.Data
{
    class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }

        public string Description { get; set; }


    }
}
