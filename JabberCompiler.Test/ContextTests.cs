using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Test
{
    [TestClass]
    public class ContextTests
    {
        private IContextData context;

        [TestInitialize]
        public void Setup()
        {
            context = CreationUtilities.CreateContext();
        }

        /*[TestMethod]
        public void ContextAddType()
        {
            string name = "Test";

            ITypeData type = context.CreateType(name);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, name);
            Assert.ReferenceEquals(type.ClassContext, context);
        }*/

        [TestMethod]
        [TestCategory("Context")]
        public void ContextAddVariable()
        {
            string varName = "MyVariable";
            IReadOnlyType type = TypeRegistration.Int;

            IReadOnlyVariable variable = context.AddVariable(varName, type);

            Assert.IsNotNull(variable);
            Assert.AreEqual(variable.Name, varName, false);
            Assert.ReferenceEquals(variable.OwningContext, context);
            Assert.ReferenceEquals(variable.Type, type);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [TestCategory("Context")]
        public void ContextAddVoidVar()
        {
            string varName = "MyVariable";
            IReadOnlyType type = TypeRegistration.Void;

            IReadOnlyVariable variable = context.AddVariable(varName, type);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [TestCategory("Context")]
        public void ContextDoubleAddVar()
        {
            string varName = "MyVariable";
            IReadOnlyType type = TypeRegistration.Bool;
            IReadOnlyType type2 = TypeRegistration.Int;

            context.AddVariable(varName, type);
            context.AddVariable(varName, type2);
        }

        [TestMethod]
        [TestCategory("Context")]
        public void ContextAfterAddVar()
        {
            string varName = "MyVariable";
            IReadOnlyType type = TypeRegistration.Int;

            IReadOnlyVariable variable = context.AddVariable(varName, type);

            Assert.IsFalse(context.Variables.IsNullOrEmpty());
            Assert.IsTrue(context.ContainsVariable(varName));
        }
    }
}
