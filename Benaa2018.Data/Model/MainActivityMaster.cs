using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("MainActivity_Master")]
    public class MainActivityMaster : BaseModel
    {
        [Key]
        public int Main_Activity_Id { get; set; }
        public int Group_Id { get; set; }
        public string Main_Activity_Name { get; set; }
        public string Main_Activity_Code { get; set; }
        public int Org_Id { get; set; }
        public string Sequence { get; set; }
        public bool Status { get; set; }
        public bool Is_Deleted { get; set; }
        public string MainActivityDescription { get; set; }
    }
}
