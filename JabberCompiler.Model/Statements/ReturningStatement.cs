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
            return new Internal.Implementation.Statements.Constant(type, value);
        }

        public static IGetVariableStatement CreateVariable(IReadOnlyVariable variable)
        {
            return new Internal.Implementation.Statements.GetVariable(variable);
        }
    }
}
