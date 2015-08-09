using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Statements
{
    internal static class KindUtilities
    {
        public static bool CreatesContext(StatementKind kind)
        {
            return false;
        }

        public static bool IsRootOnly(StatementKind kind)
        {
            return kind == StatementKind.Declaration || kind == StatementKind.Assignment;
        }

        public static bool IsNeverRoot(StatementKind kind)
        {
            return kind == StatementKind.Constant || kind == StatementKind.New || kind == StatementKind.Variable;
        }
    }
}
