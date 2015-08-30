using JabberCompiler.Model.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class ContextData : IContextData
    {
        private Dictionary<string, IReadOnlyVariable> variablesByName;
        private Dictionary<string, ITypeData> typesByName;
        private IReadOnlyContext parentContext;

        internal ContextData(IReadOnlyContext parentContext)
        {
            this.parentContext = parentContext;
            variablesByName = new Dictionary<string, IReadOnlyVariable>();
            typesByName = new Dictionary<string, ITypeData>();
        }

        public IReadOnlyVariable GetByName(string name)
        {
            if (SelfContains(name))
                return variablesByName[name];

            return parentContext.GetByName(name);
        }

        public bool ContainsVariable(string name)
        {
            if (SelfContains(name))
                return true;

            return parentContext.ContainsVariable(name);
        }

        public IReadOnlyVariable AddVariable(string name, IReadOnlyType type)
        {
            if (ContainsVariable(name))
                throw new InvalidOperationException("The variable already exists in this context.");

            VariableData data = new VariableData(name, type, this);
            variablesByName[name] = data;
            return data;
        }

        public bool ContainsType(string name)
        {
            if (typesByName.ContainsKey(name))
                return true;

            return parentContext.ContainsType(name);
        }

        public IReadOnlyType GetTypeByName(string name)
        {
            if (typesByName.ContainsKey(name))
                return typesByName[name];

            return parentContext.GetTypeByName(name);
        }

        public ITypeData AddType(string name)
        {
            if (ContainsType(name))
                throw new InvalidOperationException("The type already exists in this context.");

            ITypeData data = new TypeData(name, this);
            typesByName[name] = data;
            return data;
        }

        private bool SelfContains(string name)
        {
            return variablesByName.ContainsKey(name);
        }
    }
}
