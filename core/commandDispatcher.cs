using System;
using System.Collections.Generic;
using System.Linq;
using Winux.Core;

namespace Winux.Core
{
    public class CommandDispatcher
    {
        private readonly List<iCommand> _commands = new();

        public void RegisterCommand(iCommand command)
        {
            _commands.Add(command);
        }

        public void Dispatch(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: winux <command> [args]");
                return;
            }

            string input = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            var command = _commands.FirstOrDefault(c => c.Name.Equals(input, StringComparison.OrdinalIgnoreCase)
                                                      || c.Aliases.Contains(input, StringComparer.OrdinalIgnoreCase));

            if (command == null)
            {
                Console.WriteLine($"Command not found: {input}");
                return;
            }

            command.Execute(commandArgs);
        }
    }
}