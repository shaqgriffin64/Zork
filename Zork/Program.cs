using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZorkGame
{
    class Program
    {

        //private static readonly Room[,] Rooms =
        //{
        //    {new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
        //    {new Room("Forest"), new Room("West of House"), new Room("Behind House") },
        //    {new Room("Dense Woods"), new Room("North of House"),  new Room("Clearing") }
        //};



        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private enum CommandLineArguements
        {
            GameFilename = 0
        }


        private enum Fields
        {
            Name = 0,
            Description
        }

        #region Main
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.Json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename);
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));
            game.Player = new Player(game.World);




            //InitializeRoomDescriptions(roomDescriptionsFilename);



            
            }
        }
        #endregion

        #region Move method
        private static bool Move(Commands command)
        {
            bool isValidMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;
                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
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
        #endregion


        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static void InitializeRoomDescriptions(string roomDescriptionsFilename)
        {


            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                roomMap.Add(room.Name, room);
                roomMap[room.Name] = room;
            }

            //use this when you fill out Rooms.Json [Zork 4.2]
            string roomsJsonString = File.ReadAllText(roomDescriptionsFilename);
            Room[] rooms = JsonConvert.DeserializeObject<Room[]>(roomsJsonString);
            foreach (Room room in rooms)
            {
                roomMap[room.Name].Description = room.Description;
            }


            //string[] lines = File.ReadAllLines(roomDescriptionsFilename);
            //foreach (string line in lines)
            //{
            //    const string delimiter = "##";
            //    const int expectedFieldCount = 2;

            //    string[] fields = line.Split(delimiter);
            //    Assert.IsTrue(fields.Length == expectedFieldCount, "Invalid record.");

            //    (string name, string description) = (fields[(int)Fields.Name], fields[(int)Fields.Description]);
            //    roomMap[name].Description = description;
            //}
        }

    }
}