using System;
using System.Collections.Generic;

//Personal note, finish Zork 2.3

namespace ZorkGame
{
    class Program
    {
        public static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {

                Console.WriteLine(CurrentRoom);
;                Console.Write("\n> ");
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
                        Console.WriteLine("A rubber mat saying 'Welcome to Zork!' lies by the door. \n");
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

        private static void InitializeRoomDescriptions()
        {
            Rooms[0, 0] = "You are on a rock-strewn trail";
        }

        private static readonly Room[,] Rooms = 
        {
            {new Room ("Rocky Trail"), new Room ("South of House"), new Room("Canyon View")},
            {new Room ("Forest"), new Room ("West of House"), new Room("Behind House") },
            {new Room ("Dense Woods"), new Room ("North of House"),  new Room ("Clearing")}

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

