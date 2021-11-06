using System;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;

namespace ZorkBuilder.ViewModels
{
    public class WorldViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Filename { get; set; }

        public BindingList<Player> Players { get; set; }



        public BindingList<Item> Items { get; set; }

        public World World 
        {
            set
            {
                if (mWorld != value)
                {
                    mWorld = value;

                    if (mWorld != null)
                    {
<<<<<<< HEAD
                        Rooms = new BindingList<Room>(Rooms);
=======
                        Players = new BindingList<Player>(mWorld.Players);
                        Items = new BindingList<Item>(mWorld.Items);
>>>>>>> parent of 40a6bf7 (Joe gave good news)
                    }
                    else
                    {
                        Players = new BindingList<Player>(Array.Empty<Player>());
                        Items = new BindingList<Item>(Array.Empty<Item>());
                    }
                }
            }
        }

        public WorldViewModel(World world = null)
        {
            World = world;
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

<<<<<<< HEAD
            mWorld = new Game(mWorld.World, mWorld.Player);
=======
            mWorld = new World();
>>>>>>> parent of 40a6bf7 (Joe gave good news)

            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, mWorld);
            }
        }
        #endregion File Saving

        private World mWorld;
    }
}