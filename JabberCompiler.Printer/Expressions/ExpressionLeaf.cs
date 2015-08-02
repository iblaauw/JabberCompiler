using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Expressions
{
    internal class ExpressionLeaf : IExpressionNode
    {
        private string item;
        
        public ExpressionLeaf(string item)
        {
            this.item = item;
        }

        public IReadOnlyList<IExpressionNode> Children
        {
            get { return null; }
        }

        public string Print()
        {
            return item;
        }

    }
}
