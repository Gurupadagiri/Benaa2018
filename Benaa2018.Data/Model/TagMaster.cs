using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Tag_Master")]
    public class TagMaster : BaseModel
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
