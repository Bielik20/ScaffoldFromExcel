using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWrite
{
    public static class Extensions
    {
        public static readonly string fill_title = "FILL_TITLE";
        public static readonly string fill_ftitle = "FILL_FTITLE";

        public static readonly string start_list = "START_LIST";
        public static readonly string end_list = "END_LIST";

        public static readonly string fill_item = "FILL_ITEM";
        public static readonly string fill_fitem = "FILL_FITEM";


        public static string FormatedText(this string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input.ToTitleCase())
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string ToTitleCase(this string str)
        {
            var tokens = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1);
            }

            return string.Join(" ", tokens);
        }

        public static string ReadFile(string filePath)
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
