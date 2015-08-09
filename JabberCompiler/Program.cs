using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model;

namespace JabberCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeData typeData = new TypeData("Follower");
            FunctionData funcData = typeData.CreateFunction("Lead", TypeRegistration.Void);
            funcData.CreateArgument("numbSteps", TypeRegistration.Int);

            Task task = JabberCompiler.Printer.Printer.PrintType(typeData);
            task.Wait();
        }
    }
}
