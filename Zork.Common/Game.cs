using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Zork.Common;

namespace ZorkGame
{
    public class Game
    {
        [JsonIgnore]
        public bool IsRunning { get; set; }

        #region Services
        [JsonIgnore]
        public IOutputService Output { get; private set; }

        [JsonIgnore]
        public IInputService Input { get; set; }

        #endregion Services

        #region Json Related Variables

        public World World { get; set; }

        public string StartingLocation { get; set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; set; }

        #endregion Json Related Variables

        #region Commands Related Code

        [JsonIgnore]
        public Dictionary<string, Command> Commands { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;

            //Add any new commands to this dictionary
            Commands = new Dictionary<string, Command>()
            {
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.NORTH)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.SOUTH)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.EAST)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.WEST)) },
            };
        }

        #endregion Commands Related Code

        #region Run

        public void Run(IInputService input, IOutputService output)
        {
            Assert.IsNotNull(output);
            Output = output;

            Assert.IsNotNull(input);
            Input = input;

            IsRunning = true;
            Room previousRoom = null;

            //Find way to print welcome message here
            while (IsRunning)
            {

                #region New Content
                if (previousRoom != Player.Location)
                {
                    Look(this);
                    previousRoom = Player.Location;
                }

                Output.Write("\n> ");
                string commandString = Console.ReadLine().Trim().ToUpper();
                Command foundCommand = null;
                foreach (Command command in Commands.Values)
                {
                    if (command.Verbs.Contains(commandString))
                    {
                        foundCommand = command;
                        break;
                    }
                }

                if (foundCommand != null)
                {
                    foundCommand.Action(this);
                }
                else
                {
                    Output.WriteLine("Unknown command.");
                }
                #endregion New Content
            }

            Output.WriteLine(string.IsNullOrWhiteSpace(ExitMessage) ? "Thank you for playing!" : ExitMessage);
        }

        #endregion Run

        #region Load

        public static Game Load(string jsonString, IInputService input, IOutputService output)
        {
            //Checking if a file exists in the given location
            if (!File.Exists(jsonString))
            {
                throw new FileNotFoundException("Expected file.", jsonString);
            }

            Game game = JsonConvert.DeserializeObject<Game>(jsonString);
            game.Player = game.World.SpawnPlayer();
            game.Output = output;

            input.InputReceived += InputReceivedHandler;


            return game;
        }

        private static void InputReceivedHandler(object sender, string inputString)
        {
            throw new NotImplementedException();
        }

        #endregion Load

        #region Command Methods
        private static void Move(Game game, Directions direction)
        {
            if (game.Player.Move(direction) == false)
            {
                Console.WriteLine("The way is shut!");
            }
        }

        private static void Look(Game game) => Console.WriteLine(game.Player.Location.Description);

        private static void Quit(Game game) => game.IsRunning = false;

        private void DisplayWelcomeMessage() => Output.WriteLine(WelcomeMessage);

        #endregion  Command Methods
    }
}
