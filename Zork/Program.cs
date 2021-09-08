using System;

namespace ZorkGame
{
    class Program
    {
        public static string Location
            {
                get
                {
                    return Rooms[LocationColumn];
                }
            }

        //public static string outOfBounds
        //    {

        //    }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {


                Console.Write($"{Location}      \n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        command = Commands.QUIT;
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        command = Commands.LOOK;
                        outputString = "A rubber mat saying 'Welcome to Zork!' lies by the door. \n";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                        outputString = "The way is shut \n";
                            break;

                    case Commands.EAST:
                        if (LocationColumn < Rooms.Length - 1)
                        {
                            LocationColumn++;
                            outputString = $"You moved {command}. \n";
                        }
                        else
                        {
                            outputString = "The way is shut. /n";
                        }
                        break;
                    case Commands.WEST:
                        
                        if (LocationColumn > 0)
                        {
                            LocationColumn--;
                            outputString = $"You moved {command}. \n";
                        }
                        else
                        {
                            outputString = "The way is shut. \n";
                        }
                        outputString = $"You moved {command}. \n";
                        break;


                    default:
                        command = Commands.UNKNOWN;
                        outputString = "Unknown command. \n";
                        break;
                };
                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int LocationColumn = 1;

    }
}

