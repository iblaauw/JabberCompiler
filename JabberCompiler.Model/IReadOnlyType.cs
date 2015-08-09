using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyType
    {
        string Name { get; }
        bool IsSingleton { get; }
        IReadOnlyList<IReadOnlyFunction> MemberFunctions { get; }
        IReadOnlyContext ClassContext { get; }
    }
}
