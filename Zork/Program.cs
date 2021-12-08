using System.IO;
using Zork;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Program
    {
        #region Main

        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            //Generating game variable, tying it to loaded file
            //Game game = JsonConvert.DeserializeObject<Game>(gameFilename);
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));


            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            game.Player.LocationChanged += Player_LocationChanged;

            output.WriteLine(string.IsNullOrWhiteSpace(game.WelcomeMessage) ? "Welcome To Zork!" : game.WelcomeMessage);

            game.Start(input, output, game);
            output.WriteLine(game.StartingLocation);
            Game.Look(game);
            output.Write("\n> ");

            //Game Loop
            while (game.IsRunning)
            {
                //output.WriteLine(game.Player.Location);
                input.GetInput();
                output.Write("\n> ");
            }

            output.WriteLine(string.IsNullOrWhiteSpace(game.ExitMessage) ? "Thank You For Playing!" : game.ExitMessage);
        }

        #endregion Main

        #region Event Handlers
        private static void Player_LocationChanged(object sender, Room e)
        {
            //throw new NotImplementedException();
        }

        #endregion Event Handlers

        #region Enums
        private enum CommandLineArguements
        {
            GameFilename = 0
        }

        #endregion Enums
    }
}