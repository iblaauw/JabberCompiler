using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model.Statements;
using JabberCompiler.Model.Implementation;

namespace JabberCompiler.Model.Expressions
{
    public class ExpressionData : IExpressionData
    {
        internal ExpressionData(ContextData owningContext, IStatementData statementHead)
        {
            //These should have been checked before calling this
            Debug.Assert(!KindUtilities.IsNeverRoot(statementHead.Kind));
            Debug.Assert(statementHead.ParentExpression == null);
            Debug.Assert(statementHead.ParentStatement == null);

            statementHead.ParentExpression = this;

            if (KindUtilities.CreatesContext(statementHead.Kind))
            {
                ContextData subContext = new ContextData(owningContext);
                SubSet = new ExpressionSet(subContext);
            }
        }

        public Statements.IStatementData ComponentsHead { get; private set; }

        public IContext OwningContext { get; private set; }

        public IExpressionSet SubExpressions
        {
            get { return SubSet; }
        }

        public ExpressionSet SubSet { get; private set; }

        private void DoStatementSpecific(IStatementData data, ContextData context)
        {
            StatementKind kind = data.Kind;
            if (kind == StatementKind.Declaration)
            {
                IDeclaration declaration = data as IDeclaration;

                if (declaration == null)
                    throw new InvalidOperationException("The given statement did not match its declared statement kind.");

                context.AddVariable(declaration.Name, declaration.Type);
            }
        }
    }
}
