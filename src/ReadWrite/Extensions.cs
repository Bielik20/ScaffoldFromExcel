using System;
using System.Collections.Generic;
using System.Globalization;
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
            TextInfo textInfo = new CultureInfo("en-US").TextInfo;
            StringBuilder sb = new StringBuilder();
            foreach (char c in textInfo.ToLower(input))
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
