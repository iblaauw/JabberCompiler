using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model.Statements;
using JabberCompiler.Model;

namespace JabberCompiler.Test
{
    [TestClass]
    public class DeclarationTests
    {
        private const string VarName = "MyVariable";

        private IExpression expression;

        private IDeclaration declaration;
        private IReadOnlyVariable createdVar;
        private IReadOnlyType type;

        [TestInitialize]
        public void Setup()
        {
            type = KnownTypes.Int;
            expression = CreationUtilities.CreateExpression();
            declaration = expression.SetAsDeclaration(VarName, type, out createdVar);
        }

        [TestMethod]
        public void DeclarationBasics()
        {
            Assert.IsNotNull(declaration);
            Assert.IsTrue(declaration.Kind == StatementKind.Declaration);
            Assert.AreEqual(declaration.Name, VarName, false);
            Assert.IsTrue(declaration.SubStatements.IsNullOrEmpty());
            Assert.ReferenceEquals(declaration.Type, type);
        }

        [TestMethod]
        public void DeclarationVariable()
        {
            Assert.IsNotNull(createdVar);
            Assert.AreEqual(createdVar.Name, VarName, false);
            Assert.ReferenceEquals(createdVar.Type, type);
        }

        [TestMethod]
        public void DeclarationVarContext()
        {
            Assert.ReferenceEquals(createdVar.OwningContext, expression.OwningContext);
            Assert.IsTrue(expression.OwningContext.ContainsVariable(VarName));
            Assert.ReferenceEquals(expression.OwningContext.GetByName(VarName), createdVar);
        }
    }
}
