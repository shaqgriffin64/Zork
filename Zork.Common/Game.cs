using System.Collections.Generic;
using System.ComponentModel;
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

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }


        [JsonIgnore]
        public IInputService Input { get; set; }

        [JsonIgnore]
        public IOutputService Output { get; set; }

        [JsonIgnore]
        public Room previousLocation { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool IsRunning { get; set; }
        
        //Don't lost track of this
        [JsonIgnore]
        public string interactableItem { get; set; }

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
                {"TAKE", new Command("TAKE", new string[] {"TAKE", "T"}, game => Take(game, interactableItem))},
                {"DROP", new Command("DROP", new string[] {"DROP"}, game => Drop(game, interactableItem))},
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE", "TOODLES", "SHALLOM" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "REWARD", new Command("REWARD", new string[] { "REWARD", "R"}, Reward) },
                { "SCORE", new Command("SCORE", new string[] { "SCORE"}, ShowScore) },
                { "INVENTORY", new Command("INVENTORY", new string[] {"INVENTORY", "I"}, game => ShowInventory(game))},
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.NORTH)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.SOUTH)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.EAST)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.WEST)) },
            };
        }

        #endregion Commands Logic

        #region Start
        public void Start(IInputService input, IOutputService output, Game game)
        {
            //Output instance
            Assert.IsNotNull(output);
            Output = output;

            //Input instance
            Assert.IsNotNull(input);
            Input = input;

            //Input handler
            Input.InputReceived += InputRecievedHandler;

            IsRunning = true;

            //game.Output.WriteLine(game.WelcomeMessage);
        }

        #endregion Start

        #region Input Handler
        private void InputRecievedHandler(object sender, string commandString)
        {
            Command foundCommand = null;

            //Generating an array from the entered command + possible item for command
            string [] generatedStringArray = commandString.Split(' ');

            //Finding a matching command
            foreach (Command command in Commands.Values)
            {

                if (command.Verbs.Contains(generatedStringArray[0]))
                {

                    //Hard coding to check if the inserted command is take
                    if (command.Verbs.Contains("TAKE"))
                    {
                        if (generatedStringArray.Length > 1)
                        {
                            //Give the iteractable item it's actual value (aka the approved item)
                            interactableItem = generatedStringArray[1];
                        }
                        else
                        {
                            //Print the query
                            Output.WriteLine("What do you want to take?");

                            //Print the space
                            Output.Write(" ");
                            return;
                        }
                    }

                    //Hard coding to check if the inserted command is drop
                    else if (command.Verbs.Contains("DROP"))
                    {
                        if (generatedStringArray.Length > 1)
                        {
                            //Give the iteractable item it's actual value (aka the approved item)
                            interactableItem = generatedStringArray[1];
                        }
                        else
                        {
                            //Print the query
                            Output.WriteLine("What do you want to drop?");
                            
                            //Print the space
                            Output.Write(" ");
                            return;
                        }
                    }

                    //Think of this as officiating the entered command after a matching command has been found
                    foundCommand = command;
                    break;
                }
            }

            if (foundCommand != null)
            {
                foundCommand.Action(this);
                Player.Moves++;
            }
            else
            {
                Output.WriteLine("Unknown command.");
                Output.Write(" ");
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

        //Just does whatever the hell to the score value
        private static void Reward(Game game)
        {
            game.Player.Score += 1;

            game.Output.WriteLine("You have been rewarded 1 point!");
        }

        //Literally just turns the game off
        private static void Quit(Game game) => game.IsRunning = false;


        //Keep this as a lambda / expression bodied member for ease of use pls
        public static void Look(Game game)
        {
            game.Output.WriteLine(game.Player.Location.Description);

            if (game.Player.Location.Items != null)
            {
                game.Output.WriteLine("Within the room you see the following:");
                game.Output.Write(" ");

                foreach (Item item in game.Player.Location.Items)
                {
                    game.Output.WriteLine($"- {item.Description}");
                }
            }

            game.Output.Write("");
        }


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
        }//End ShowScore

        //Displays the player's Inventory
        //Player centered Inventory & World centered Master Item List

        private static void ShowInventory(Game game)
        {
            if (game.Player.Inventory.Count != 0)
            {
                game.Output.WriteLine("You are carrying:");

                foreach (Item item in game.Player.Inventory)
                {
                    game.Output.WriteLine($"- {item}");
                }
            }
            else
            {
                game.Output.WriteLine("You are empty handed.");
            }
        }//End Show Inventory


        //Takes the Item
        private static void Take(Game game, string enteredItem)
        {
            //Checks the location's inventory for a matching item
            foreach (Item item in game.Player.Location.Items)
            {
                if (item.Name == enteredItem)
                {
                    game.Player.Inventory.Add(item);
                    game.Player.Location.Items.Remove(item);

                    game.Output.WriteLine($"Taken.");
                    game.Output.Write(" ");

                    return;
                }
            }

            game.Output.WriteLine($"That isn't isn't here.");
            game.Output.Write(" ");
            
            return;
        }//End Take

        //Drops the item
        private static void Drop(Game game, string enteredItem)
        {
            //Checks the player's inventory for a matching item
            foreach (Item item in game.Player.Inventory)
            {
                if (item.Name == enteredItem)
                {
                    game.Player.Location.Items.Add(item);
                    game.Player.Inventory.Remove(item);

                    game.Output.WriteLine($"Dropped.");
                    game.Output.Write(" ");
                    return;
                }
            }
            game.Output.WriteLine($"You do not have such an item.");
            game.Output.Write(" ");

            return;
        }//End Drop

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) => Player = new Player(World, StartingLocation);

        #endregion Misc. Methods
    }
}