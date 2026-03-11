using System;
using Winux.Core;

namespace Winux.Commands
{
    public class Echo : iCommand
    {
        public string Name => "echo";
        public string[] Aliases => new string[] { "echo" };

        public void Execute(string[] args)
        {
            Console.WriteLine(string.Join(' ', args));
        }
    }
}