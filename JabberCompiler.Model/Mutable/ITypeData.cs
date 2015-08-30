using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable
{
    public interface ITypeData : IReadOnlyType
    {
        IFunctionData CreateFunction(string name, IReadOnlyType returnType);

        IContextData ClassContextMutable { get; }
    }
}
