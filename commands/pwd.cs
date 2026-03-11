using System;
using Winux.Core;

namespace Winux.Commands
{
    public class Pwd : iCommand
    {
        public string Name => "pwd";
        public string[] Aliases => new string[] { "pwd" };

        public void Execute(string[] args)
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
        }
    }
}