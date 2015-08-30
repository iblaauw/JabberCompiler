using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Statements;
using JabberCompiler.Model;

namespace JabberCompiler.Test
{
    [TestClass]
    public class ReturningStatementTests
    {
        [TestMethod]
        public void ReturningConstant()
        {
            IConstant constant = ReturningStatement.CreateConstant(KnownTypes.Int, "5");

            Assert.IsNotNull(constant);
            Assert.IsTrue(constant.Kind == StatementKind.Constant);
            Assert.IsTrue(constant.SubStatements.IsNullOrEmpty());
            Assert.ReferenceEquals(constant.Type, KnownTypes.Int);
            Assert.AreEqual(constant.Value, "5", false);
        }

        [TestMethod]
        public void ReturningGetVariable()
        {
            var context = CreationUtilities.CreateContext();
            IReadOnlyVariable variable = context.AddVariable("MyVariable", KnownTypes.Int);
            IGetVariableStatement getVar = ReturningStatement.CreateVariable(variable);

            Assert.IsNotNull(getVar);
            Assert.IsTrue(getVar.Kind == StatementKind.Variable);
            Assert.IsTrue(getVar.SubStatements.IsNullOrEmpty());
            Assert.ReferenceEquals(getVar.Type, KnownTypes.Int);
            Assert.ReferenceEquals(getVar.Variable, variable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturningConstNull()
        {
            ReturningStatement.CreateConstant(null, "5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturningConstNull2()
        {
            ReturningStatement.CreateConstant(KnownTypes.Int, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturningGetVarNull()
        {
            ReturningStatement.CreateVariable(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReturningConstVoid()
        {
            ReturningStatement.CreateConstant(KnownTypes.Void, "bleh");
        }
    }
}
