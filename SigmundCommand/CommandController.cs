using SigmundCommand.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand
{
    public class CommandController
    {
        public List<Command> Commands { get; set; }

        public CommandController() {
            Commands = new List<Command>();
        }

        public Command GetCommand(string name, IEnumerable<string> args) {

            var cmd = Commands.Where(x => x.Name.ToLower() == args.ElementAt(0)).FirstOrDefault();
            if (cmd == null) cmd = GetCommandByAlias(name);
            return cmd;

        }

        private Command GetCommandByAlias(string alias)
        {
            return Commands.Where(x => x.Alias.ToLower() == alias).FirstOrDefault();
            
        }

        public void ExecuteCommand(string name, IEnumerable<string> args) {
            var cmd = GetCommand(name, args);
            if (cmd != null)
            {
                cmd.Execute(args);
            }
            else {
                PrintErrorCmdNotFound(name);
            }
            
        }

        private void PrintErrorCmdNotFound(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command " + name + " not found");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
