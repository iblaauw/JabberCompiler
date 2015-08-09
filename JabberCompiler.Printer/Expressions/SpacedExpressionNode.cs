using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Expressions
{
    /// <summary>
    /// A basic expression node that just puts spaces between its children
    /// </summary>
    internal class SpacedExpressionNode : ExpressionNode
    {
        public override string PrintFromChildren(IEnumerable<string> childPrints)
        {
            return String.Join(" ", childPrints);
        }
    }
}
