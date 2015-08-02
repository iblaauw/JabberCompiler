using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class Function
    {
        public Function()
        {
            IsPublic = true;
            IsStatic = false;
        }

        public string Name { get; set; }
        public string ReturnType { get; set; }
        public IEnumerable<Argument> Arguments { get; set; }
        public string Contents { get; set; }

        public bool IsPublic { get; set; }

        public bool IsStatic { get; set; }

    }
}
