using JabberCompiler.Model.Expressions;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class ExpressionSet : IExpressionSet
    {
        private List<IReadOnlyExpression> expressions;

        internal ExpressionSet(IContextData associatedContext)
        {
            this.expressions = new List<IReadOnlyExpression>();
            AssociatedContextMutable = associatedContext;
        }

        public IReadOnlyList<IReadOnlyExpression> Expressions
        {
            get { return expressions; }
        }

        IReadOnlyContext IReadOnlyExpressionSet.AssociateContext 
        { 
            get { return AssociatedContextMutable; }
        }

        public IContextData AssociatedContextMutable { get; private set; }

        public IReadOnlyExpression AddExpression(IStatementData statementHead)
        {
            ValidateStatementToAdd(statementHead);

            ExpressionData data = new ExpressionData(AssociatedContextMutable, statementHead);
            expressions.Add(data);

            return data;
        }

        private void ValidateStatementToAdd(IStatementData statementHead)
        {
            if (KindUtilities.IsNeverRoot(statementHead.Kind))
            {
                throw new InvalidOperationException("The statement cannot be used as a stand-alone expression.");
            }

            if (statementHead.ParentExpression != null)
            {
                throw new InvalidOperationException("The statement is already part of a different expression.");
            }

            if (statementHead.ParentStatement != null)
            {
                throw new InvalidOperationException("The statement is not the root of its tree.");
            }
        }
    }
}
