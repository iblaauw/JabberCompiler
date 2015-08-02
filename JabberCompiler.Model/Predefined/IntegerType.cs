﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model.Predefined
{
    internal class IntegerType : ITypeData
    {
        public string Name { get { return "int"; } }


        public bool IsSingleton { get { return false; } }


        public IReadOnlyList<IFunctionData> MemberFunctions { get { return null; } }
        
    }
}
