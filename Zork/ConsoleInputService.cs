using System;
using Zork.Common;

//To Do: Fix broken stuff

namespace Zork : IInputService
{
    class ConsoleInputService
{
    public void ReadLine(object value)
    {
        Console.ReadLine(value);
    }
}
}
