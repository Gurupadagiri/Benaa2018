using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectScheduleMasterViewModel
    {
        public int Project_Schedule_ID { get; set; }
        public int OrgID { get; set; }
        public int ProjectId { get; set; }
        public int ProjectColorId { get; set; }

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
        public int JobColorID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Work Days")]
        public string WorkDays { get; set; }
    }
}
