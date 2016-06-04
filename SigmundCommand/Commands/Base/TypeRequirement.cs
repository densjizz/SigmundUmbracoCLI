using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmundCommand.Commands.Base
{
    public class TypeRequirement<T> : Requirement
    {



        public override Argument Deserialize(string str)
        {
            if (typeof(T) == typeof(int))
            {
                Argument value = DeserializeInt(str);
                return value;
            }

            throw (new Exception("Argument " + Name + " cannot contain value : " + str));
        }

        private Argument DeserializeInt(string str)
        {
            int value = -1;
            if (int.TryParse(str, out value))
            {
                return new Argument() { Value = value};
            }

            throw new Exception("Cannot convert " + str + " into a 32bit signed integer");
        }

        public override string TypeAsString() {
            return typeof(T).ToString();
        }
    }
}
