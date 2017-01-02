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
            var writer = new Writer(modelList);

            if (Directory.Exists(AppContext.BaseDirectory + @"\BaseFiles"))
            {
                foreach (var filePath in Directory.GetFiles(AppContext.BaseDirectory + @"\BaseFiles"))
                {
                    writer.WriteFiles(Extensions.ReadFile(filePath), Path.GetFileName(filePath));
                }
            }

            if (Directory.Exists(AppContext.BaseDirectory + @"\BaseLines"))
            {
                foreach (var filePath in Directory.GetFiles(AppContext.BaseDirectory + @"\BaseLines"))
                {
                    writer.WriteLines(Extensions.ReadFile(filePath), Path.GetFileName(filePath));
                }
            }
        }
    }
}
