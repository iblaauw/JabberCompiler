using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable
{
    public interface IContextData : IReadOnlyContext
    {
        IReadOnlyVariable AddVariable(string name, IReadOnlyType type);
        ITypeData AddType(string name);
    }
}
