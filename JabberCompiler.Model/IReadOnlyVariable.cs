using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyVariable
    {
        string Name { get; }
        IReadOnlyContext OwningContext { get; }
        IReadOnlyType Type { get; }
    }
}
