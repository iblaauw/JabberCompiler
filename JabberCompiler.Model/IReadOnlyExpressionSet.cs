using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyExpressionSet
    {
        IReadOnlyList<IReadOnlyExpression> Expressions { get; }
        IReadOnlyContext AssociateContext { get; }
    }
}
