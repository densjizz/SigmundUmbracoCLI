using SigmundCommand;
using SigmundCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class Program
    {
        public static List<Command> Commands = new List<Command>();

        static void Main(string[] args)
        {
            InitiateCommands();

            ExecuteCommand(args);

            
        }

        private static void ExecuteCommand(string[] args)
        {
            if (args == null || args.Count() == 0)
            {
                Commands.Where(x => x.Name == "help").FirstOrDefault().Execute(args);
            }
            else {
                var cmd = Commands.Where(x => x.Name.ToLower() == args[0]).FirstOrDefault();
                if (cmd != null) cmd.Execute(args);
            }
            


        }

        private static void InitiateCommands()
        {
            
            //var helpCommand = new HelpCommand() { Name = "Help", Description = "List all available commands.", Options = new List<CommandOption>() { new CommandOption { Callname = "caca", Type = "String", Description = "some command option", Alias = "o", DefaultValue = "Fun" } } };
            var helpCommand = new HelpCommand() { Name = "help", Alias = "h", Description = "List all available commands.", Options = new List<CommandOption>() {  }, Commands = Commands };
            Commands.Add(helpCommand);
        }
    }
}
