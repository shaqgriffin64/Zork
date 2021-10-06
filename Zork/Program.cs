using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

    //Bugs:

    //- Navigation is broken
    //- Welcome & Exit Message are not printing on run
    //- Possibliy missing dictionary

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
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename);
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));
            game.Run();
                //= new Player(game.World);
        }
    }

}