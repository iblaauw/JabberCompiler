using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public static class TypeRegistration
    {
        private static Dictionary<string, ITypeData> dataMapping;
        private static Predefined.VoidType predefVoid;
        private static Predefined.BooleanType predefBool;
        private static Predefined.IntegerType predefInt;

        static TypeRegistration()
        {
            dataMapping = new Dictionary<string, ITypeData>();
            GeneratePredefs();
        }

        public static ITypeData Void { get { return predefVoid; } }
        public static ITypeData Bool { get { return predefBool; } }
        public static ITypeData Int { get { return predefInt; } }

        public static ITypeData GetNamedType(string typeName)
        {
            return dataMapping[typeName];
        }

        internal static bool IsRegistered(string name)
        {
            return dataMapping.ContainsKey(name);
        }

        internal static void RegisterType(string name, ITypeData type)
        {
            dataMapping[name] = type;
        }

        private static void GeneratePredefs()
        {
            predefVoid = new Predefined.VoidType();
            predefBool = new Predefined.BooleanType();
            predefInt = new Predefined.IntegerType();

            RegisterType(predefVoid.Name, predefVoid);
            RegisterType(predefBool.Name, predefBool);
            RegisterType(predefInt.Name, predefInt);
        }
    }
}
