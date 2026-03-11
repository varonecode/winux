using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Rm : iCommand
    {
        public string Name => "rm";
        public string[] Aliases => new string[] { "rm", "del" };

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: rm [-r] [-f] <file_or_directory>");
                return;
            }

            bool recursive = false;
            bool force = false;
            string path = "";

            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    if (arg.Contains("r")) recursive = true;
                    if (arg.Contains("f")) force = true;
                }
                else
                {
                    path = arg;
                }
            }

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine($"Deleted file: {path}");
                }
                else if (Directory.Exists(path))
                {
                    if (recursive)
                    {
                        Directory.Delete(path, true);
                        Console.WriteLine($"Deleted directory recursively: {path}");
                    }
                    else
                    {
                        Console.WriteLine($"Directory exists: {path}. Use -r to delete recursively.");
                    }
                }
                else if (!force)
                {
                    Console.WriteLine($"File or directory not found: {path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting '{path}': {ex.Message}");
            }
        }
    }
}