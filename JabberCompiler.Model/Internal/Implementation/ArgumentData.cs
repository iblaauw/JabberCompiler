using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model;

namespace JabberCompiler.Model.Internal.Implementation
{
    internal class ArgumentData : IReadOnlyArgument
    {
        internal ArgumentData(string name, IReadOnlyType type, IReadOnlyFunction owner) 
            : this(name, type, owner, Preposition.NONE)
        { }

        internal ArgumentData(string name, IReadOnlyType type, IReadOnlyFunction owner, Preposition prep)
        {
            this.Name = name;
            this.Type = type;
            this.Owner = owner;
            this.AlternateAccess = prep;
        }

        public string Name { get; private set; }

        public IReadOnlyFunction Owner { get; private set; }

        public IReadOnlyType Type { get; private set; }

        public Preposition AlternateAccess { get; private set; }
    }
}
