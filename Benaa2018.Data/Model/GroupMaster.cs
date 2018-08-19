using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Group_Master")]
    public class GroupMaster : BaseModel
    {
        [Key]
        public int Group_Id { get; set; }
        public string Group_Code { get; set; }
        public string Group_Name { get; set; }
        public string Sequence { get; set; }
        public int Org_Id { get; set; }
        public bool  Status { get; set; }
        public bool Is_Deleted { get; set; }

    }
}
