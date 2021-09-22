using System;
using System.Collections.Generic;

//make it just the output of the room instead of room + description when you do no change rooms

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

                Console.Write("\n> ");
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
                        Console.WriteLine("Unknown command. \n");
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
            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                roomMap.Add(room.Name, room);
            }
            
            roomMap["Rocky Trail"].Description = "You are on a rock-strewn trail. \n";
            roomMap["South of House"].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred \n";
            roomMap["Canyon View"].Description = "You are at the top of the Great Canyon on its South wall. \n";
            roomMap["Forest"].Description = "This is a forest, with trees in all directions around you. \n";
            roomMap["West of House"].Description = "This is an open field West of a white house, with a boarded front door. \n";
            roomMap["Behind House"].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar. \n";
            roomMap["Dense Woods"].Description = "This is a dimly lit forest, with large trees all around. To the East, there appears to be sunlight. \n";
            roomMap["North of House"].Description = "You are facing the North side of a white house. There is no door here, and all the windows are barred. \n";
            roomMap["Clearing"].Description = "You are in a clearing, with a forret surroundign you no the West and South. \n";
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

