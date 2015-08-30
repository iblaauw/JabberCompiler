using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class VariableData : IReadOnlyVariable
    {
        internal VariableData(string name, IReadOnlyType type, IReadOnlyContext owner)
        {
            this.Name = name;
            this.Type = type;
            this.OwningContext = owner;
        }

        public string Name { get; private set; }

        public IReadOnlyContext OwningContext { get; private set; }

        public IReadOnlyType Type { get; private set; }
    }
}
