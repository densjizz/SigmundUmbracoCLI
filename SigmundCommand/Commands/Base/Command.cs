using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand.Commands.Base
{
    public class Command
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public List<CommandOption> Options { get; set; }
        public List<Requirement> Requirements { get; set; }

        public Command() {
            Options = new List<CommandOption>();
            Requirements = new List<Requirement>();
            InitializeOptions();
            InitializeRequirements();
        }

        

        public void PrintHelp() {
            
            Console.Write("sig " + Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Requirement r in Requirements) {
                Console.Write(" <"+r.Name.ToLower()+"> ");
            }
            

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("<options...> \n\r");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Description);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("aliases: " + Alias);
            foreach (CommandOption o in Options) {
                o.PrintHelp();
            }
            Console.WriteLine("");
            Console.WriteLine("");
            
        }

        public virtual void InitializeOptions()
        {
            throw new NotImplementedException();
        }

        public virtual void InitializeRequirements()
        {
            throw new NotImplementedException();
        }

        public virtual void Execute(IEnumerable<string> args) {
            throw new NotImplementedException();
        }

        public virtual void Undo(IEnumerable<string> args) {
            throw new NotImplementedException();
        }

        public List<Argument> ExpectArguments(IEnumerable<string> args)
        {
            //TODO: same number of arguments then required or else throw exception
            var arguments = DeserializeArguments(args);

            
            return arguments;
        }

        private List<Argument> DeserializeArguments(IEnumerable<string> args)
        {
            List<Argument> arguments = new List<Argument>();
            int i = 0;
            Requirement requirement = null;
            string currentStr = null;
            try
            {
                for (i = 0; i < args.Count(); i++)
                {
                    currentStr = args.ElementAt(i);
                    if (StringIsNotOption(currentStr))
                    {
                        requirement = Requirements[i];
                        var argument = DeserializeArgument(currentStr, requirement);
                        arguments.Add(argument);
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                arguments = null;
                Console.WriteLine("unable to deserialize " + currentStr + " into " + requirement.TypeAsString());
            }

            return arguments;
        }

        private Argument DeserializeArgument(string str, Requirement requirement)
        {
            return requirement.Deserialize(str);
        }

        private bool StringIsNotOption(string str)
        {
            return !str.Contains("--");
        }

        private void ExpectArguments()
        {
            
        }

    }
}
