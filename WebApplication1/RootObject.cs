using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class RootObject
    {
        public string id { get; set; }
        public string link { get; set; }
        public List<string> dept { get; set; }
    }
}