using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectScheduleMasterViewModel
    {
        public ProjectScheduleMasterViewModel()
        {
            DaysList.Add("Sun", 1);
            DaysList.Add("Mon", 2);
            DaysList.Add("Tues", 3);
            DaysList.Add("Wed", 4);
            DaysList.Add("Thrus", 5);
            DaysList.Add("Fri", 6);
            DaysList.Add("Sat", 7);
        }
        public int Project_Schedule_ID { get; set; }

        public int OrgID { get; set; }

        public int ProjectId { get; set; }

        public string ProjectColorId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Project Start")]
        public string ProjectStart { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Actual Start")]
        public string ActualStart { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Project Completion")]
        public string ProjectCompletion { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Actual Completion")]
        public string ActualCompletion { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Job Color")]
        public string JobColorID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Work Days")]
        public string WorkDays { get; set; }

        public Dictionary<string, int> DaysList { get; set; } = new Dictionary<string, int>();
    }
}
