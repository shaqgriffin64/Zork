﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZorkGame
{
    class Program
    {
        public static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        private static (int Row, int Column) Location = (1, 1);

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private enum Fields
        {
            Name = 0,
            Description
        }

        static void Main(string[] args)
        {
            const string roomDescriptionsFilename = "Rooms.txt";
            InitializeRoomDescriptions(roomDescriptionsFilename);

            Console.WriteLine("Welcome to Zork!");

            Room previousRoom = null;

            Commands command = Commands.UNKNOWN;

            while (command != Commands.QUIT)
            {

                Console.WriteLine($"{CurrentRoom}");

                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        command = Commands.QUIT;
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        command = Commands.LOOK;
                        Console.WriteLine(CurrentRoom.Description);
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                };
            }
        }

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

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static void InitializeRoomDescriptions(string roomDescriptionsFilename)
        {


        var roomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                roomMap.Add(room.Name, room);
                roomMap[room.Name] = room;
            }

            //use this when you fill out Rooms.Json
            //string roomsJsonString = File.ReadAllText(roomDescriptionsFilename);
            //Room[] rooms = JsonConvert.DeserializeObject<Room[]>(roomsJsonString);
            //foreach (Room room in rooms)
            //{
            //    roomMap[room.Name].Description = room.Description;
            //}


            string[] lines = File.ReadAllLines(roomDescriptionsFilename);
            foreach (string line in lines)
            {
                const string delimiter = "##";
                const int expectedFieldCount = 2;

                string[] fields = line.Split(delimiter);
                Assert.IsTrue(fields.Length == expectedFieldCount, "Invalid record.");

                (string name, string description) = (fields[(int)Fields.Name], fields[(int)Fields.Description]);
                roomMap[name].Description = description;
            }
        }

        private static readonly Room[,] Rooms =
        {
            {new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            {new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            {new Room("Dense Woods"), new Room("North of House"),  new Room("Clearing") }
        };

    }
}