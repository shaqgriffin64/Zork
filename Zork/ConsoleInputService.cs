using System;
using Zork.Common;

//To Do: Fix broken stuff
//      - Broken stuff is mostly fixed
//      - Fix this script specifically

namespace Zork
{
    class ConsoleInputService : IInputService
{
        //public void ReadLine(object value)
        //{
        //    Console.ReadLine(value);
        //}

        public event EventHandler<string> InputReceived;

        public void ProcessInput()
        {
            string inputString = Console.ReadLine.Trim().ToUpper();
            InputReceived?.Invoke(this, inputString);
        }
    }
}