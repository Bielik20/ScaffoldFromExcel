using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadWrite
{
    public class Model
    {
        public string Title { get; set; }
        public List<string> Items { get; set; } = new List<string>();
    }
}
