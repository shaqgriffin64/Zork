using System.ComponentModel;
using System.Runtime.CompilerServices;
using InventoryManager.Data;

 namespace ZorkBuilder.ViewModels
{
    public class WorldViewModel : INotifyPropertyChanged
    {
        //Basically the same as a variable being given a value via the inspector in Unity instead of in script
        public event PropertyChangedEventHandler PropertyChanged;

        public string Filename { get; set; }

        public World World { get; set; }
    }
}