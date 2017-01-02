using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadWrite;
using System.IO;

namespace ScaffoldFromExcel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!File.Exists(AppContext.BaseDirectory + @"\input.xlsx"))
            {
                Console.WriteLine("You must place valid 'input.xlsx' file in program directory");
                Console.Read();
                return;
            }

            var reader = new ExcelReader(AppContext.BaseDirectory + @"\input.xlsx");
            var modelList = reader.GetModelList();
            var writer = new Writer(modelList);

            if (Directory.Exists(AppContext.BaseDirectory + @"\BaseFiles"))
            {
                foreach (var filePath in Directory.GetFiles(AppContext.BaseDirectory + @"\BaseFiles"))
                {
                    writer.WriteFiles(Extensions.ReadFile(filePath), Path.GetFileName(filePath));
                }
            }
            else
            {
                Console.WriteLine("No Base Files detected.\n" + 
                    "To add Base Files create folder in program directory named " +
                    "'BaseFile' and drop your Base Files there");
            }

            if (Directory.Exists(AppContext.BaseDirectory + @"\BaseLines"))
            {
                foreach (var filePath in Directory.GetFiles(AppContext.BaseDirectory + @"\BaseLines"))
                {
                    writer.WriteLines(Extensions.ReadFile(filePath), Path.GetFileName(filePath));
                }
            }
            else
            {
                Console.WriteLine("No Base Lines detected.\n" + 
                    "To add Base Lines create folder in program directory named " + 
                    "'BaseLines' and drop your Base Lines there");
            }

            Console.WriteLine("Scaffolding completed.");
            Console.Read();
            return;
        }
    }
}
