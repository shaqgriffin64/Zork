using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Zork.Common;

namespace ZorkGame
{
    public class Room : IEquatable<Room>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Porperties

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string Description { get; set; }

        #endregion Properties

        #region Dictionary
        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; } = new Dictionary<Directions, string>();

        #endregion Dictionary

        //Interface Dictionary
        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors => mNeighbors;

        //Room ref???
        public Room(string name = null)
        {
            Name = name;
        }

        //Space Magic, look into this over Winter Break
        public static bool operator == (Room lhs, Room rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return string.Compare(lhs.Name, rhs.Name, ignoreCase: true) == 0;
        }

        public static bool operator !=(Room lhs, Room rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Room room && this == room;

        public bool Equals(Room other) => this == other;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();

        public void UpdateNeighbors(World world)
        {
            mNeighbors.Clear();
            foreach (var entry in NeighborNames)
            {
                mNeighbors.Add(entry.Key, world.roomsByName[entry.Value]);
            }
        }

        public void RemoveNeighbor(Directions direction)
        {
            mNeighbors.Remove(direction);

            NeighborNames.Remove(direction);
        }

        public void AssignNeighbor(Directions direction, Room neighbor)
        {
            mNeighbors[direction] = neighbor;

            NeighborNames[direction] = neighbor.Name;
        }

        private Dictionary<Directions, Room> mNeighbors = new Dictionary<Directions, Room>();
    }
}