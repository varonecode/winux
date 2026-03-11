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
                Console.WriteLine("Usage: rm <file_or_directory>");
                return;
            }

            string path = args[0];

            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Deleted file: {path}");
            }
            else if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Console.WriteLine($"Deleted directory: {path}");
            }
            else
            {
                Console.WriteLine($"File or directory not found: {path}");
            }
        }
    }
}