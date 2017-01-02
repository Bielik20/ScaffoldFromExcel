using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWrite
{
    public class Writer
    {
        readonly List<Model> _modelList;
        readonly string _filesDirectory;
        readonly string _linesDirectory;

        public Writer(List<Model> modelList)
        {
            _modelList = modelList;
            _filesDirectory = AppContext.BaseDirectory + @"\Output_Files";
            _linesDirectory = AppContext.BaseDirectory + @"\Output_Lines";
            Directory.CreateDirectory(_filesDirectory);
            Directory.CreateDirectory(_linesDirectory);
        }

        public void WriteFiles(string baseString, string extension)
        {
            foreach (var model in _modelList)
            {
                using (StreamWriter file = File.CreateText(_filesDirectory + @"\" + model.Title.FormatedText() + extension))
                {
                    file.WriteLine(ModelToString(baseString, model));
                }
            }
        }

        public void WriteLines(string baseString, string fileName)
        {
            var lines = "";
            foreach (var model in _modelList)
            {
                lines += ModelToString(baseString, model);
            }

            using (StreamWriter file = File.CreateText(_linesDirectory + @"\" + fileName))
            {
                file.WriteLine(lines);
            }
        }

        private string ModelToString(string baseString, Model model)
        {
            var output = baseString;

            while (true)
            {
                var startIndex = output.IndexOf(Extensions.start_list);
                var endIndex = output.IndexOf(Extensions.end_list);
                if (startIndex == -1 || endIndex == -1)
                {
                    break;
                }
                var substring = output.Substring(startIndex, endIndex - startIndex + Extensions.end_list.Length);
                var clearSubstring = RemoveListIndicators(substring);

                var listOutput = "";
                foreach (var item in model.Items)
                {
                    listOutput += ReplacePlaceholders(clearSubstring, model, item);
                }
                output = output.Replace(substring, listOutput);
            }
            
            return output.Replace(output, ReplacePlaceholders(output, model));
        }

        private string RemoveListIndicators(string input)
        {
            var output = input.Remove(0, Extensions.start_list.Length);
            return output.Remove(output.IndexOf(Extensions.end_list));
        }

        private string ReplacePlaceholders(string input, Model model, string item = null)
        {
            var output = input.Replace(Extensions.fill_title, model.Title);
            output = output.Replace(Extensions.fill_ftitle, model.Title.FormatedText());
            if (item != null)
            {
                output = output.Replace(Extensions.fill_item, item);
                output = output.Replace(Extensions.fill_fitem, item.FormatedText());
            }

            return output;
        }
    }
}
