using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IExpressionData
    {
        Statements.IStatementData ComponentsHead { get; }
        IContext OwningContext { get; internal set; }
        IExpressionSet SubExpressions { get; }
    }
}
