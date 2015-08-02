using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Expressions
{
    /// <summary>
    /// A node in the expression tree. An expression is a statement fragment
    /// </summary>
    public interface IExpressionNode
    {
        IReadOnlyList<IExpressionNode> Children { get; }

        string Print();
    }
}
