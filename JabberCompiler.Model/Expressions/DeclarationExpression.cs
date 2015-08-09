using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Expressions
{
    public class DeclarationExpression : IReadOnlyExpression
    {
        private Statements.IDeclaration statement;

        public DeclarationExpression(Statements.IDeclaration declaration)
        {
            this.statement = declaration;
        }

        public IStatementData ComponentsHead
        {
            get { return statement; }
        }

        public IReadOnlyContext OwningContext { get; internal set; }

        public IReadOnlyExpressionSet SubExpressions
        {
            get { return null; }
        }
    }
}
