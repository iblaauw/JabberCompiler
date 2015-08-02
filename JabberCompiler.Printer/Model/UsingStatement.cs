using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    public class UsingStatement
    {
        private static readonly List<string> defaultUsingsNames = new List<string> { "System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Threading.Tasks" };

        public static readonly IEnumerable<UsingStatement> DefaultUsings = defaultUsingsNames.Select(n => new UsingStatement(n)).ToList();

        public UsingStatement(string nspace)
        {
            this.Namespace = nspace;
        }

        public string Namespace { get; set; }

        public override string ToString()
        {
            return String.Format("using {0};", Namespace);
        }
    }
}
