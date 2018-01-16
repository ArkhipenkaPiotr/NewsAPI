using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi
{
 
    public class News
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
