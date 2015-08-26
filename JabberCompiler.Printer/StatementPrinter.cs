using JabberCompiler.Model;
using JabberCompiler.Model.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer
{
    class StatementPrinter
    {
        IReadOnlyStatement root;
        StringBuilder builder;

        public StatementPrinter(IReadOnlyStatement statementRoot)
        {
            this.root = statementRoot;
            builder = new StringBuilder();
        }

        public string Print()
        {
            PrintStatementNode(root);
            builder.Append(";");
            return builder.ToString();
        }

        private void PrintStatementNode(IReadOnlyStatement node)
        {
            switch (node.Kind)
            {
                case StatementKind.Assignment:
                    PrintAssignment(node.AsAssignment());
                    break;
                case StatementKind.Constant:
                    PrintConstant(node.AsConstant());
                    break;
                case StatementKind.Declaration:
                    PrintDeclaration(node.AsDeclaration());
                    break;
                case StatementKind.Variable:
                    PrintVariable(node.AsVariable());
                    break;
            }
        }

        private void PrintAssignment(IReadOnlyAssignment assignment)
        {
            builder.Append(assignment.AssignedTo.Name);
            builder.Append(" = ");
            PrintStatementNode(assignment.AssignedValue);
        }

        private void PrintDeclaration(IDeclaration declaration)
        {
            builder.Append(declaration.Type.Name);
            builder.Append(" ");
            builder.Append(declaration.Name);
        }

        private void PrintConstant(IConstant constant)
        {
            builder.Append(constant.Value);
        }

        private void PrintVariable(IGetVariableStatement variable)
        {
            builder.Append(variable.Variable.Name);
        }
    }
}
