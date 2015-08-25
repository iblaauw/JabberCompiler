using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public interface IDeclaration : IReadOnlyStatement
    {
        string Name { get; }
        IReadOnlyType Type { get; }
        //bool IsAssigned { get; }
        //IStatementData AssignmentValue { get; }
    }
}
