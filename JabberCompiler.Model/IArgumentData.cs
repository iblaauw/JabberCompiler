using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IArgumentData
    {
        string Name { get; }
        IFunctionData Owner { get; }
        ITypeData Type { get; }
        Preposition AlternateAccess { get; }
    }
}
