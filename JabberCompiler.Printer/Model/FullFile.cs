using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class FullFile
    {
        public string Name { get; set; }
        public IEnumerable<UsingStatement> Usings { get; set; }
        public Namespace NamespaceContained { get; set; }
    }
}
