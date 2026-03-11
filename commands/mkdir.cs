using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Mkdir : iCommand
    {
        public string Name => "mkdir";
        public string[] Aliases => new string[] { "mkdir" };

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: mkdir <directory>");
                return;
            }

            string path = args[0];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Directory created: {path}");
            }
            else
            {
                Console.WriteLine($"Directory already exists: {path}");
            }
        }
    }
}