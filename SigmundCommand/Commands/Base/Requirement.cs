using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand.Commands.Base
{
    public abstract class Requirement
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public virtual Argument Deserialize(string str)
        {
            throw new NotImplementedException();
        }

        public abstract string TypeAsString();
    }
}
