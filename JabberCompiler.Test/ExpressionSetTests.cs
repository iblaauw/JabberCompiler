using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JabberCompiler.Model.Mutable;

namespace JabberCompiler.Test
{
    [TestClass]
    public class ExpressionSetTests
    {
        private IExpressionSet set;

        [TestInitialize]
        public void Setup()
        {
            set = CreationUtilities.CreateExpressionSet();
        }

        [TestMethod]
        public void ExpressionSetBasics()
        {
            Assert.IsNotNull(set);
            Assert.ReferenceEquals(set.AssociateContext, set.AssociatedContextMutable);
            Assert.IsTrue(set.Expressions.IsNullOrEmpty());
        }

        [TestMethod]
        public void ExpressionSetAdd()
        {
            IExpression expression = set.AddExpression();

            Assert.IsNotNull(expression);
            Assert.ReferenceEquals(expression.OwningContext, set.AssociateContext);
        }
    }
}
