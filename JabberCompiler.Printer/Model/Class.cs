using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class Class
    {
        public string Name { get; set; }
        public IEnumerable<Function> Functions { get; set; }

        public bool IsStatic { get; set; }
    }
}
