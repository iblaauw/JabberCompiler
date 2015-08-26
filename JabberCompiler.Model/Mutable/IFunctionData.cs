using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable
{
    public interface IFunctionData : IReadOnlyFunction
    {
        IReadOnlyArgument CreateArgument(string name, IReadOnlyType type);

        IReadOnlyArgument CreateAlternateArgument(string name, IReadOnlyType type, Preposition alternateAccess);

        IExpressionSet ExpressionsMutable { get; }
    }
}
