using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Cp : iCommand
    {
        public string Name => "cp";
        public string[] Aliases => new string[] { "cp", "copy" };

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: cp <source> <destination>");
                return;
            }

            string source = args[0];
            string dest = args[1];

            if (!File.Exists(source))
            {
                Console.WriteLine($"Source file not found: {source}");
                return;
            }

            File.Copy(source, dest, true);
            Console.WriteLine($"Copied '{source}' to '{dest}'");
        }
    }
}