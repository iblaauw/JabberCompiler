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

        [TestMethod]
        [TestCategory("Context")]
        public void ContextAddVariable()
        {
            string varName = "MyVariable";
            IReadOnlyType type = KnownTypes.Int;

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
            IReadOnlyType type = KnownTypes.Void;

            IReadOnlyVariable variable = context.AddVariable(varName, type);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [TestCategory("Context")]
        public void ContextDoubleAddVar()
        {
            string varName = "MyVariable";
            IReadOnlyType type = KnownTypes.Bool;
            IReadOnlyType type2 = KnownTypes.Int;

            context.AddVariable(varName, type);
            context.AddVariable(varName, type2);
        }

        [TestMethod]
        [TestCategory("Context")]
        public void ContextAfterAddVar()
        {
            string varName = "MyVariable";
            IReadOnlyType type = KnownTypes.Int;

            IReadOnlyVariable variable = context.AddVariable(varName, type);

            Assert.IsTrue(context.ContainsVariable(varName));
        }

        [TestMethod]
        public void ContextAddType()
        {
            string name = "Test";

            ITypeData type = context.AddType(name);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, name);
            Assert.ReferenceEquals(type.ClassContext, context);

            Assert.IsTrue(context.ContainsType(name));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ContextDoubleAddType()
        {
            string name = "Test";

            context.AddType(name);
            context.AddType(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContextAddNullType()
        {
            context.AddType(null);
        }

        [TestMethod]
        public void ContextStartsEmpty()
        {
            Assert.IsFalse(context.ContainsVariable("Test"));
            Assert.IsFalse(context.ContainsVariable("Test"));
        }
    }
}
