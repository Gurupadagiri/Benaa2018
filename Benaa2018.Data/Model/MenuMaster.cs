using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Menu_Master")]
    public class MenuMaster : BaseModel
    {
        [Key]
        public int Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public int PatentId { get; set; }
        public bool Active { get; set; }
        public bool Delflag { get; set; }
        public string CssClass { get; set; }

        [NotMapped]
        public List<MenuMaster> MenuItems { get; set; }
    }
}
