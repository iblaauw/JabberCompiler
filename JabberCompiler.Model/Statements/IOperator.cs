using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public interface IOperator : IStatementData
    {
        ITypeData ReturnType { get; }
        IStatementData LeftSide { get; }
        IStatementData RightSide { get; }
    }
}
