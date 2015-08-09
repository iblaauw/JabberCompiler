using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class FunctionData : IFunctionData
    {
        private List<IReadOnlyArgument> arguments;
        private Dictionary<Preposition, IReadOnlyArgument> prepArgMap;
        private HashSet<string> argumentNames;

        internal FunctionData(string name, IReadOnlyType owner, IReadOnlyType returnType)
        {
            this.Name = name;
            this.Owner = owner;
            this.ReturnType = returnType;

            functionContext = new ContextData(owner.ClassContext);
            arguments = new List<IReadOnlyArgument>();
            prepArgMap = new Dictionary<Preposition, IReadOnlyArgument>();
            argumentNames = new HashSet<string>();
            expressions = new ExpressionSet(functionContext);
        }

        public string Name { get; private set; }

        public IReadOnlyType Owner { get; private set; }

        public IReadOnlyType ReturnType { get; private set; }

        public IReadOnlyList<IReadOnlyArgument> AllArguments
        {
            get { return arguments; }
        }

        public IReadOnlyDictionary<Preposition, IReadOnlyArgument> AlternateArguments
        {
            get { return prepArgMap; }
        }

        public IReadOnlyArgument CreateArgument(string name, IReadOnlyType type)
        {
            if (this.argumentNames.Contains(name))
                throw new InvalidOperationException("An argument with the given name already exists.");

            ArgumentData arg = new ArgumentData(name, type, this);
            this.arguments.Add(arg);
            this.argumentNames.Add(name);
            return arg;
        }

        public IReadOnlyArgument CreateAlternateArgument(string name, IReadOnlyType type, Preposition alternateAccess)
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
        public IReadOnlyContext FunctionContext
        {
            get { return functionContext; }
        }

        private ExpressionSet expressions;
        public IReadOnlyExpressionSet Expressions
        {
            get { return expressions; }
        }
    }
}
