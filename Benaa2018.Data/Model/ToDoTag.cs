using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_Tag")]
    public class ToDoTag : BaseModel
    {
        [Key]
        public int ToDoTagid { get; set; }
        public int Tagid { get; set; }
        public int TodoDetailsID { get; set; }
    }
}
