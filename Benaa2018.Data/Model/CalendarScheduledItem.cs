using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Calendar_Scheduled_Item")]
    public class CalendarScheduledItem : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ScheduledItemId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
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
    }
}
