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
            string path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Directory not found: {path}");
                return;
            }

            foreach (var entry in Directory.GetFileSystemEntries(path))
            {
                Console.WriteLine(entry);
            }
        }
    }
}