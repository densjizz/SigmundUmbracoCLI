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
        public List<Command> Commands;

        static void Main(string[] args)
        {
            //Commands = LoadCommandsFromJSon();
            var t = new Command() { Name = "Some Command", Description = "description goes here", Options = new List<CommandOption>() { new CommandOption { Callname = "caca", Type = "String", Description = "some command option", Alias = "o", DefaultValue ="Fun" } } };
            t.ExecuteCmd = DoSomething;

            t.Execute(args);
        }

        private static string DoSomething(string[] arg)
        {
            Console.WriteLine("function delegates are working");
            return "";
        }
    }
}
