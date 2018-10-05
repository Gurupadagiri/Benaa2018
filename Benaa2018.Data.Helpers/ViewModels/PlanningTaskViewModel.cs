using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class PlanningTaskViewModel : CommonViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string BaselineEndDate { get; set; }
        public string Name { get; set; }
        public decimal PercentDone { get; set; }
        public string StartDate { get; set; }
        public string BaselineStartDate { get; set; }
        public int Duration { get; set; }
        public bool Expanded { get; set; }
    }
}
