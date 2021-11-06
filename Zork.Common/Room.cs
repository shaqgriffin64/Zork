using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zork.Common;

namespace ZorkGame
{
    public class Room : IEquatable<Room>, INotifyPropertyChanged
    {
        public Room(string name = null, string description = null, List<string> roomsNames = null, Dictionary<Directions, string> chosenNeighborNames = null)
        {
            Name = name;
            Description = description;
            RoomsNames = roomsNames ?? new List<string>();
            ChosenNeighborNames = chosenNeighborNames;
            ChosenNeighbors = new Dictionary<Directions, Room>();
            RoomsList = new List<Room>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string Description { get; set; }

        [JsonIgnore]
        public List<Room> RoomsList { get; private set; }


        [JsonProperty(PropertyName = "Room")]
        private List<string> RoomsNames { get; set; }


        [JsonProperty(PropertyName = "ChosenNeighbors", Order = 3)]
        private Dictionary<Directions, string> ChosenNeighborNames { get; set; }

        [JsonIgnore]
<<<<<<< HEAD
        public Dictionary<Directions, Room> ChosenNeighbors { get; set; }
=======
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }
>>>>>>> parent of 40a6bf7 (Joe gave good news)

        public static bool operator ==(Room lhs, Room rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Room lhs, Room rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Room room ? this == room : false;

        public bool Equals(Room other) => this == other;

        public override string ToString() => Name;
        public override int GetHashCode() => Name.GetHashCode();

        public void UpdateNeighbors(World world) => ChosenNeighbors = (from entry in ChosenNeighborNames
                                                                 let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                                                                 where room != null
                                                                 select (Direction: entry.Key, Room: room))
                                                                 .ToDictionary(pair => pair.Direction, pair => pair.Room);

        public void BuildInventoryFromNames(List<Room> rooms)
        {
            RoomsList = (from roomName in RoomsNames
                         let room = rooms.Find(i => i.Name.Equals(roomName, System.StringComparison.InvariantCultureIgnoreCase))
                         where room != null
                         select room).ToList();

            RoomsNames.Clear();
        }
        public void BuildEquippedItemsFromNames(List<Room> rooms)
        {
            //items = items;

            ChosenNeighbors = (from entry in ChosenNeighborNames
                             let item = rooms.Find(i => i.Name.Equals(entry.Value, System.StringComparison.InvariantCultureIgnoreCase))
                             where item != null
                             select (EquipLocation: entry.Key, Item: item)).
                        ToDictionary(pair => pair.EquipLocation, pair => pair.Item);

            ChosenNeighborNames.Clear();
        }
    }
    public class PlayerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType.IsAssignableFrom(typeof(Room));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            string name = jsonObject["Name"].Value<string>();
            string description = jsonObject["Description"].Value<string>();
            List<string> roomNames = jsonObject["Room"].ToObject<List<string>>();

            Dictionary<Directions, string> neighborNames;
            if (jsonObject.TryGetValue("ChosenNeighbors", out JToken neighborNamesToken))
            {
                neighborNames = neighborNamesToken.ToObject<Dictionary<Directions, string>>();
            }
            else
            {
                neighborNames = new Dictionary<Directions, string>();
            }

            return new Room(name, description, roomNames, neighborNames);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Room room = (Room)value;
            JToken neighborNamesToken = JToken.FromObject(room.ChosenNeighbors.ToDictionary(pair => pair.Key, pair => pair.Value.Name), serializer);

            JObject roomObject = new JObject()
            {
                { nameof(Room.Name), room.Name },
                { nameof(Room.Description), room.Description },
                { nameof(Room.RoomsList), JToken.FromObject(room.RoomsList.Select(neighbor => neighbor.Name), serializer)},
                { nameof(Room.ChosenNeighbors), neighborNamesToken },
            };
        }
    }
}