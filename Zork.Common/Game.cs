using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Zork.Common;

namespace ZorkGame
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Great Wall Of Properties
        public World World { get; private set; }

        public string StartingLocation { get; set; }

        public Room previousLocation { get; set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }
        [JsonIgnore]
        public bool IsRunning { get; set; }

        public IInputService Input { get; set; }

        public IOutputService Output { get; set; }

        [JsonIgnore]
        public Dictionary<string, Command> Commands { get; private set; }

        #endregion Great Wall Of Properties

        #region Commands Logic
        public Game(World world, Player player)
        {
            World = world;
            Player = player;

            Commands = new Dictionary<string, Command>()
            {
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE", "TOODLES", "SHALLOM" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "REWARD", new Command("REWARD", new string[] { "REWARD", "R"}, Reward) },
                { "SCORE", new Command("SCORE", new string[] { "SCORE"}, ShowScore) },
                /*
                 * {"TAKE", new Command("TAKE", new string[] {"TAKE, T"}, Take)},
                 * {"INVENTORY", new Command("INVENTORY", new string[] {"INVENTORY, I"}, ShowInventory)},
                 */
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.NORTH)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.SOUTH)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.EAST)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.WEST)) },
            };
        }

        #endregion Commands Logic

        #region Start
        public void Start(IInputService input, IOutputService output)
        {
            Assert.IsNotNull(output);
            Output = output;

            Assert.IsNotNull(input);
            Input = input;
            Input.InputReceived += InputRecievedHandler;

            IsRunning = true;
        }

        #endregion Start

        #region Input Handler
        private void InputRecievedHandler(object sender, string commandString)
        {

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
                //This = InputReceivedHandler
                foundCommand.Action(this);
                Player.Moves++;
            }
            else
            {
                //Overall default for when nothing else works
                Output.WriteLine("Unknown command.");
            }
        }

        #endregion Input Handler

        #region Move Method
        //Call this function for when you want to move in any direction (super cool and works nicely)
        private static void Move(Game game, Directions direction)
        {
            if (game.Player.Move(direction) == false)
            {
                game.Output.WriteLine("The way is shut!");
            }
            else
            {
                game.Output.WriteLine($"You moved {direction}.");
            }

            if (game.previousLocation != game.Player.Location)
            {
                game.previousLocation = game.Player.Location;
                Look(game);
            }
            string value = " ";
            game.Output.WriteLine(value);
        }

        #endregion Move Method

        #region Misc. Methods
        //Keep this as a lambda / expression bodied member for ease of use pls
        public static void Look(Game game) => game.Output.WriteLine(game.Player.Location.Description);



        //Just does whatever the hell to the score value
        private static void Reward(Game game) => game.Player.Score += 1;


        //Literally just turns the game off
        private static void Quit(Game game) => game.IsRunning = false;

        //Checks the current score of the player and whatnot
        private static void ShowScore(Game game)
        {
            if (game.Player.Moves > 0)
            {
                game.Output.WriteLine($"Your score is:{game.Player.Score} and you have made {game.Player.Moves} move(s).");
            }
            else
            {
                game.Output.WriteLine($"You don't even have a score yet.");
            }
        }

        //Might be redundant, look into when theres time
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) => Player = new Player(World, StartingLocation);

        #endregion Misc. Methods
    }
}