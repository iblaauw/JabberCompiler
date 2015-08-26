using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Mutable;
using JabberCompiler.Model;

namespace JabberCompiler.Test
{
    [TestClass]
    public class FunctionTests
    {
        private IFunctionData function;

        [TestInitialize]
        public void Setup()
        {
            function = CreationUtilities.CreateFunction();
        }

        [TestMethod]
        [TestCategory("Function")]
        public void FunctionAddArgument()
        {
            string name = "Hello";
            IReadOnlyType type = TypeRegistration.Bool;


            IReadOnlyArgument arg = function.CreateArgument(name, type);

            Assert.AreEqual(arg.Name, name, false);
            Assert.ReferenceEquals(arg.Owner, function);
            Assert.ReferenceEquals(arg.Type, type);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [TestCategory("Function")]
        public void FunctionAddVoidArgument()
        {
            string name = "Hello";
            function.CreateArgument(name, TypeRegistration.Void);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [TestCategory("Function")]
        public void FunctionAddArgumentTwice()
        {
            string name = "Hello";
            function.CreateArgument(name, TypeRegistration.Bool);

            function.CreateArgument(name, TypeRegistration.Int);
        }
    }
}
