using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public static class TypeRegistration
    {
        private static Dictionary<string, IReadOnlyType> dataMapping;
        private static Predefined.VoidType predefVoid;
        private static Predefined.BooleanType predefBool;
        private static Predefined.IntegerType predefInt;

        static TypeRegistration()
        {
            dataMapping = new Dictionary<string, IReadOnlyType>();
            GeneratePredefs();
        }

        public static IReadOnlyType Void { get { return predefVoid; } }
        public static IReadOnlyType Bool { get { return predefBool; } }
        public static IReadOnlyType Int { get { return predefInt; } }

        public static IReadOnlyType GetNamedType(string typeName)
        {
            return dataMapping[typeName];
        }

        internal static bool IsRegistered(string name)
        {
            return dataMapping.ContainsKey(name);
        }

        internal static void RegisterType(string name, IReadOnlyType type)
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
