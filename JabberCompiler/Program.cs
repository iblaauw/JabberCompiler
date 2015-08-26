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
            ITypeData followerType = GlobalContext.Instance.CreateType("Follower");
            IFunctionData funcData = followerType.CreateFunction("Lead", TypeRegistration.Void);
            funcData.CreateArgument("numbSteps", TypeRegistration.Int);
            IFunctionData funcData2 = followerType.CreateFunction("Join", TypeRegistration.Bool);
            funcData2.CreateArgument("toReplace", followerType);

            IReadOnlyVariable doVariable;
            IExpression newExpression = funcData2.ExpressionsMutable.AddExpression();
            newExpression.SetAsDeclaration("doVariable", TypeRegistration.Int, out doVariable);

            IExpression newExpression2 = funcData2.ExpressionsMutable.AddExpression();
            IAssignment assignment = newExpression2.SetAsAssignment(doVariable);
            var constant = ReturningStatement.CreateConstant(TypeRegistration.Int, "5");
            assignment.SetValue(constant);

            IReadOnlyVariable itVariable;
            IExpression newExpression3 = funcData2.ExpressionsMutable.AddExpression();
            newExpression3.SetAsDeclaration("itVariable", TypeRegistration.Int, out itVariable);

            IExpression newExpression4 = funcData2.ExpressionsMutable.AddExpression();
            IAssignment assignment2 = newExpression4.SetAsAssignment(itVariable);
            IGetVariableStatement getDoVar = ReturningStatement.CreateVariable(doVariable);
            assignment2.SetValue(getDoVar);

            Task task = JabberCompiler.Printer.Printer.PrintType(followerType);
            task.Wait();
        }
    }
}
