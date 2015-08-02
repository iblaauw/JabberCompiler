using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public interface IExpressionSet
    {
        IReadOnlyList<IExpressionData> Expressions { get; }
        IContext AssociateContext { get; }
    }
}
