using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;

namespace JabberCompiler.Test
{
    [TestClass]
    public class GlobalContextTests
    {
        [TestMethod]
        [TestCategory("GlobalContext")]
        public void GlobalNotNull()
        {
            GlobalContext context = GlobalContext.Instance;
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
        [TestCategory("GlobalContext")]
        public void GlobalCanAddType()
        {
            string name = "test";
            GlobalContext context = GlobalContext.Instance;

            ITypeData type = context.CreateType(name);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, name);
            Assert.ReferenceEquals(type.ClassContext, context);
        }

    }
}
