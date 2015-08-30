using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model.Statements.Mutable;
using JabberCompiler.Model.Statements;

namespace JabberCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeData followerType = GlobalContext.Instance.AddType("Follower");
            IFunctionData funcData = followerType.CreateFunction("Lead", KnownTypes.Void);
            funcData.CreateArgument("numbSteps", KnownTypes.Int);
            IFunctionData funcData2 = followerType.CreateFunction("Join", KnownTypes.Bool);
            funcData2.CreateArgument("toReplace", followerType);

            IReadOnlyVariable doVariable;
            IExpression newExpression = funcData2.ExpressionsMutable.AddExpression();
            newExpression.SetAsDeclaration("doVariable", KnownTypes.Int, out doVariable);

            IExpression newExpression2 = funcData2.ExpressionsMutable.AddExpression();
            IAssignment assignment = newExpression2.SetAsAssignment(doVariable);
            var constant = ReturningStatement.CreateConstant(KnownTypes.Int, "5");
            assignment.SetValue(constant);

            IReadOnlyVariable itVariable;
            IExpression newExpression3 = funcData2.ExpressionsMutable.AddExpression();
            newExpression3.SetAsDeclaration("itVariable", KnownTypes.Int, out itVariable);

            IExpression newExpression4 = funcData2.ExpressionsMutable.AddExpression();
            IAssignment assignment2 = newExpression4.SetAsAssignment(itVariable);
            IGetVariableStatement getDoVar = ReturningStatement.CreateVariable(doVariable);
            assignment2.SetValue(getDoVar);

            Task task = JabberCompiler.Printer.Printer.PrintType(followerType);
            task.Wait();
        }
    }
}
