using System;
using System.Collections.Generic;

namespace Benaa2018.Helper.ViewModels
{
    public class CalendarScheduledItemViewModel : CommonViewModel
    {
        public CalendarScheduledItemViewModel()
        {
            ProjectColorViewModels = new List<ProjectColorViewModel>();
        }
        public int ScheduledItemId { get; set; }
        public string Title { get; set; }
        public string ColorCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string AssignedTo { get; set; }
        public int Reminder { get; set; }
        public bool Hourly { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public List<ProjectColorViewModel> ProjectColorViewModels { get; set; }
        public List<UserMasterViewModel> UserMasterViewModels { get; set; }
        public List<ProjectSubcontractorMasterViewModel> ProjectSubcontractorMasterViewModels { get; set; }

        public List<string> TimeIntervalLists
        {
            get
            {
                return TimeIntervals();
            }
        }
        public List<string> TimeIntervals()
        {
            List<string> timeIntervals = new List<string>();
            DateTime date = DateTime.MinValue.AddHours(0);
            DateTime endDate = DateTime.MinValue.AddDays(1).AddHours(0);
            while (date < endDate)
            {
                timeIntervals.Add(date.ToShortTimeString());
                date = date.AddMinutes(30);
            }
            return timeIntervals;
        }
    }
}
