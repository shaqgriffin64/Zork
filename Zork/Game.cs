using Newtonsoft.Json;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZorkGame
{
    public class Game
    {
        public World World { get; set; }

        public string StartingLocation { get; set; }

        public Player Player { get; private set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }


        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Player = new Player(World, StartingLocation);
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        public void Run()
        {
            Console.WriteLine(WelcomeMessage);

            Commands command = Commands.UNKNOWN;

            while (command != Commands.QUIT)
            {

                Console.WriteLine($"{Player.CurrentRoom}");

                if (Player.PreviousRoom != Player.CurrentRoom)
                {
                    Console.WriteLine($"{Player.CurrentRoom.Description} \n");
                    Player.PreviousRoom = Player.CurrentRoom;
                }

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        command = Commands.QUIT;
                        Console.WriteLine(ExitMessage);
                        //Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        command = Commands.LOOK;
                        Console.WriteLine($"{Player.CurrentRoom.Description} \n");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Player.Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                };
            }

        }
    }
}
