﻿using System;

namespace Zork.Common
{
    public interface IInputService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
