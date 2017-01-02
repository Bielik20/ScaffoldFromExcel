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
            var reader = new ExcelReader(AppContext.BaseDirectory + @"\input.xlsx");
            var modelList = reader.GetModelList();

            var a = Read(AppContext.BaseDirectory + @"\aaa.txt");
            var writer = new Writer(modelList);
            writer.WriteFiles(a, Path.GetExtension("test.cs"));
            writer.WriteLines(a, "test.cs");
        }

        public static string Read(string filePath)
        {
            try
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:\n");
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}
