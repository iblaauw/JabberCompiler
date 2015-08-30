using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;

namespace JabberCompiler.Test
{
    [TestClass]
    public class GlobalContextTests
    {
        GlobalContext context;

        [TestInitialize]
        public void Setup()
        {
            context = CreationUtilities.CreateGlobal();
        }

        [TestMethod]
        [TestCategory("GlobalContext")]
        public void GlobalNotNull()
        {
            Assert.IsNotNull(context);
        }

        [TestMethod]
        [TestCategory("GlobalContext")]
        public void GlobalNoChange()
        {
            GlobalContext context = GlobalContext.Instance;
            GlobalContext context2 = GlobalContext.Instance;
            Assert.ReferenceEquals(context, context2);
        }

        [TestMethod]
        public void GlobalAddVariable()
        {
            string name = "myTest";
            IReadOnlyType type = KnownTypes.Int;

            IReadOnlyVariable variable = context.AddVariable(name, type);

            Assert.IsNotNull(variable);
            Assert.AreEqual(variable.Name, name);
            Assert.ReferenceEquals(variable.OwningContext, context);
            Assert.ReferenceEquals(variable.Type, type);
            
            Assert.IsTrue(context.ContainsVariable(name));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GlobalDoubleAddVar()
        {
            string name = "myTest";

            context.AddVariable(name, KnownTypes.Int);
            context.AddVariable(name, KnownTypes.Bool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GlobalAddVarNull()
        {
            context.AddVariable(null, KnownTypes.Int);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GlobalAddVarNull2()
        {
            context.AddVariable("myTest", null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GlobalAddVarVoid()
        {
            context.AddVariable("myTest", KnownTypes.Void);
        }

        [TestMethod]
        [TestCategory("GlobalContext")]
        public void GlobalCanAddType()
        {
            string name = "test";

            ITypeData type = context.AddType(name);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, name);
            Assert.ReferenceEquals(type.ClassContext, context);

            Assert.IsTrue(context.ContainsType(name));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GlobalDoubleAddType()
        {
            string name = "test";

            context.AddType(name);
            context.AddType(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GlobalAddTypeNull()
        {
            context.AddType(null);
        }

        [TestMethod]
        public void GlobalClear()
        {
            string name1 = "myTest";
            string name2 = "myTest2";

            ITypeData type = context.AddType(name1);
            context.AddVariable(name2, type);

            GlobalContext.Clear();

            Assert.IsFalse(context.ContainsType(name1));
            Assert.IsFalse(context.ContainsVariable(name2));
        }
    }
}
