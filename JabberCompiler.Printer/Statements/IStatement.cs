using JabberCompiler.Printer.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Model
{
    /// <summary>
    /// Represents a single statement, which can be made up of several IExpression fragments.
    /// A statement can also start a new operating context, which can have several statements inside of it
    /// </summary>
    public interface IStatement
    {
        IExpressionNode ExpressionTreeHead { get; }

        /// <summary>
        /// Whether the statement starts a new context
        /// </summary>
        bool StartsNewContext { get; }

        IReadOnlyList<IStatement> SubStatements { get; }
    }
}
