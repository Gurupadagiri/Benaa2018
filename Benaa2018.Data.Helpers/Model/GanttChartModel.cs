using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
    public class GanttChartModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public string duration { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public List<string> users { get; set; } = new List<string>();
        public string pred   { get; set; }
        public bool status { get; set; }
        public string color { get; set; }
        public int parent { get; set; }
        public decimal progress { get; set; }
    }
}
