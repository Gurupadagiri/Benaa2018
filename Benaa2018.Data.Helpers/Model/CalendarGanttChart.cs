using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
    public class CalendarGanttChart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public decimal Progress { get; set; }
        public int? Predicate { get; set; }
        public string AssignedTo { get; set; }
        public bool Status { get; set; }
    }
}
