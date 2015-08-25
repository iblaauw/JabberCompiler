using JabberCompiler.Model.Statements.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public static class ReturningStatement
    {
        public static IConstant CreateConstant(IReadOnlyType type, string value)
        {
            return new Constant(type, value);
        }

        public static IGetVariableStatement CreateVariable(IReadOnlyVariable variable)
        {
            return new GetVariable(variable);
        }
    }
}
