using System;
using Zork.Common;

namespace Zork
{
    class ConsoleInputService : IInputService
    {
        public event EventHandler<string> InputReceived;

        public void GetInput()
        {
            string inputString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                //null coalescing operator
                InputReceived?.Invoke(this, inputString);
            }
        }
    }
}