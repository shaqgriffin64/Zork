using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZorkGame
{
    public class Player
    {
        #region Event Handlers
        public event EventHandler<Room> LocationChanged;

        public event EventHandler<int> ScoreChanged;

        public event EventHandler<int> MovesChanged;

        #endregion Event Handlers

        #region Variables

        private Room location;
        private int score;
        private int moves;
        //Invnetory variable
        //private List<[insert either reference to Items.cs OR ]> Inventory;

        //Insert player inventory list

        #endregion Variables

        #region Properties
        public World World { get; }

        [JsonIgnore]
        public Room Location
        {
            get
            {
                return location;
            }
            private set
            {
                if (location != value)
                {
                    location = value;
                    LocationChanged?.Invoke(this, location);
                }
            }
        }

        public int Moves
        {
            get
            {
                return moves;
            }
            set
            {
                if (moves != value)
                {
                    moves = value;
                    MovesChanged?.Invoke(this, moves);
                }
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    ScoreChanged?.Invoke(this, score);
                }
            }
        }

        public List<Item> Inventory { get; set; }

        #endregion Properties

        //Player Setup
        public Player(World world, string startingLocation)
        {
            Assert.IsTrue(world != null);
            Assert.IsTrue(world.roomsByName.ContainsKey(startingLocation));

            World = world;
            Location = world.roomsByName[startingLocation];
        }

        //Logic for movement
        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }
    }
}
