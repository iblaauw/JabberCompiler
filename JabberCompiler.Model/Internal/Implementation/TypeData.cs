using JabberCompiler.Model.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class TypeData : ITypeData
    {
        private List<IReadOnlyFunction> functions;
        private HashSet<string> funcNames;

        public TypeData(string name, IReadOnlyContext owningContext, bool isSingleton = false)
        {
            this.Name = name;
            this.IsSingleton = isSingleton;

            this.context = new ContextData(owningContext);

            functions = new List<IReadOnlyFunction>();
            funcNames = new HashSet<string>();
        }

        public string Name { get; private set; }

        public bool IsSingleton { get; private set; }

        public IReadOnlyList<IReadOnlyFunction> MemberFunctions
        {
            get { return functions; }
        }

        public FunctionData CreateFunction(string name, IReadOnlyType returnType)
        {
            if (funcNames.Contains(name))
                throw new InvalidOperationException("A function with the given name already exists.");

            FunctionData data = new FunctionData(name, this, returnType);
            this.functions.Add(data);
            this.funcNames.Add(name);
            return data;
        }

        private ContextData context;
        public IReadOnlyContext ClassContext { get { return context; } }
    }
}
