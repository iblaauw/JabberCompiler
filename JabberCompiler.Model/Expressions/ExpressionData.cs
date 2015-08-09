using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model.Statements;
using JabberCompiler.Model.Internal.Implementation;
using JabberCompiler.Model.Mutable;

//TODO NEXT: Take the current model configuration (which is a mess) and split it into 
//      a bunch of IReadOnlyXXX and IXXX. So an IReadOnlyContext, an IContext, and an internal Context for backing.

namespace JabberCompiler.Model.Expressions
{
    public class ExpressionData : IReadOnlyExpression
    {
        internal ExpressionData(IReadOnlyContext owningContext, IStatementData statementHead)
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

        public IReadOnlyContext OwningContext { get; private set; }

        public IReadOnlyExpressionSet SubExpressions
        {
            get { return SubSet; }
        }

        public IExpressionSet SubSet { get; private set; }

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
