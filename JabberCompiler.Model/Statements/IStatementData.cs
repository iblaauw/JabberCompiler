using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    /// <summary>
    /// A Statement is a small snippet that is understandable by the compiler.
    /// It is things like an assignment, a keyword, etc.
    /// An Expression is made up of a tree of statements
    /// </summary>
    public interface IStatementData
    {
        StatementKind Kind { get; }
        IReadOnlyExpression ParentExpression { get; }
        IStatementData ParentStatement { get; }
        IReadOnlyList<IStatementData> SubStatements { get; }
    }
}
