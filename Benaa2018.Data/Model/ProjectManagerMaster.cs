using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_Manager_Master")]
    public class ProjectManagerMaster : BaseModel
    {
        [Key]
        public int Manager_ID { get; set; }
        public int Org_ID { get; set; }
        public string Manager_Name { get; set; }
    }
}
