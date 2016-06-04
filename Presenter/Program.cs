using SigmundCommand;
using SigmundCommand.Commands;
using SigmundCommand.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class Program
    {

        public static CommandController cmdController;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            InitiateCommands();

            var argList = args.ToList();
            argList.RemoveAt(0);
            cmdController.ExecuteCommand(args[0], argList.ToList());
            Console.ReadLine();
        }
        

        private static void InitiateCommands()
        {
            cmdController = new CommandController();

            cmdController.Commands.Add(new Multiply() { Name = "multiply", Alias= "m", Description = "Multiplies two numbers and return result" });


            var help = new Help() { Name = "help", Alias = "h", Description = "List all available commands.", CmdController = cmdController };
            cmdController.Commands.Add(help);
        }
    }
}
