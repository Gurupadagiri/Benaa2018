using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_schedule_Master")]
    public class ProjectScheduleMaster : BaseModel
    {
        [Key]
        public int Schedule_ID { get; set; }
        public int Org_ID { get; set; }
        public int Project_ID { get; set; }
        public int ProjectColorId { get; set; }
        public DateTime Projected_Start { get; set; }
        public DateTime Projected_Completion { get; set; }
        public DateTime Actual_Start { get; set; }
        public DateTime Actual_Completion { get; set; }
        public int Project_Color_ID { get; set; }
        public string Works_Days { get; set; }        
    }
}
