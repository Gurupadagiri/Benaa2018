using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{

    [Table("Unit_Master")]
    public class UnitMaster : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Unit_id { get; set; }
        public String Unit_Name { get; set; }
        public String Description { get; set; }
        public bool Status { get; set; }
        public int Orgid{get;set;}
        
   }
}
