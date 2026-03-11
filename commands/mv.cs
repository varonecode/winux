using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Mv : iCommand
    {
        public string Name => "mv";
        public string[] Aliases => new string[] { "mv", "move" };

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: mv <source> <destination>");
                return;
            }

            string source = args[0];
            string dest = args[1];

            if (!File.Exists(source) && !Directory.Exists(source))
            {
                Console.WriteLine($"Source not found: {source}");
                return;
            }

            if (File.Exists(source))
            {
                File.Move(source, dest, true);
                Console.WriteLine($"Moved file '{source}' to '{dest}'");
            }
            else
            {
                Directory.Move(source, dest);
                Console.WriteLine($"Moved directory '{source}' to '{dest}'");
            }
        }
    }
}