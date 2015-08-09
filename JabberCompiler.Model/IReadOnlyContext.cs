using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyContext
    {
        IReadOnlyCollection<IReadOnlyVariable> Variables { get; }

        IReadOnlyVariable GetByName(string name);

        bool ContainsVariable(string name);
    }
}
