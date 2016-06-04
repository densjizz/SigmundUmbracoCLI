using SigmundCommand.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand
{
    public class Help : Command
    {
        public CommandController CmdController;


        public override void InitializeRequirements()
        {
            
        }

        public override void InitializeOptions()
        {
            
        }

        public override void Execute(IEnumerable<string> args)
        {
            foreach (Command c in CmdController.Commands) {
                c.PrintHelp();
            }
        }
    }
}
