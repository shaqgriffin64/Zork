﻿using System;

namespace ZorkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine().ToUpper();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
