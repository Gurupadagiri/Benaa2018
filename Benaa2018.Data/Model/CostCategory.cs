using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Cost_Category")]
    public class  CostCategory : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CostCategoryId { get; set; }
        public string CostCategoryTitle { get; set; }
        public int CostCategoryParentId { get; set; }
        public string CostCategoryDetails { get; set; }
        public bool isDeleted { get; set; }

    }
}
