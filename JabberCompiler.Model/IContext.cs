using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IContext
    {
        IReadOnlyCollection<IVariable> Variables { get; }

        IVariable GetByName(string name);

        bool ContainsVariable(string name);
    }
}
