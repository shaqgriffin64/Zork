using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class World : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public List<Room> rooms { get; set; }


        #endregion Properties

        //Interface Dictionary || Ignored
        [JsonIgnore]
        public IReadOnlyDictionary<string, Room> roomsByName => mRoomsByName;

        //World Instance
        public World()
        {
            rooms = new List<Room>();
            mRoomsByName = new Dictionary<string, Room>();
        }

        //Might also be redundant, look into in the future
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mRoomsByName = rooms.ToDictionary(room => room.Name, room => room);

            foreach (Room room in rooms)
            {
                room.UpdateNeighbors(this);
            }
        }

        private Dictionary<string, Room> mRoomsByName;
    }
}
