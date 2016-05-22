using SigmundCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand
{
    public class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CommandOption> Options { get; set; }
        public Func<string[], string> ExecuteCmd;

        public void PrintHelp() {
            
            Console.ResetColor();
            Console.Write("Sig " + Name + " ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("<value> ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("<options...> \n\r");
            Console.ResetColor();

            
            Console.WriteLine("  " + Description);

            foreach (CommandOption o in Options) {
                o.PrintHelp();
            }
            
        }

        public virtual void Execute(string[] args) {
            ExecuteCmd(args);
        }

    }
}
