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

        public IExpression AddExpression()
        {
            Expression expression = new Expression(AssociatedContextMutable);
            expressions.Add(expression);

            return expression;
        }
    }
}
