using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberCompiler.Model;
using JabberCompiler.Model.Mutable;

namespace JabberCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeData followerType = GlobalContext.Instance.CreateType("Follower");
            IFunctionData funcData = followerType.CreateFunction("Lead", TypeRegistration.Void);
            funcData.CreateArgument("numbSteps", TypeRegistration.Int);
            IFunctionData funcData2 = followerType.CreateFunction("Join", TypeRegistration.Bool);
            funcData2.CreateArgument("toReplace", followerType);

            Task task = JabberCompiler.Printer.Printer.PrintType(followerType);
            task.Wait();
        }
    }
}
