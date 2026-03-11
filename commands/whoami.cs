using System;
using Winux.Core;

namespace Winux.Commands
{
    public class Whoami : iCommand
    {
        public string Name => "whoami";
        public string[] Aliases => new string[] { "whoami" };

        public void Execute(string[] args)
        {
            Console.WriteLine(Environment.UserName);
        }
    }
}