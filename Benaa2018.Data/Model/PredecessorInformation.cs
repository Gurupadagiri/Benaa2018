using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Predecessor_Information")]
    public class PredecessorInformation : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PredecessorId { get; set; }
        public int SourceScheuledId { get; set; }
        public int ProjectId { get; set; }
        public int ScheduledItemId { get; set; }
        public string TimeFrame { get; set; }
        public int Lag { get; set; }
        public int CompanyId { get; set; }
    }
}
