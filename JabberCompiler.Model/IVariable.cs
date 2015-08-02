using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IVariable
    {
        string Name { get; }
        IContext OwningContext { get; }
        ITypeData Type { get; }
    }
}
