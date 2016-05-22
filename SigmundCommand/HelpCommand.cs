using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand
{
    public class HelpCommand : Command
    {
        public List<Command> Commands;


        public override void Execute(string[] args)
        {
            foreach (Command c in Commands) {
                c.PrintHelp();
            }
        }
    }
}
