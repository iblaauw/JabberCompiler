using JabberCompiler.Model;
using JabberCompiler.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler
{
    public class FunctionData : IFunctionData
    {
        private List<IArgumentData> arguments;
        private Dictionary<Preposition, IArgumentData> prepArgMap;
        private HashSet<string> argumentNames;

        internal FunctionData(string name, ITypeData owner, ITypeData returnType)
        {
            this.Name = name;
            this.Owner = owner;
            this.ReturnType = returnType;

            functionContext = new ContextData(owner.ClassContext);
            arguments = new List<IArgumentData>();
            prepArgMap = new Dictionary<Preposition, IArgumentData>();
            argumentNames = new HashSet<string>();
            expressions = new ExpressionSet(functionContext);
        }

        public string Name { get; private set; }

        public ITypeData Owner { get; private set; }

        public ITypeData ReturnType { get; private set; }

        public IReadOnlyList<IArgumentData> AllArguments
        {
            get { return arguments; }
        }

        public IReadOnlyDictionary<Preposition, IArgumentData> AlternateArguments
        {
            get { return prepArgMap; }
        }

        public ArgumentData CreateArgument(string name, ITypeData type)
        {
            if (this.argumentNames.Contains(name))
                throw new InvalidOperationException("An argument with the given name already exists.");

            ArgumentData arg = new ArgumentData(name, type, this);
            this.arguments.Add(arg);
            this.argumentNames.Add(name);
            return arg;
        }

        public ArgumentData CreateAlternateArgument(string name, ITypeData type, Preposition alternateAccess)
        {
            if (this.argumentNames.Contains(name))
                throw new InvalidOperationException("An argument with the given name already exists.");

            if (this.prepArgMap.ContainsKey(alternateAccess))
                throw new InvalidOperationException("An argument already exists with the given alternate access.");

            ArgumentData arg = new ArgumentData(name, type, this, alternateAccess);
            this.arguments.Add(arg);
            this.argumentNames.Add(name);
            this.prepArgMap[alternateAccess] = arg;
            return arg;
        }

        private ContextData functionContext;
        public IContext FunctionContext
        {
            get { return functionContext; }
        }

        private ExpressionSet expressions;
        public IExpressionSet Expressions
        {
            get { return expressions; }
        }
    }
}
