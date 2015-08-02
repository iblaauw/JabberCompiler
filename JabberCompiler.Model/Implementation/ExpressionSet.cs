using JabberCompiler.Model.Expressions;
using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Implementation
{
    public class ExpressionSet : IExpressionSet
    {
        private List<IExpressionData> expressions;

        internal ExpressionSet(IContext associatedContext)
        {
            this.expressions = new List<IExpressionData>();
            AssociateContext = associatedContext;
        }

        public IReadOnlyList<IExpressionData> Expressions
        {
            get { return expressions; }
        }

        public IContext AssociateContext { get; private set; }

        public ExpressionData AddExpression(IStatementData statementHead)
        {
            ValidateStatementToAdd(statementHead);

            ExpressionData data = new ExpressionData(AssociateContext, statementHead);
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
