using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_ScheduleItem")]
    public  class ToDoScheduleItem: BaseModel
    {
        [Key]
        public int ToDoScheduleItemId { get; set; }
        public int TodoDetailsID { get; set; }
        public string ToDoScheduleTitle { get; set; }
        public DateTime ToDoScheduleStartDate { get; set; }
        public DateTime ToDoScheduleEndDate { get; set; }
        public int ToDoScheduleDuration { get; set; }
        public bool ToDoScheduleIsHourly { get; set; }
        public int ToDoScheduleDisplayColor { get; set; }

        public int ToDoScheduleReminder { get; set; }
    }
}
