using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Cost_Code")]
    public class CostCode :BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CostCodeId { get; set; }
        public string CostCodeTitle { get; set; }
        public int CostCategoryId { get; set; }
        public int CodeSubCodeId { get; set; }
        public bool IsCostCodeActive { get; set; }
        public bool IsTimeClockLabourCode { get; set; }
        public string CostCodeDetails { get; set; }
        public string DefaultLabourCode { get; set; }

    }
}
