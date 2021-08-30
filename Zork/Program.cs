using System;

namespace ZorkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (true)
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door. \n A rubber may saying 'Welcome to Zork!' lies by the door.");
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }
        }
    }
}
