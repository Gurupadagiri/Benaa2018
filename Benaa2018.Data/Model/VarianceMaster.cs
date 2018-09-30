using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Variance_Master")]
    public class VarianceMaster : BaseModel
    {
        [Key]
        public int Variance_Id { get; set; }
        public int Main_Activity_Id { get; set; }
        public string Variance_Name { get; set; }
        public string Variance_Code { get; set; }
        public int Parent_Id { get; set; }
        public int Org_Id { get; set; }
        public bool Status { get; set; }
        public string Sequence { get; set; }
        public bool Is_Deleted { get; set; }
        public string VarianceDescription { get; set; }
    }
}
