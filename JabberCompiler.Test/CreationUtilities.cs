using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Test
{
    internal static class CreationUtilities
    {
        public static IContextData CreateContext()
        {
            GlobalContext.Clear();
            return GlobalContext.Instance;
        }

        public static ITypeData CreateType()
        {
            GlobalContext.Clear();
            return GlobalContext.Instance.CreateType("MyType");
        }

        public static IFunctionData CreateFunction()
        {
            return CreateFunction(TypeRegistration.Int);
        }

        public static IFunctionData CreateFunction(IReadOnlyType returnType)
        {
            return CreateType().CreateFunction("MyFunc", returnType);
        }

        public static IExpressionSet CreateExpressionSet()
        {
            return CreateFunction().ExpressionsMutable;
        }

        public static IExpression CreateExpression()
        {
            return CreateExpressionSet().AddExpression();
        }
    }
}
