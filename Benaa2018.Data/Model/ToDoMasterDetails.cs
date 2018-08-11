using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_Master_Details")]
    public class ToDoMasterDetails : BaseModel
    {
        [Key]
        public int TodoDetailsID { get; set; }
        public int Project_ID { get; set; }
        public string Project_Site { get; set; }
        public string Title { get; set; }
        public int Org_ID { get; set; }
        public string TypeNote { get; set; }
        public bool IsMarkedComplete { get; set; }
        public string Priority { get; set; }
        public DateTime  Duedate { get; set; }
        public string DueDatetime { get; set; }
        public int LinkToUnit { get; set; }
        public string LinkToDaysStatus { get; set; }
        public int LinkToWorkId { get; set; }
        public DateTime LinkToDate { get; set; }
        public string LinkToTime { get; set; }
        public int ReminderId { get; set; }
        public bool DeletionStatus { get; set; }

    }
}
