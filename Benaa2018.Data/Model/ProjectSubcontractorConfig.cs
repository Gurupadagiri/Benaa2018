using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_Subcontractor_config")]
    public class ProjectSubcontractorConfig : BaseModel
    {
        [Key]
        public int SubContractor_ID { get; set; }
        public int Org_ID { get; set; }
        public decimal Project_ID { get; set; }
        public string Subcontractor_Name { get; set; }
        public bool View_Access { get; set; }
    }
}
