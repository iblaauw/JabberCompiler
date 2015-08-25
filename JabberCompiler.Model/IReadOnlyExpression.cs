using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyExpression
    {
        IReadOnlyStatement ComponentsHead { get; }
        IReadOnlyContext OwningContext { get; }
        IReadOnlyExpressionSet SubExpressions { get; }
    }
}
