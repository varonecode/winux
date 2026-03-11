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
                Console.WriteLine("Usage: mv [-f] <source> <destination>");
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

            try
            {
                if (File.Exists(dest) || Directory.Exists(dest))
                {
                    if (!overwrite)
                    {
                        Console.WriteLine($"Destination exists: {dest}. Use -f to overwrite.");
                        return;
                    }

                    if (File.Exists(dest)) File.Delete(dest);
                    else Directory.Delete(dest, true);
                }

                if (File.Exists(source))
                {
                    File.Move(source, dest);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Moved file '{source}' to '{dest}'");
                    Console.ResetColor();
                }
                else if (Directory.Exists(source))
                {
                    Directory.Move(source, dest);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Moved directory '{source}' to '{dest}'");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Source not found: {source}");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error moving '{source}' to '{dest}': {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}