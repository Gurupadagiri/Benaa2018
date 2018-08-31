using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_CheckList_Details")]
    public class ToDochecklistDetails : BaseModel
    {
        [Key]
        public int ToDochecklistDetailsId { get; set; }
        public int ToDoCheckListId { get; set; }
        public bool ToDoIsCheckList { get; set; }
        public string ToDoCheckListTitle { get; set; }
        public int ToDoCheckListUserTypeId { get; set; }
        public int ToDoCheckListUserId { get; set; }
        public bool DeletionStatus { get; set; }
    }
}
