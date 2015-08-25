using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IReadOnlyStatement
    {
        StatementKind Kind { get; }
        //IReadOnlyStatement ParentStatement { get; }
        IReadOnlyList<IReadOnlyStatement> SubStatements { get; }
    }
}
