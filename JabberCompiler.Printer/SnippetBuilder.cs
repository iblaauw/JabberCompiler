using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer
{
    internal class SnippetBuilder
    {
        private static readonly List<string> defaultUsings = new List<string> { "System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Threading.Tasks" };

        public IReadOnlyList<string> DefaultUsingNamespaces { get { return defaultUsings.AsReadOnly(); } }

        public string GenerateFullFile(Model.FullFile file)
        {
            return file.ToString();
        }

        public string GenerateFullFile(string usings, string namespaceItems)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(usings);
            builder.AppendLine();
            builder.AppendLine(namespaceItems);
            return builder.ToString();
        }

        public string GenerateUsingStatements(IEnumerable<string> usingNamespaces)
        {
            StringBuilder builder = new StringBuilder();
            
            foreach (string usingName in usingNamespaces)
            {
                builder.AppendFormat("using {0};", usingName);
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public string GetDefaultUsingStatements()
        {
            return GenerateUsingStatements(DefaultUsingNamespaces);
        }

        public string GenerateNamespace(string namespaceName, string namespaceContents)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("namespace {0}", namespaceName);
            builder.AppendLine();
            builder.AppendLine("{");
            builder.AppendLine(namespaceContents);
            builder.AppendLine("}");
            return builder.ToString();
        }
        
        public string GenerateClass(string name, string classContents)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("public class {0}", name);
            builder.AppendLine();
            builder.AppendLine("{");
            builder.AppendLine(classContents);
            builder.AppendLine("}");
            return builder.ToString();
        }

        public string GenerateFunction(string name, string returnType, string arguments, string contents)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("public {0} {1}({2})", returnType, name, arguments);
            builder.AppendLine();
            builder.AppendLine("{");
            builder.AppendLine(contents);
            builder.AppendLine("}");
            return builder.ToString();
        }

        public string GenerateArguments(IEnumerable<ArgumentData> arguments)
        {
            StringBuilder argBuilder = new StringBuilder();

            bool first = true;
            foreach (ArgumentData arg in arguments)
            {
                if (first)
                    first = false;
                else
                    argBuilder.Append(", ");
                argBuilder.AppendFormat("{0} {1}", arg.Type, arg.Name);
            }

            return argBuilder.ToString();
        }

        public struct ArgumentData
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }
    }
}
