using JabberCompiler.Model.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public class GlobalContext : IContextData
    {
        private static readonly GlobalContext instance = new GlobalContext();

        private Dictionary<string, VariableData> variables;

        private Dictionary<string, ITypeData> typeData;

        private GlobalContext()
        {
            variables = new Dictionary<string, VariableData>();
            typeData = new Dictionary<string, ITypeData>();
        }

        public static GlobalContext Instance
        {
            get { return instance; }
        }
        
        public static void Clear()
        {
            instance.variables.Clear();
            instance.typeData.Clear();
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

        public IReadOnlyVariable AddVariable(string name, IReadOnlyType type)
        {
            if (ContainsVariable(name))
                throw new InvalidOperationException("The variable already exists.");

            var newVar = new VariableData(name, type, this);
            variables[name] = newVar;

            return newVar;
        }

        public ITypeData CreateType(string name)
        {
            Internal.Implementation.TypeData data = new Internal.Implementation.TypeData(name, this);
            this.typeData[name] = data;
            return data;
        }

        public ITypeData GetType(string name)
        {
            return this.typeData[name];
        }
    }
}
