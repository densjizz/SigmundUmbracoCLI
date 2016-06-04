using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmundCommand.Commands.Base;

namespace SigmundCommand.Commands
{
    public class Multiply : Command
    {



        public override void InitializeRequirements()
        {
            Requirements.AddRange(
                new Requirement[]{
                    new TypeRequirement<int> { Name = "First Number" },
                    new TypeRequirement<int> { Name = "Second Number" }
                }
            );
        }

        public override void InitializeOptions()
        {
            
        }

        public override void Execute(IEnumerable<string> args)
        {
            List<Argument> passedArguments = ExpectArguments(args);
            if (passedArguments != null) {
                var result = (int)passedArguments[0].Value * (int)passedArguments[1].Value;
                Console.WriteLine(passedArguments[0].Value + "*" + passedArguments[0].Value + "=" + result);
            }
            
        }

        public override void Undo(IEnumerable<string> args)
        {
            base.Undo(args);
        }

        

    }
}
