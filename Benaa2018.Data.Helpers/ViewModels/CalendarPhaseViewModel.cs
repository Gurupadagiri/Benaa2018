using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class CalendarPhaseViewModel: CommonViewModel
    {
        public int PhaseId { get; set; }
        public int ScheduleId { get; set; }
        public int CompanyId { get; set; }
        public int DisplayOrder { get; set; }
        public int ProjectId { get; set; }
        public string PhaseName { get; set; }
        public string PhaseColor { get; set; }
    }
}
