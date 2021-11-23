﻿using System;
using System.Collections.Generic;
using System.Linq;
using ZorkGame;

namespace Zork.Common
{
    public class Command
    {
        #region Properties
        public string Name { get; set; }

        public string[] Verbs { get; set; }

        public Action<Game> Action { get; set; }

        #endregion Properties

        public Command(string name, IEnumerable<string> verbs, Action<Game> action)
        {
            Assert.IsNotNull(name);
            Assert.IsNotNull(verbs);
            Assert.IsNotNull(action);

            Name = name;
            Verbs = verbs.ToArray();
            Action = action;
        }

        
        public override string ToString() => Name;
    }
}