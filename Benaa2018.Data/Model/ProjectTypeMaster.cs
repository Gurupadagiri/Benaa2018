using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_Type_Master")]
    public class ProjectTypeMaster : BaseModel
    {
        [Key]
        public int Project_Type_ID { get; set; }
        public int Org_ID { get; set; }
        public string Project_Type_Name { get; set; }
        public bool Active { get; set; }
    }
}
