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
                Console.WriteLine("Usage: cp [-f] <source> <destination>");
                return;
            }

            bool overwrite = false;
            string source = "";
            string dest = "";

            foreach (var arg in args)
            {
                if (arg.StartsWith("-") && arg.Contains("f")) overwrite = true;
                else if (string.IsNullOrEmpty(source)) source = arg;
                else dest = arg;
            }

            if (!File.Exists(source))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Source file not found: {source}");
                Console.ResetColor();
                return;
            }

            File.Copy(source, dest, overwrite);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Copied '{source}' to '{dest}'");
            Console.ResetColor();
        }
    }
}