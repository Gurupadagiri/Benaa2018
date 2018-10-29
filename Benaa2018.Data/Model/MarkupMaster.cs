using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Markup_Master")]
  public  class MarkupMaster:BaseModel
    {
        [Key]
        public int Markup_ID { get; set; }

        public String Markup_Name { get; set; }

        public String Description { get; set; }
        public bool Status { get; set; }
        public int Orgid { get; set; }
        
    }
}
