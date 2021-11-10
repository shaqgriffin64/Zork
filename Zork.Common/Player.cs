using System;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Player
    {
        public event EventHandler<Room> LocationChanged;

        public World World { get; }

        [JsonIgnore]
        public Room Location { get; private set; }

        //[JsonIgnore]
        //public string LocationName
        //{
        //    get
        //    {
        //        return Location?.Name;
        //    }
        //    set
        //    {
        //        Location = World?.RoomsByName.GetValueOrDefault(value);
        //    }
        //}

        public Player (World world, string startingLocation)
        {
            Assert.IsTrue(world != null);
            Assert.IsTrue(world.RoomsByName.ContainsKey(startingLocation));

            World = world;
            Location = world.RoomsByName[startingLocation];
            //LocationName = startingLocation;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }
    }
}
