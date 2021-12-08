﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZorkGame
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Item(string name = null)
        {
            Name = name;
        }

        public static bool operator ==(Item lhs, Item rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return string.Compare(lhs.Name, rhs.Name, ignoreCase: true) == 0;
        }

        public static bool operator !=(Item lhs, Item rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Item item && this == item;

        public bool Equals(Item other) => this == other;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();
    }
}
