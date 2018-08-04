using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoScheduleItemViewModel : CommonViewModel
    {
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
