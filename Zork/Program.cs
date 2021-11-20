using System;
using Zork;
using Zork.Common;
using ZorkGame;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            Game game = JsonConvert.DeserializeObject<Game>(gameFilename);

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();


            //Game Loop
            while (game.IsRunning)
            {
                output.WriteLine(game.Player.Location);
                output.Write("\n> ");
                input.GetInput();
            }

            //Game game = Game.Load(gameFilename/*, output*/);
            //Supposed to be game.Load not Game.Load
            Game.Load(gameFilename, input, output);
            
            //Console.WriteLine("Welcome to Zork!");
            //game.Run(input, output);
            output.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguements
        {
            GameFilename = 0
        }
    }

}