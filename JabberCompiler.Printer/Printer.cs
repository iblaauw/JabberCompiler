using JabberCompiler.Printer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberCompiler.Printer
{
    public static class Printer
    {
        public const string OUTPUT_DIRECTORY = "JabberOutput";
        
        private static readonly string outputDirPath;

        static Printer()
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            outputDirPath = Path.Combine(myDocs, OUTPUT_DIRECTORY);
        }

        public static Task PrintType(JabberCompiler.Model.ITypeData typeData)
        {
            FullFile fullFile = Composer.CreateFileForType(typeData);

            PrinterBuilder builder = new PrinterBuilder();
            string fileContents = builder.PrintFullFile(fullFile);

            return PrintToFile(fullFile.Name, fileContents);
        }

        public static Task PrintToFile(string fileName, string contents)
        {
            if (!Directory.Exists(outputDirPath))
            {
                Directory.CreateDirectory(outputDirPath);
            }
            string path = Path.Combine(outputDirPath, fileName);
            return Task.Run(() => File.WriteAllText(path, contents));
        }
    }
}
