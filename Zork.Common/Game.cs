using System;
using System.IO;
using Newtonsoft.Json;
using Zork.Common;

namespace ZorkGame
{
    public class Game
    {
        public World World { get; set; }

        [JsonIgnore]
        public Player Player { get; set; }


        [JsonIgnore]
        private bool IsRunning { get; set; }

        public Game (World world, Player player)
        {
            World = world;
            Player = player;
        }

        public IOutputService Output { get; set; }

        public void Run()
        {
            IsRunning = true;
            Room previousRoom = null;
            while (IsRunning)
            {

                Output.WriteLine(Player.Location);
                if (previousRoom != Player.Location)
                {
                    Output.WriteLine(Player.Location.Description);
                    previousRoom = Player.Location;
                }

                Output.Write("> ");
                Commands command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        command = Commands.QUIT;
                        IsRunning = false;
                        break;

                    case Commands.LOOK:
                        Output.WriteLine(Player.Location.Description);
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Directions direction = (Directions)command;
                        if (Player.Move(direction) == false)
                        {
                            Output.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Output.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        public static Game Load(string fileName, IOutputService output)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(fileName));
            game.Player = game.World.SpawnPlayer();

            game.Output = output;

            return game;
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
