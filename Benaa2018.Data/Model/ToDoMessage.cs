using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("To_Do_Message")]
    public class ToDoMessage : BaseModel
    {
        [Key]
        public int ToDo_Message_Id { get; set; }
        public int ToDo_Details_Id { get; set; }
        public string ToDo_Message_Title { get; set; }
        public bool Is_Owner { get; set; }
        public bool Is_Sub { get; set; }
    }
}
