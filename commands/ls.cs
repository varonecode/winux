using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Ls : iCommand
    {
        public string Name => "ls";
        public string[] Aliases => new string[] { "ls", "dir" };

        public void Execute(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            bool longFormat = false;

            // Parse flags
            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    if (arg.Contains("l")) longFormat = true;
                }
                else
                {
                    path = arg;
                }
            }

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Directory not found: {path}");
                return;
            }

            foreach (var entry in Directory.GetFileSystemEntries(path))
            {
                var info = new FileInfo(entry);
                bool isDir = Directory.Exists(entry);

                if (longFormat)
                {
                    string type = isDir ? "d" : "-";
                    string size = isDir ? "<DIR>" : info.Length.ToString();
                    Console.Write($"{type}\t{size}\t");
                }

                if (isDir) Console.ForegroundColor = ConsoleColor.Cyan;
                else Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(Path.GetFileName(entry));
                Console.ResetColor();
            }
        }
    }
}