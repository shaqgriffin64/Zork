using System;
using Zork;
using Zork.Common;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            //Generating game variable, tying it to loaded file
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

            //Supposed to be game.Load not Game.Load
            Game.Start(gameFilename, input, output);
            
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