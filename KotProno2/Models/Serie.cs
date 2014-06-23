using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class Serie
    {
        public string Name { get; set; }
        public IList<int> Data { get; set; }
    }
}