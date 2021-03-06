﻿using JabberCompiler.Model.Statements;
using JabberCompiler.Model.Statements.Mutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Mutable
{
    public interface IExpression : IReadOnlyExpression
    {
        IAssignment SetAsAssignment(IReadOnlyVariable assignTo);

        IDeclaration SetAsDeclaration(string variableName, IReadOnlyType type, 
            out IReadOnlyVariable variableCreated);
    }
}
