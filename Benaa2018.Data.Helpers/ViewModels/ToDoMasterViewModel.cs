using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoMasterViewModel
    {        
        public int TodoID { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Priority { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string ProjectSite { get; set; }
    }
}
