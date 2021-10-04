using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ZorkGame
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room CurrentRoom
        {
            get
            {
                return World.Rooms[Location.Row, Location.Column];
            }
        }

        [JsonIgnore]
        public Room PreviousRoom { get; set; }

        public Player (World world, string startingLocation)
        {
            World = world;

            //Location = arracy indices for the given name;

            for (int row = 0; row < World.Rooms.GetLength(0); row++)
            {
                for (int column = 0; column < World.Rooms.GetLength(1); column++)
                {
                    //Room room = World.Rooms[row, column];

                    if (World.Rooms[row, column].Name.Equals(startingLocation, System.StringComparison.OrdinalIgnoreCase))
                    {
                        Location = (row, column);
                        return;
                    }
                }
            }
        }

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        public bool Move(Commands command)
        {
            Assert.IsTrue(Directions.Contains(command), "Invalid direction.");

            bool isValidMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row < World.Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;
                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < World.Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;
                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }
            return isValidMove;
        }



        private static (int Row, int Column) Location = (1, 1);
    }
}
