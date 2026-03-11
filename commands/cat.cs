using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Cat : iCommand
    {
        public string Name => "cat";
        public string[] Aliases => new string[] { "cat" };

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: cat <file>");
                return;
            }

            string path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine($"File not found: {path}");
                return;
            }

            Console.WriteLine(File.ReadAllText(path));
        }
    }
}