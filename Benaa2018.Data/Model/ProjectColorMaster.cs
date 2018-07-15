using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Project_Color")]
    public class ProjectColorMaster : BaseModel
    {
        [Key]
        public int ProjectColorId { get; set; }
        public string ProjectColorName { get; set; }
        public bool IsDisable { get; set; }
        public string ColorCode { get; set; }
    }
}
