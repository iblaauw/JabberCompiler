using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public enum StatementKind
    {
        Assignment,
        Constant,
        Declaration,
        FunctionCall,
        New,
        Operator,
        Variable
    }
}
