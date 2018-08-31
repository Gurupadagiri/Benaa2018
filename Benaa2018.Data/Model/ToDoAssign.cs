using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_Assign")]
    public class ToDoAssign : BaseModel
    {
        [Key]
        public int ToDoAssignID { get; set; }
        public int UserID { get; set; }
        public int TodoDetailsID { get; set; }
        public int ToDoUserAssignTypeId { get; set; }
        public bool DeletionStatus { get; set; }
    }
}
