using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements.Internal
{
    internal class Declaration : IDeclaration
    {
        public Declaration(string variableName, IReadOnlyType type)
        {
            this.Name = variableName;
            this.Type = type;
        }

        public string Name { get; private set; }

        public IReadOnlyType Type { get; private set; }

        public StatementKind Kind 
        {
            get { return StatementKind.Declaration; }
        }

        public IReadOnlyList<IReadOnlyStatement> SubStatements { get { return null; } }
    }
}
