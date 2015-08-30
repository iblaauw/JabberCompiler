using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Model
{
    public static class KnownTypes
    {
        private static Dictionary<string, IReadOnlyType> dataMapping;
        private static Predefined.VoidType predefVoid;
        private static Predefined.BooleanType predefBool;
        private static Predefined.IntegerType predefInt;

        static KnownTypes()
        {
            dataMapping = new Dictionary<string, IReadOnlyType>();
            GeneratePredefs();
        }

        public static IReadOnlyType Void { get { return predefVoid; } }
        public static IReadOnlyType Bool { get { return predefBool; } }
        public static IReadOnlyType Int { get { return predefInt; } }

        private static void RegisterType(IReadOnlyType type)
        {
            dataMapping[type.Name] = type;
        }

        private static void GeneratePredefs()
        {
            predefVoid = new Predefined.VoidType();
            predefBool = new Predefined.BooleanType();
            predefInt = new Predefined.IntegerType();

            RegisterType(predefVoid);
            RegisterType(predefBool);
            RegisterType(predefInt);
        }
    }
}
