using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model;
using JabberCompiler.Model.Statements.Mutable;
using JabberCompiler.Model.Statements;

namespace JabberCompiler.Test
{
    [TestClass]
    public class ExpressionTests
    {
        private IExpression expression;

        [TestInitialize]
        public void Setup()
        {
            expression = CreationUtilities.CreateExpression();
        }

        [TestMethod]
        public void ExpressionBasics()
        {
            Assert.IsNotNull(expression);
            Assert.IsNull(expression.SubExpressions);
            Assert.IsNotNull(expression.OwningContext);
            Assert.IsNull(expression.ComponentsHead);
        }

        [TestMethod]
        public void ExpressionSetAssignment()
        {
            IReadOnlyVariable variable = GlobalContext.Instance.AddVariable("Hello", KnownTypes.Int);

            IAssignment assignment = expression.SetAsAssignment(variable);

            Assert.IsNotNull(assignment);
            Assert.ReferenceEquals(expression.ComponentsHead, assignment);
            Assert.IsNull(expression.SubExpressions);
        }

        [TestMethod]
        public void ExpressionSetDeclaration()
        {
            string name = "MyVariable";
            IReadOnlyType type = KnownTypes.Int;

            IReadOnlyVariable variable;
            IDeclaration declaration = expression.SetAsDeclaration(name, type, out variable);

            Assert.ReferenceEquals(expression.ComponentsHead, declaration);
            Assert.IsNull(expression.SubExpressions);

            Assert.IsNotNull(declaration);
            Assert.ReferenceEquals(declaration.Type, type);
            Assert.AreEqual(declaration.Name, name, false);
            Assert.IsTrue(declaration.SubStatements.IsNullOrEmpty());

            Assert.IsNotNull(variable);
            Assert.AreEqual(variable.Name, name, false);
            Assert.ReferenceEquals(variable.OwningContext, expression.OwningContext);
            Assert.ReferenceEquals(variable.Type, type);
        }

        [TestMethod]
        public void ExpressionDeclarationContext()
        {
            string name = "MyVariable";
            IReadOnlyType type = KnownTypes.Int;

            IReadOnlyVariable variable;
            IDeclaration declaration = expression.SetAsDeclaration(name, type, out variable);

            Assert.IsTrue(expression.OwningContext.ContainsVariable(name));
            Assert.ReferenceEquals(expression.OwningContext.GetByName(name), variable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpressionAssignmentNull()
        {
            IAssignment assignment = expression.SetAsAssignment(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpressionDeclarationNull()
        {
            //string name = "MyVariable";
            IReadOnlyType type = KnownTypes.Int;

            IReadOnlyVariable variable;
            expression.SetAsDeclaration(null, type, out variable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpressionDeclarationNull2()
        {
            string name = "MyVariable";
            //IReadOnlyType type = TypeRegistration.Int;

            IReadOnlyVariable variable;
            expression.SetAsDeclaration(name, null, out variable);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExpressionDeclareVoid()
        {
            string name = "MyVariable";
            IReadOnlyType type = KnownTypes.Void;

            IReadOnlyVariable variable;
            expression.SetAsDeclaration(name, type, out variable);
        }
    }
}
