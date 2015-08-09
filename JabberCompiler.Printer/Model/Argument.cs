using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class Argument
    {
        public Argument(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type + " " + Name;
        }
    }
}
