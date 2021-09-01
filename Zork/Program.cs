using System;

namespace ZorkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

<<<<<<< Updated upstream
            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door. \n A rubber may saying 'Welcome to Zork!' lies by the door.");
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
                Console.Write("> ");
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
                        outputString = "A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                        command = Commands.NORTH;
                        outputString = "You moved NORTH.";
                        break;

                    case Commands.SOUTH:
                        command = Commands.SOUTH;
                        outputString = "You moved SOUTH.";
                        break;

                    case Commands.EAST:
                        command = Commands.EAST;
                        outputString = "You moved EAST.";
                        break;

                    case Commands.WEST:
                        command = Commands.WEST;
                        outputString = "You moved WEST.";
                        break;

                    default:
                        command = Commands.UNKNOWN;
                        outputString = "Unknown command.";
                        break;
                };

                Console.WriteLine(outputString);
            }
=======
            string inputString = Console.ReadLine().ToUpper();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
>>>>>>> Stashed changes
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

    }
}
