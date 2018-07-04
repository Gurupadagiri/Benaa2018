using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_Status_Master")]
    public class ProjectStatusMaster : BaseModel
    {
        [Key]
        public int Status_ID { get; set; }
        public int Org_ID { get; set; }
        public string Status_Name { get; set; }
        public bool Active { get; set; }
    }
}
