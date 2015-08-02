using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface ITypeData
    {
        string Name { get; }
        bool IsSingleton { get; }
        IReadOnlyList<IFunctionData> MemberFunctions { get; }
        IContext ClassContext { get; }
    }
}
