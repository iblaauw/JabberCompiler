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
            Assert.IsNotNull(TypeRegistration.Int);
            Assert.IsNotNull(TypeRegistration.Bool);
            Assert.IsNotNull(TypeRegistration.Void);
        }

        [TestMethod]
        [TestCategory("KnownTypes")]
        public void KnownTypesNames()
        {
            Assert.AreEqual(TypeRegistration.Int.Name, "int");
            Assert.AreEqual(TypeRegistration.Bool.Name, "bool");
            Assert.AreEqual(TypeRegistration.Void.Name, "void");
        }

        [TestMethod]
        [TestCategory("KnownTypes")]
        public void KnownTypesVoidEmpty()
        {
            Assert.IsTrue(TypeRegistration.Void.MemberFunctions.IsNullOrEmpty());
        }
    }
}
