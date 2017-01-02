using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWrite
{
    public class Writer
    {
        List<Model> modelList;

        public string ModelToString(string baseString, Model model)
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
