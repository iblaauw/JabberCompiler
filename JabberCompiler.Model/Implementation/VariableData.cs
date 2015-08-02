using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    internal class VariableData : IVariable
    {
        internal VariableData(string name, ITypeData type, IContext owner)
        {
            this.Name = name;
            this.Type = type;
            this.OwningContext = owner;
        }

        public string Name { get; private set; }

        public IContext OwningContext { get; private set; }

        public ITypeData Type { get; private set; }
    }
}
