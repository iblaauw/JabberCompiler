using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public class GlobalContext : IReadOnlyContext
    {
        private static readonly GlobalContext instance = new GlobalContext();

        private Dictionary<string, VariableData> variables;

        private GlobalContext()
        {
            variables = new Dictionary<string, VariableData>();
        }

        public static GlobalContext GetInstance()
        {
            return instance;
        }

        public IReadOnlyCollection<IReadOnlyVariable> Variables
        {
            get { return variables.Values.ToList(); }
        }

        public IReadOnlyVariable GetByName(string name)
        {
            return variables[name];
        }

        public bool ContainsVariable(string name)
        {
            return variables.ContainsKey(name);
        }

        public void AddVariable(string name, IReadOnlyType type)
        {
            if (ContainsVariable(name))
                throw new InvalidOperationException("The variable already exists.");

            variables[name] = new VariableData(name, type, this);
        }
    }
}
