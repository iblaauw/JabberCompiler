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
        private IReadOnlyContext parentContext;

        internal ContextData(IReadOnlyContext parentContext)
        {
            this.parentContext = parentContext;
            variablesByName = new Dictionary<string, IReadOnlyVariable>();
        }


        public IReadOnlyCollection<IReadOnlyVariable> Variables
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyVariable GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool ContainsVariable(string name)
        {
            if (parentContext.ContainsVariable(name))
                return true;

            if (SelfContains(name))
                return true;

            return false;
        }

        public IReadOnlyVariable AddVariable(string name, IReadOnlyType type)
        {
            if (ContainsVariable(name))
                throw new InvalidOperationException("The variable already exists in this context.");

            VariableData data = new VariableData(name, type, this);
            variablesByName[name] = data;
            return data;
        }

        private bool SelfContains(string name)
        {
            return variablesByName.ContainsKey(name);
        }
    }
}
