using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyContext
    {
        IReadOnlyVariable GetByName(string name);

        bool ContainsVariable(string name);

        IReadOnlyType GetTypeByName(string name);

        bool ContainsType(string name);
    }
}
