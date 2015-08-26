using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Printer.Model;
using System.Diagnostics;
using JabberCompiler.Model;

namespace JabberCompiler.Printer
{
    class PrinterBuilder
    {
        private int indentLevel = 0;
        private StringBuilder builder;

        public string PrintFullFile(FullFile file)
        {
            Debug.Assert(indentLevel == 0);
            builder = new StringBuilder();

            PrintUsings(file.Usings);
            builder.AppendLine();
            PrintNamespace(file.NamespaceContained);

            return builder.ToString();
        }

        private void PrintClass(IReadOnlyType type)
        {
            //TODO: make a static class and an internal class
            AppendFormatLine("public class {0}", type.Name);
            AppendLine("{");

            indentLevel++;
            foreach (IReadOnlyFunction function in type.MemberFunctions)
            {
                PrintFunction(function);
            }
            indentLevel--;
        }

        private void PrintFunction(IReadOnlyFunction function)
        {
            var argsAsStrings = function.AllArguments.Select(PrintArgument);
            string arguments = String.Join(", ", argsAsStrings);

            AppendFormatLine("public {0} {1}({4})", function.ReturnType.Name, function.Name, arguments);
            AppendLine("{");

            indentLevel++;
            foreach (IReadOnlyExpression expression in function.Expressions.Expressions)
            {
                PrintExpression(expression);
            }
            indentLevel--;

            AppendLine("}");
        }

        private string PrintArgument(IReadOnlyArgument argument)
        {
            return argument.Type.Name + " " + argument.Name;
        }

        private void PrintExpression(IReadOnlyExpression expression)
        {
            StatementPrinter sprinter = new StatementPrinter(expression.ComponentsHead);
            string result = sprinter.Print();
            AppendLine(result);

            if (expression.SubExpressions != null)
            {
                AppendLine("{");

                indentLevel++;
                foreach (IReadOnlyExpression exp in expression.SubExpressions.Expressions)
                {
                    PrintExpression(exp);
                }
                indentLevel--;

                AppendLine("}");
            }
        }

        private void PrintNamespace(Namespace nspace)
        {
            Debug.Assert(indentLevel == 0);

            AppendFormatLine("namespace {0}", nspace.Name);
            AppendLine("{");

            indentLevel++;
            PrintClass(nspace.InnerClass);
            indentLevel--;
            
            AppendLine("}");
        }

        private void PrintUsings(IEnumerable<UsingStatement> usings)
        {
            Debug.Assert(indentLevel == 0);
            foreach (UsingStatement statement in usings)
            {
                builder.AppendLine(statement.ToString());
            }
        }

        #region Append Functions

        private void Append(string item)
        {
            builder.Append(item);
        }

        private void AppendFormatLine(string format, params string[] args)
        {
            FixIndent();
            builder.AppendFormat(format, args);
            builder.AppendLine();
        }

        private void AppendLine(string item)
        {
            FixIndent();
            builder.AppendLine(item);
        }

        private void AppendLine()
        {
            builder.AppendLine();
        }

        #endregion

        private void FixIndent()
        {
            for (int i = 0; i < indentLevel; i++)
            {
                builder.Append("\t");
            }
        }

    }
}
