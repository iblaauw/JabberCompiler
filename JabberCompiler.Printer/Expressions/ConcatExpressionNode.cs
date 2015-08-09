using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Expressions
{
    internal class ConcatExpressionNode : ExpressionNode
    {
        public override string PrintFromChildren(IEnumerable<string> childPrints)
        {
            return String.Join(String.Empty, childPrints);
        }
    }
}
