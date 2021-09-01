using System;

namespace ZorkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine().ToUpper();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        //{
            //try
            //{
            //    return Enum.Parse<Commands>(commandString, true);
            //}
            //catch
            //{
            //    return Commands.UNKNOWN;
            //}

            //if (Enum.TryParse<Commands>(commandString, true, out Commands result))
            //{
            //    return result;
            //}
            //else
            //{
            //    return Commands.UNKNOWN;
            //}

            //return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        //}
        //{
        //    Commands command;
        //    switch (commandString)
        //    {
        //        case "QUIT":
        //            command = Commands.QUIT;
        //            break;

        //        case "LOOK":
        //            command = Commands.LOOK;
        //            break;

        //        case "NORTH":
        //            command = Commands.NORTH;
        //            break;

        //        case "SOUTH":
        //            command = Commands.SOUTH;
        //            break;

        //        case "EAST":
        //            command = Commands.EAST;
        //            break;

        //        case "WEST":
        //            command = Commands.WEST;
        //            break;

        //        default:
        //            command = Commands.UNKNOWN;
        //            break;
        //    };

        //    return command;
        //}
    }
}
