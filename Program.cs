using System;
using Winux.Core;
using Winux.Commands;

namespace Winux
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new CommandDispatcher();

            // Register all commands
            dispatcher.RegisterCommand(new Whoami());
            dispatcher.RegisterCommand(new Cat());
            dispatcher.RegisterCommand(new Touch());
            dispatcher.RegisterCommand(new Mkdir());

            dispatcher.Dispatch(args);
        }
    }
}