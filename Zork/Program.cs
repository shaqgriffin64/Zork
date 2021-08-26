using System;

namespace ZorkGame
{
    enum Commands
    {
        QUIT,
        LOOK,
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UNKNOWN
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            Commands command = ToCommand(inputString.Trim().ToUpper());

            //inputString = inputString.ToUpper();
            
            
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field West of a white house, iwth a boarded front door. \n A rubber mat saying 'Welcome to Zork' lies by the door.");
            }
            else 
            {
                Console.WriteLine("Unrecognized command.");
            }


        }

        private static Commands ToCommand(string commandString)
        {
            Commands command;

            if (true)
            {

            }
            else if (commandString == "QUIT")
            {
                command = Commands.LOOK;
            }
            else if (true)
            {

            }
            else if (true)
            {

            }
            else if (true)
            {

            }
            else if (true)
            {

            }
            else
            {
                
            }
        }
    }
}
