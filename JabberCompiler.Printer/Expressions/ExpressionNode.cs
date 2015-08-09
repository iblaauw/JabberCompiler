using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer.Expressions
{
    internal abstract class ExpressionNode : IExpressionNode
    {
        private List<IExpressionNode> children = new List<IExpressionNode>();

        public IReadOnlyList<IExpressionNode> Children
        {
            get { return children; }
        }

        public void Add(IExpressionNode node)
        {
            if (node == null)
                throw new ArgumentNullException();

            children.Add(node);
        }

        public void AddLeaf(string leaf)
        {
            Add(new ExpressionLeaf(leaf));
        }

        public string Print()
        {
            var childPrints = children.Select(n => n.Print());
            return PrintFromChildren(childPrints);
        }

        public abstract string PrintFromChildren(IEnumerable<string> childPrints);
    }
}
