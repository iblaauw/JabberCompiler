using JabberCompiler.Model.Mutable.Statements;
using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation.Statements
{
    internal class Assignment : IAssignment
    {
        public Assignment(IReadOnlyVariable toVariable)
        {
            AssignedTo = toVariable;
        }

        public void SetValue(IReturningStatement statement)
        {
            this.AssignedValue = statement;
        }

        public IReadOnlyVariable AssignedTo { get; private set; }

        public IReturningStatement AssignedValue { get; private set; }

        public StatementKind Kind
        {
            get { return StatementKind.Assignment; }
        }

        public IReadOnlyList<IReadOnlyStatement> SubStatements
        {
            get 
            {
                if (AssignedValue == null)
                    throw new InvalidOperationException("The assignment has not been given a value...");

                return new List<IReadOnlyStatement>() { AssignedValue };
            }
        }
    }
}
