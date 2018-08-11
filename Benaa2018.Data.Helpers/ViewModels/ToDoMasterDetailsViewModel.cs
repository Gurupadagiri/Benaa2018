using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
   public  class ToDoMasterDetailsViewModel : CommonViewModel
    {
        public int TodoDetailsID { get; set; }
        public int Project_ID { get; set; }
        public string Project_Site { get; set; }
        public string Title { get; set; }
        public int Org_ID { get; set; }
        public string TypeNote { get; set; }
        public bool IsMarkedComplete { get; set; }
        public string Priority { get; set; }
        public DateTime Duedate { get; set; }
        public string DueDatetime { get; set; }
        public int LinkToUnit { get; set; }
        public string LinkToDaysStatus { get; set; }
        public int TillingWorkId { get; set; }
        public DateTime TillingDate { get; set; }
        public string TillingTime { get; set; }
        public int ReminderId { get; set; }
        public string  CreatedBy { get; set; }

        public bool DeletionStatus { get; set; }
    }
}
