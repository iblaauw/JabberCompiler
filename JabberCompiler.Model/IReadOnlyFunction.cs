using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyFunction
    {
        string Name { get; }
        IReadOnlyType Owner { get; }
        IReadOnlyType ReturnType { get; }
        IReadOnlyList<IReadOnlyArgument> AllArguments { get; }
        IReadOnlyDictionary<Preposition, IReadOnlyArgument> AlternateArguments { get; }
        IReadOnlyExpressionSet Expressions { get; }
        IReadOnlyContext FunctionContext { get; }
    }
}
