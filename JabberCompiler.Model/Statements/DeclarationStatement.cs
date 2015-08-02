using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    public class DeclarationStatement : IDeclaration
    {
        public string Name { get; private set; }

        public ITypeData Type { get; private set; }

        public bool IsAssigned { get; private set; }

        public IStatementData AssignmentValue { get; private set; }

        public StatementKind Kind { get; private set; }

        public IExpressionData ParentExpression { get; private set; }

        public IStatementData ParentStatement { get; private set; }

        public IReadOnlyList<IStatementData> SubStatements { get; private set; }
    }
}
