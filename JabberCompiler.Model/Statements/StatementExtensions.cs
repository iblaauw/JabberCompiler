using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public static class StatementExtensions
    {
        public static IDeclaration AsDeclaration(this IReadOnlyStatement statement)
        {
            return DoCast<IDeclaration>(statement, StatementKind.Declaration);
        }

        public static IConstant AsConstant(this IReadOnlyStatement statement)
        {
            return DoCast<IConstant>(statement, StatementKind.Constant);
        }

        public static IGetVariableStatement AsVariable(this IReadOnlyStatement statement)
        {
            return DoCast<IGetVariableStatement>(statement, StatementKind.Variable);
        }

        public static IReadOnlyAssignment AsAssignment(this IReadOnlyStatement statement)
        {
            return DoCast<IReadOnlyAssignment>(statement, StatementKind.Assignment);
        }

        private static T DoCast<T>(IReadOnlyStatement statement, StatementKind kind)
        {
            if (statement == null)
                throw new NullReferenceException();

            if (statement.Kind != kind)
                throw new InvalidOperationException("Cannot convert the Statement: Statement is not a compatible statement type.");

            return (T)statement;
        }
    }
}
