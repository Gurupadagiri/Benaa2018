using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Calendar_Tag")]
    public class CalendarTag: BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string TagName { get; set; }
    }
}
