using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Printer.Expressions;
using JabberCompiler.Model;

namespace JabberCompiler.Printer.Statements
{
    public class VariableDeclareStatement : IStatement
    {
        private SpacedExpressionNode head;

        public VariableDeclareStatement(ITypeData type, string name)
        {
            ExpressionLeaf leaf1 = new ExpressionLeaf(type.Name);
            ExpressionLeaf leaf2 = new ExpressionLeaf(type.Name);
            ExpressionLeaf leaf3 = new ExpressionLeaf(type.Name);



            head = new SpacedExpressionNode();

            var inner = new ConcatExpressionNode();
            
            head.AddLeaf(type.Name);
            head.Add(inner);

            inner.AddLeaf(name);
            inner.AddLeaf(";");
        }

        public IExpressionNode ExpressionTreeHead
        {
            get { return head; }
        }

        public bool StartsNewContext
        {
            get { return false; }
        }

        public IReadOnlyList<IStatement> SubStatements
        {
            get { return null; }
        }
    }
}
