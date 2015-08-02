using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IFunctionData
    {
        string Name { get; }
        ITypeData Owner { get; }
        ITypeData ReturnType { get; }
        IReadOnlyList<IArgumentData> AllArguments { get; }
        IReadOnlyDictionary<Preposition, IArgumentData> AlternateArguments { get; }
        IExpressionSet Expressions { get; }
        IContext FunctionContext { get; }
    }
}
