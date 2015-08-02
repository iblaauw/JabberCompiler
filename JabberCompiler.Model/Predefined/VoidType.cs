using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Predefined
{
    internal class VoidType : ITypeData
    {
        public string Name { get { return "void"; } }

        public bool IsSingleton { get { return false; } }

        public IReadOnlyList<IFunctionData> MemberFunctions { get { return null; } }
    }
}
