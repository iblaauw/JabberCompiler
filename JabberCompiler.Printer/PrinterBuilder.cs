using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Printer.Model;
using System.Diagnostics;

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

        private void PrintClass(Class classToPrint)
        {
            string isStatic = classToPrint.IsStatic ? "static " : String.Empty;
            AppendFormatLine("public {0}class {1}", isStatic, classToPrint.Name);
            AppendLine("{");

            indentLevel++;
            foreach (Function func in classToPrint.Functions)
            {
                PrintFunction(func);
            }
            indentLevel--;

            AppendLine("}");
        }

        private void PrintFunction(Function function)
        {
            string arguments = String.Join(", ", function.Arguments);
            string scope = function.IsPublic ? "public" : "private";
            string isStatic = function.IsStatic ? "static " : String.Empty;
            AppendFormatLine("{0} {1}{2} {3}({4})", scope, isStatic, function.ReturnType, function.Name, arguments);
            AppendLine("{");

            indentLevel++;
            AppendLine(function.Contents);
            indentLevel--;
            
            AppendLine("}");
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
