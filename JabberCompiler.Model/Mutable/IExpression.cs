using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable
{
    public interface IExpression : IReadOnlyExpression
    {
        Mutable.Statements.IAssignment SetAsAssignment(IReadOnlyVariable assignTo);

        JabberCompiler.Model.Statements.IDeclaration SetAsDeclaration(string variableName, IReadOnlyType type, 
            out IReadOnlyVariable variableCreated);
    }
}
