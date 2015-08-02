using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class Namespace
    {
        public string Name { get; set; }
        public Class InnerClass { get; set; }
    }
}
