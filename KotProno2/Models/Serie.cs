using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    /// <summary>
    /// Represents a person's score as plotted on a chart.
    /// </summary>
    public class Serie
    {
        public string Name { get; set; }
        public IList<int> Data { get; set; }
    }
}