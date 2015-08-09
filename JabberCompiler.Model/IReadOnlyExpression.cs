using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyExpression
    {
        Statements.IStatementData ComponentsHead { get; }
        IReadOnlyContext OwningContext { get; internal set; }
        IReadOnlyExpressionSet SubExpressions { get; }
    }
}
