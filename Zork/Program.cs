using System;
using Zork;

namespace ZorkGame
{
    public class Program
    {
        //public IOutputService Output { get; set; }

        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            ConsoleOutputService output = new ConsoleOutputService();
            ConsoleInputService input = new ConsoleInputService();

            Game game = Game.Load(gameFilename, output);
            Console.WriteLine("Welcome to Zork!");
            game.Run(input, output);
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguements
        {
            GameFilename = 0
        }
    }

}