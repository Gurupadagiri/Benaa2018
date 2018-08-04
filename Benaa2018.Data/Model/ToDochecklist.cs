using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_CheckList")]
    public class ToDochecklist : BaseModel
    {
        [Key]
        public int ToDoCheckListId { get; set; }
        public int TodoDetailsID { get; set; }
       
        public bool ToDoAssignIsCheckListItem { get; set; }
        public bool ToDoAssignIFilesCheckListItem { get; set; }
    }
}
