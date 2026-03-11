using System;
using System.IO;
using Winux.Core;

namespace Winux.Commands
{
    public class Touch : iCommand
    {
        public string Name => "touch";
        public string[] Aliases => new string[] { "touch" };

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: touch <file>");
                return;
            }

            string path = args[0];
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                Console.WriteLine($"Created file: {path}");
            }
            else
            {
                File.SetLastWriteTime(path, DateTime.Now);
                Console.WriteLine($"Updated timestamp: {path}");
            }
        }
    }
}