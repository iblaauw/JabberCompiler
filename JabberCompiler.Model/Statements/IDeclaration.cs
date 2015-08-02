using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public interface IDeclaration : IStatementData
    {
        string Name { get; }
        ITypeData Type { get; }
        bool IsAssigned { get; }
        IStatementData AssignmentValue { get; }
    }
}
