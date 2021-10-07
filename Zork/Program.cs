﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ZorkGame
{
    class Program
    {
        private static Room[,] Rooms;

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

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        enum Fields
        {
            Name = 0,
            Description,
        }

        static void Main(string[] args)
        {

            const string defaultRoomsFilename = "Rooms.Json";
            string roomsFilename = args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename;

            InitializeRoomDescriptions(roomsFilename);

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


        private static void InitializeRoomDescriptions(string roomsFilename) =>
            Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));
    }
}