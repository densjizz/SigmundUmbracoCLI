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
        public string Alias { get; set; }
        public string Description { get; set; }
        public List<CommandOption> Options { get; set; }

        public void PrintHelp() {
            
            Console.ResetColor();
            Console.Write("sig " + Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" <value> ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("<options...> \n\r");
            Console.ResetColor();

            
            Console.WriteLine("  alias " + Alias + " " + Description);

            foreach (CommandOption o in Options) {
                o.PrintHelp();
            }
            
        }

        public virtual void Execute(string[] args) {
            
        }

        public virtual void Undo(string[] args) {

        }

    }
}
