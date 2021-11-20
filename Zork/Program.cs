using System;
using Zork;
using Zork.Common;
using ZorkGame;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Program
    {
        //public IOutputService Output { get; set; }

        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            //Game game = JsonConvert.DeserializeObject<Game>();

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            output.WriteLine(Player.Location);

            while (Game.IsRunning)
            {

            }

            //Game game = Game.Load(gameFilename/*, output*/);
            //Supposed to be game.Load not Game.Load
            Game.Load(gameFilename, input, output);
            //Console.WriteLine("Welcome to Zork!");
            Game.Run(input, output);
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguements
        {
            GameFilename = 0
        }
    }

}