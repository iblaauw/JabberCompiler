using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public interface IReadOnlyAssignment : IReadOnlyStatement
    {
        IReadOnlyVariable AssignedTo { get; }
        IReturningStatement AssignedValue { get; }
    }
}
