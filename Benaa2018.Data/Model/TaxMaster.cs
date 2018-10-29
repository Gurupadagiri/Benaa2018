using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Tax_Master")]
    public class TaxMaster:BaseModel
    {
        [Key]
        public int Tax_ID { get; set; }
        public String Tax_Name { get; set; }
        public String Description { get; set; }
        public bool Status { get; set; }
        public int Orgid { get; set; }
        
    }
}
