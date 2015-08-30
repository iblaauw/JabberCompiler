using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model;

namespace JabberCompiler.Test
{
    [TestClass]
    public class KnownTypesTests
    {
        [TestMethod]
        [TestCategory("KnownTypes")]
        public void KnownTypesNotNull()
        {
            Assert.IsNotNull(KnownTypes.Int);
            Assert.IsNotNull(KnownTypes.Bool);
            Assert.IsNotNull(KnownTypes.Void);
        }

        [TestMethod]
        [TestCategory("KnownTypes")]
        public void KnownTypesNames()
        {
            Assert.AreEqual(KnownTypes.Int.Name, "int");
            Assert.AreEqual(KnownTypes.Bool.Name, "bool");
            Assert.AreEqual(KnownTypes.Void.Name, "void");
        }

        [TestMethod]
        [TestCategory("KnownTypes")]
        public void KnownTypesVoidEmpty()
        {
            Assert.IsTrue(KnownTypes.Void.MemberFunctions.IsNullOrEmpty());
        }
    }
}
