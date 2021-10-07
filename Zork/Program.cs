using System;

namespace ZorkGame
{
    public class Program
    {
<<<<<<< Updated upstream
         static void Main(string[] args)
=======
        private static readonly Dictionary<string, Room> RoomMap;

        static Program()
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
	            {
                    RoomMap[room.Name] = room;
	            }

        }

    public static Room CurrentRoom
>>>>>>> Stashed changes
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguements.GameFilename] : defaultGameFilename;

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Zork!");
            game.Run();
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguements
        {
            GameFilename = 0
        }
    }

}