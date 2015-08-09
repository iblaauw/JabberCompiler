using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyArgument
    {
        string Name { get; }
        IReadOnlyFunction Owner { get; }
        IReadOnlyType Type { get; }
        Preposition AlternateAccess { get; }
    }
}
