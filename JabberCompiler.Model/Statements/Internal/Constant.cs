using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements.Internal
{
    internal class Constant : IConstant
    {
        public Constant(IReadOnlyType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public IReadOnlyType Type { get; private set; }

        public string Value { get; private set; }
        
        public StatementKind Kind
        {
            get { return StatementKind.Constant; }
        }

        public IReadOnlyList<IReadOnlyStatement> SubStatements
        {
            get { return null; }
        }
    }
}
