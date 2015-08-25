using JabberCompiler.Model.Internal.Implementation.Statements;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model.Mutable.Statements;
using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class Expression : IExpression
    {
        private IContextData owningContext;

        public Expression(IContextData context)
        {
            this.owningContext = context;
            this.ComponentsHead = null;
            this.SubExpressions = null;
        }

        public IAssignment SetAsAssignment(IReadOnlyVariable assignTo)
        {
            if (ComponentsHead != null)
                throw new InvalidOperationException("The expression has already been set! It cannot be set twice.");

            if (assignTo == null)
                throw new ArgumentNullException();

            //TODO: check that the context can access this variable...

            Assignment assignment = new Assignment(assignTo);
            this.ComponentsHead = assignment;

            return assignment;
        }

        public IDeclaration SetAsDeclaration(string variableName, IReadOnlyType type, out IReadOnlyVariable variableCreated)
        {
            if (ComponentsHead != null)
                throw new InvalidOperationException("The expression has already been set! It cannot be set twice.");

            if (variableName == null || type == null)
                throw new ArgumentNullException();

            if (owningContext.ContainsVariable(variableName))
                throw new InvalidOperationException("A variable with that name already exists!");

            variableCreated = owningContext.AddVariable(variableName, type);

            Declaration declaration = new Declaration(variableName, type);
            this.ComponentsHead = declaration;
            return declaration;
        }

        public IReadOnlyStatement ComponentsHead { get; private set; }

        public IReadOnlyContext OwningContext { get { return owningContext; } }

        public IReadOnlyExpressionSet SubExpressions { get; private set; }
    }
}
