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
        public bool IsRunning { get; private set; }

        #region Services
        [JsonIgnore]
        public IOutputService Output { get; private set; }

        [JsonIgnore]
        public IInputService Input { get; set; }

        #endregion Services

        #region Json Related Properties

        public World World { get; set; }

        public string StartingLocation { get; set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; set; }


        [JsonIgnore]
        public Player Moves { get; set; }

        [JsonIgnore]
        public Player Score { get; set; }

        #endregion Json Related Properties

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
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE", "TOODLES" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "SCORE", new Command("SCORE", new string[] { "SCORE" }, ScoreCheck) },
                { "REWARD", new Command("REWARD", new string[] { "REWARD", "R" }, Reward) },
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.NORTH)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.SOUTH)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.EAST)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.WEST)) },
            };
        }
        #endregion Commands Related Code

        #region InputReceivedHandler

        public void Start(string jsonString, IInputService input, IOutputService output)
        {
            Assert.IsNotNull(output);
            Output = output;

            Assert.IsNotNull(input);
            Input = input;
            input.InputReceived += InputReceivedHandler;

            IsRunning = true;

            StartFromFile(jsonString, input, output);
        }


        public static Game StartFromFile(string jsonString, IInputService input, IOutputService output)
        {
            //Checking if a file exists in the given location
            if (!File.Exists(jsonString))
            {
                throw new FileNotFoundException("Expected file.", jsonString);
            }

            Game game = JsonConvert.DeserializeObject<Game>(jsonString);
            game.Player = game.World.SpawnPlayer();
            game.Output = output;

            Look(game);

            

            return game;
        }


        private void InputReceivedHandler(object sender, string commandString)
        {
            //Find way to print welcome message here
            while (IsRunning)
            {

                Command foundCommand = null;
                foreach (Command command in Commands.Values)
                {
                    if (command.Verbs.Contains(commandString.Trim()))
                    {
                        foundCommand = command;
                        break;
                    }
                }

                if (foundCommand != null)
                {
                    foundCommand.Action(this);

                    Player.Moves++;

                    //Room previousRoom = Player.Location;
                    //if (previousRoom != Player.Location)
                    //{
                    //    Look(this);
                    //}
                }
                else
                {
                    Output.WriteLine("That's not a verb I recognize.");
                }

            }

            Output.WriteLine(string.IsNullOrWhiteSpace(ExitMessage) ? "Thank you for playing!" : ExitMessage);
        }

        #endregion InputReceivedHandler

        #region Load


        #endregion Load

        #region Command Methods
        private static void Move(Game game, Directions direction)
        {
            if (game.Player.Move(direction) == false)
            {
                Console.WriteLine("The way is shut!");
            }
        }

        private static void Reward(Game game) => game.Player.Score += 1;

        private static void ScoreCheck(Game game)
        {
            if (game.Player.Moves == 1)
            {
                game.Output.WriteLine($"Your score is:{game.Player.Score} and you have made {game.Player.Moves} move(s)");
            }

            else
            {
                game.Output.WriteLine($"Your score is:{game.Player.Score} and you have made {game.Player.Moves} move(s)");
            }
        }

        private static void Look(Game game) => game.Output.WriteLine($"{game.Player.Location}\n {game.Player.Location.Description}");

        private static void Quit(Game game) => game.IsRunning = false;

        private void DisplayWelcomeMessage() => Output.WriteLine(WelcomeMessage);

        #endregion  Command Methods
    }
}
