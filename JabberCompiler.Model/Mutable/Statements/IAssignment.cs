using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable.Statements
{
    public interface IAssignment : IReadOnlyAssignment
    {
        void SetValue(IReturningStatement statement);
    }
}
