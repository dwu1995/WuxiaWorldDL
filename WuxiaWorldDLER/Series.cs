using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuxiaWorldDLER
{
    public class Series
    {
        public Boolean IsComplete { get; set; }
        public String Url { get; set; }
        public String Name { get; set; }

        public Series(String name, String url, Boolean isComplete)
        {
            this.Name = name;
            this.Url = url;
            this.IsComplete = isComplete;
        }
    }
}
