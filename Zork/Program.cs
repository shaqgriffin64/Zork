using System;

namespace ZorkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
        }

        static Commands ToCommand(string commandString)
            /*{
                return Enum.Parse<Commands>(commandString, true);
            }*/
        {
            Commands command;
            switch (commandString)
            {
                case "QUIT":
                    command = Commands.QUIT;
                    break;

                case "LOOK":
                    command = Commands.LOOK;
                    break;

                case "NORTH":
                    command = Commands.NORTH;
                    break;

                case "SOUTH":
                    command = Commands.SOUTH;
                    break;

                case "EAST":
                    command = Commands.EAST;
                    break;

                case "WEST":
                    command = Commands.WEST;
                    break;

                default:
                    command = Commands.UNKNOWN;
                    break;
            };
            return Commands.UNKNOWN;
        }
    }
}
