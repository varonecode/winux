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

            dispatcher.RegisterCommand(new Whoami());
            dispatcher.RegisterCommand(new Cat());
            dispatcher.RegisterCommand(new Touch());
            dispatcher.RegisterCommand(new Mkdir());
            dispatcher.RegisterCommand(new Ls());
            dispatcher.RegisterCommand(new Rm());
            dispatcher.RegisterCommand(new Cp());
            dispatcher.RegisterCommand(new Mv());
            dispatcher.RegisterCommand(new Pwd());
            dispatcher.RegisterCommand(new Echo());
            dispatcher.RegisterCommand(new Clear());

            dispatcher.Dispatch(args);
        }
    }
}