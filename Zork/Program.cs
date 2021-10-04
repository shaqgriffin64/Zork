using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Program
    {
        private enum CommandLineArguements
        {
            GameFilename = 0
        }
        private enum Fields
        {
            Name = 0,
            Description
        }
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.Json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename);
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));
            game.player = new Player(game.World);
        }
    }

}