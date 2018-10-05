using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string BaselineEndDate { get; set; }
        public string Name { get; set; }
        public decimal PercentDone { get; set; }
        public string StartDate { get; set; }
        public string BaselineStartDate { get; set; }
        public int Duration { get; set; }
        public bool expanded { get; set; }
        public List<ProjectTask> children { get; set; } = new List<ProjectTask>();
    }
}
