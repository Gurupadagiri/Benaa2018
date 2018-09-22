using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Activity_Master")]
    public   class ActivityMaster : BaseModel
    {
        [Key]
        public int Activity_Id { get; set; }
        public int Main_Activity_Id { get; set; }
        public string Activity_Name { get; set; }
        public int Parent_Id { get; set; }
        public int Org_Id { get; set; }
        public bool Status { get; set; }
        public string Sequence { get; set; }
        public bool Is_Deleted { get; set; }
        public string ActivityDescription { get; set; }
    }
}
