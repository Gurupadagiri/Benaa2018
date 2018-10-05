using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Planning_Task")]
    public class PlanningTask : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public int MainActivity_ID { get; set; }
        public int Activity_ID { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }
        public decimal PercentDone { get; set; }
        public string StartDate { get; set; }
        public string BaselineStartDate { get; set; }
        public string BaselineEndDate { get; set; }
        public int Duration { get; set; }
        public bool Expanded { get; set; }
    }
}
