﻿using System;
using System.Collections.Generic;

namespace ZorkGame
{
    class Program
    {
        public static  Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        static void Main(string[] args)
        {
            InitializeRoomDescriptions();

            Console.WriteLine("Welcome to Zork!");

           //Room previousRoom = null;

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {

                Console.WriteLine(Rooms[Location.Row, Location.Column]);

                //if (previousRoom != CurrentRoom)
                //{
                //    Console.WriteLine(CurrentRoom.Description);
                //    previousRoom = CurrentRoom;
                //}

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                //string outputString;
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

        private static Commands ToCommand(string commandString) => 
            Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool IsDirection(Commands command) => Directions.Contains(command);



        private static void InitializeRoomDescriptions()
        {
            
            Rooms[0, 0].Description = "You are on a rock-strewn trail.";                                                                                 // Rocky Trail
            Rooms[0, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred ";          // South of House
            Rooms[0, 2].Description = "You are at the top of the Great Canyon on its South wall.";                                                       // Canyon View
            
            Rooms[1, 0].Description = "This is a forest, with trees in all directions around you.";                                                      // Forest
            Rooms[1, 1].Description = "This is an open field West of a white house, with a boarded front door.";                                         // West of House
            Rooms[1, 2].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar.";      // Behind House
            
            Rooms[2, 0].Description = "This is a dimly lit forest, with large trees all around. To the East, there appears to be sunlight.";             // Dense Woods
            Rooms[2, 1].Description = "You are facing the North side of a white house. There is no door here, and all the windows are barred.";          // North of House
            Rooms[2, 2].Description = "You are in a clearing, with a forret surroundign you no the West and South.";                                     // Clearing
        }

        private static readonly Room[,] Rooms = 

        {
            {new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            {new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            {new Room("Dense Woods"), new Room("North of House"),  new Room("Clearing") }

        };

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private static (int Row, int Column) Location = (1, 1);
    } 
}

