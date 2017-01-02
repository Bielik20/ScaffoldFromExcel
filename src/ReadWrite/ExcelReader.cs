using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadWrite
{
    public class ExcelReader
    {
        FileInfo _file;
        public ExcelReader(string filePath)
        {
            _file = new FileInfo(filePath);
        }

        public List<Model> GetModelList()
        {
            var modelList = new List<Model>();
            try
            {
                using (ExcelPackage package = new ExcelPackage(_file))
                {
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        GetFromSheet(modelList, sheet);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Some error occured while importing.\n" + e.Message);
                return null;
            }
            return modelList;
        }

        private static void GetFromSheet(List<Model> modelList, ExcelWorksheet sheet)
        {
            for (int col = 1; col <= sheet.Dimension.Columns; col++)
            {
                if (sheet.Cells[1, col] == null || sheet.Cells[1, col].Value == null)
                    break;
                var model = new Model();
                model.Title = sheet.Cells[1, col].Value.ToString();

                for (int row = 2; row <= sheet.Dimension.Rows; row++)
                {
                    if (sheet.Cells[row, col] != null && sheet.Cells[row, col].Value != null)
                        model.Items.Add(sheet.Cells[row, col].Value.ToString());
                }
                modelList.Add(model);
            }
        }
    }
}
