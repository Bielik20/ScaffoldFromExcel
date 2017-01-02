using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadWrite;

namespace ScaffoldFromExcel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExcelReader reader = new ExcelReader(@"C:\Users\Bielik\git\ScaffoldFromExcel\src\ScaffoldFromExcel\bin\Debug\netcoreapp1.0\input.xlsx");
            var modelList = reader.GetModelList();
        }
    }
}
