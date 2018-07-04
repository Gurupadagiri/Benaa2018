using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_Master")]
    public class ToDoMaster : BaseModel
    {
        [Key]
        public int Todo_ID { get; set; }
        public int Project_ID { get; set; }
        public string Project_Site { get; set; }
        public string Title { get; set; }
        public int Org_ID { get; set; }
        public string Note { get; set; }
        public string Priority { get; set; }
        public string AssignTo { get; set; }
        public DateTime Due_Date_Selection { get; set; }
        public DateTime Assign_Date { get; set; }
        public int Time_choosen_ID { get; set; }
        public int Days { get; set; }
        public string state_val { get; set; }
        public int Schedule_ID { get; set; }
        public int Reminder_ID { get; set; }
        public int TaG_ID { get; set; }        
    }
}
