using System;

namespace SigmundCommand.Commands.Base
{
    public class CommandOption
    {
        public string Callname { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public string Alias { get; set; }

        public void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  --");
            Console.WriteLine(Callname + "("+ Type +") (Default:" + DefaultValue + ") " + Description);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  aliases: -" + Alias);
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}