using System;
using System.Linq;
using System.ComponentModel;
using InventoryManager.Data;
using Newtonsoft.Json;
using System.IO;
using ZorkGame;

namespace ZorkBuilder.ViewModels
{
    public class WorldViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Filename { get; set; }

        public BindingList<Room> Rooms { get; set; }

        public Game Game 
        {
            set
            {
                if (mWorld != value)
                {
                    mWorld = value;

                    if (mWorld != null)
                    {
                        Rooms = new BindingList<Room>(Rooms);
                    }
                    else
                    {
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                    }
                }
            }
        }

        public WorldViewModel(Game world = null)
        {
            Game = world;
        }

        #region File Saving
        public void SaveWorld()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                throw new InvalidProgramException("Filename expected.");
            }

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, mWorld);   
            }
        }

        public void NewWorld()
        {
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            mWorld = new Game(mWorld.World, mWorld.Player);

            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, mWorld);
            }
        }
        #endregion File Saving

        private Game mWorld;
    }
}