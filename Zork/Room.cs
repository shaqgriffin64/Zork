﻿using Sytem;
using system.Text;

namespace Zork
{
    class Room
    {
        public string Name { get; }

        public string Description { get; set; }

        public Room(string name, string description = "")
        {
            Name = name;

            Description = description;
        }
    }
}