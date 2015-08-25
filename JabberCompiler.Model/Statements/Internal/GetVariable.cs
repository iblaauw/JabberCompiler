using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements.Internal
{
    internal class GetVariable : IGetVariableStatement
    {
        public GetVariable(IReadOnlyVariable variable)
        {
            this.Variable = variable;
        }

        public IReadOnlyVariable Variable { get; private set; }

        public IReadOnlyType Type
        {
            get { return Variable.Type; }
        }

        public StatementKind Kind
        {
            get { return StatementKind.Variable; }
        }

        public IReadOnlyList<IReadOnlyStatement> SubStatements
        {
            get { return null; }
        }
    }
}
