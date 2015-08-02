using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public interface IFunctionCall : IStatementData
    {
        IFunctionData Function { get; }
        IReadOnlyList<IStatementData> ArgumentStatements { get; }
    }
}
