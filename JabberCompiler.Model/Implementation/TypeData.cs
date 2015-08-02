using JabberCompiler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler
{
    public class TypeData : ITypeData
    {
        private List<IFunctionData> functions;
        private HashSet<string> funcNames;

        public TypeData(string name, bool isSingleton = false)
        {
            this.Name = name;
            this.IsSingleton = isSingleton;

            //The context for a class is always inside of global context
            this.context = new ContextData(GlobalContext.GetInstance());

            functions = new List<IFunctionData>();
            funcNames = new HashSet<string>();

            TypeRegistration.RegisterType(name, this);
        }

        public string Name { get; private set; }

        public bool IsSingleton { get; private set; }

        public IReadOnlyList<IFunctionData> MemberFunctions
        {
            get { return functions; }
        }

        public FunctionData CreateFunction(string name, ITypeData returnType)
        {
            if (funcNames.Contains(name))
                throw new InvalidOperationException("A function with the given name already exists.");

            FunctionData data = new FunctionData(name, this, returnType);
            this.functions.Add(data);
            this.funcNames.Add(name);
            return data;
        }

        private ContextData context;
        public IContext ClassContext { get { return context; } }
    }
}
