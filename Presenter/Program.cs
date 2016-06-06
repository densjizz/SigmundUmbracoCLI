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

        public static CommandRegistry cmdController;

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
            cmdController = new CommandRegistry();

            cmdController.Commands.Add(new Multiply());
            
            cmdController.Commands.Add(new Help(cmdController.Commands));
        }
    }
}
