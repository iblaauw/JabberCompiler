using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public class ContextData : IContext
    {
        private Dictionary<string, IVariable> variablesByName;
        private IContext parentContext;

        internal ContextData(IContext parentContext)
        {
            variablesByName = new Dictionary<string, IVariable>();
        }


        public IReadOnlyCollection<IVariable> Variables
        {
            get { throw new NotImplementedException(); }
        }

        public IVariable GetByName(string name)
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

        public void AddVariable(string name, ITypeData type)
        {
            if (ContainsVariable(name))
                throw new InvalidOperationException("The variable already exists in this context.");

            VariableData data = new VariableData(name, type, this);
            variablesByName[name] = data;
        }

        private bool SelfContains(string name)
        {
            return variablesByName.ContainsKey(name);
        }
    }
}
