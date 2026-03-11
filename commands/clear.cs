using System;
using Winux.Core;

namespace Winux.Commands
{
    public class Clear : iCommand
    {
        public string Name => "clear";
        public string[] Aliases => new string[] { "clear", "cls" };

        public void Execute(string[] args)
        {
            Console.Clear();
        }
    }
}