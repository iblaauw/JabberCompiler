using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model;
using JabberCompiler.Model.Statements.Mutable;
using JabberCompiler.Model.Statements;

namespace JabberCompiler.Test
{
    [TestClass]
    public class AssignmentTests
    {
        private IAssignment assignment;
        private IReadOnlyVariable variable1;
        private IReadOnlyVariable variable2;

        [TestInitialize]
        public void Setup()
        {
            IExpression expression = CreationUtilities.CreateExpression();
            variable1 = GlobalContext.Instance.AddVariable("MyVariable", KnownTypes.Int);
            assignment = expression.SetAsAssignment(variable1);

            variable2 = GlobalContext.Instance.AddVariable("MyVariable2", KnownTypes.Int);
        }

        [TestMethod]
        public void AssignmentBasics()
        {
            Assert.IsTrue(assignment.Kind == StatementKind.Assignment);
            Assert.ReferenceEquals(assignment.AssignedTo, variable1);
        }

        [TestMethod]
        public void AssignmentValue()
        {
            IConstant constant = ReturningStatement.CreateConstant(KnownTypes.Bool, "true");

            assignment.SetValue(constant);

            Assert.ReferenceEquals(assignment.AssignedValue, constant);
        }

        [TestMethod]
        public void AssignmentValue2()
        {
            IGetVariableStatement getVar = ReturningStatement.CreateVariable(variable2);

            assignment.SetValue(getVar);

            Assert.ReferenceEquals(assignment.AssignedValue, getVar);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AssignmentDoubleSet()
        {
            IConstant constant = ReturningStatement.CreateConstant(KnownTypes.Int, "5");
            IGetVariableStatement getVar = ReturningStatement.CreateVariable(variable2);

            assignment.SetValue(constant);
            assignment.SetValue(getVar);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssignmentSetNull()
        {
            assignment.SetValue(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AssignmentUnassignedSubstatements()
        {
            var xx = assignment.SubStatements;
        }
    }
}
