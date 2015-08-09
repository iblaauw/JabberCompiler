﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Printer.Model;

namespace JabberCompiler.Printer
{
    public static class Composer
    {
        private const string NAMESPACE_START = "Jabber";
        private const string DEFAULT_PROJECT_NAME = "Test";

        public static void PrintDefaultMain(string projectName)
        {
            string mainContents = "//hello world";
            List<Argument> mainArgs = new List<Argument>() { new Argument("args", "string[]") };
            Function func = new Function() { Name = "Main", ReturnType = "void", IsStatic = true, 
                Contents = mainContents, Arguments = mainArgs, IsPublic = true };
            Class mainClass = new Class() { Name = "Program", IsStatic = true, Functions = new[] { func } };
            Namespace nspace = new Namespace() { Name = "Jabber." + projectName, InnerClass = mainClass };
            FullFile file = new FullFile() { Name = "JabberMain.cs", NamespaceContained = nspace, Usings = UsingStatement.DefaultUsings };

            PrinterBuilder builder = new PrinterBuilder();
            string fullContents = builder.PrintFullFile(file);

            Task printTask = Printer.PrintToFile("JabberMain.cs", fullContents);
            printTask.Wait();
        }

        internal static FullFile CreateFileForType(JabberCompiler.Model.IReadOnlyType type)
        {
            if (type.IsSingleton)
                throw new NotImplementedException();

            string fileName = System.IO.Path.ChangeExtension(type.Name, "cs");
            FullFile file = new FullFile() { Name = fileName, Usings = UsingStatement.DefaultUsings };
            
            Namespace nspace = GetNamespace(DEFAULT_PROJECT_NAME);
            file.NamespaceContained = nspace;

            Class newClass = new Class() { Name = type.Name, IsStatic = false };
            nspace.InnerClass = newClass;

            newClass.Functions = type.MemberFunctions.Select(ConvertFunction).ToList();

            return file;
        }

        private static Function ConvertFunction(JabberCompiler.Model.IReadOnlyFunction function)
        {
            Function value = new Function() {
                IsPublic = true,
                IsStatic = false,
                Name = function.Name,
                ReturnType = function.ReturnType.Name,
                Contents = "throw new NotImplementedException();"
            };

            value.Arguments = function.AllArguments.Select(ConvertArgument).ToList();

            return value;
        }

        private static Argument ConvertArgument(JabberCompiler.Model.IReadOnlyArgument argument)
        {
            return new Argument(argument.Name, argument.Type.Name);
        }

        private static Namespace GetNamespace(string projectName)
        {
            string fullNamespace = NAMESPACE_START + "." + projectName;
            return new Namespace() { Name = fullNamespace };
        }

    }
}
