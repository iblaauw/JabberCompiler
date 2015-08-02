using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model;

namespace JabberCompiler
{
    public class ArgumentData : IArgumentData
    {
        internal ArgumentData(string name, ITypeData type, IFunctionData owner) 
            : this(name, type, owner, Preposition.NONE)
        { }

        internal ArgumentData(string name, ITypeData type, IFunctionData owner, Preposition prep)
        {
            this.Name = name;
            this.Type = type;
            this.Owner = owner;
            this.AlternateAccess = prep;
        }

        public string Name { get; private set; }

        public IFunctionData Owner { get; private set; }

        public ITypeData Type { get; private set; }

        public Preposition AlternateAccess { get; private set; }
    }
}
