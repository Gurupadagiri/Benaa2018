using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Warrenty_Alert")]
    public class WarrentyAlert:BaseModel
    {
        [Key]
        public int Warrent_Alert_Id { get; set; }
        public int User_ID { get; set; }
        public Int32 Warrenty_Year{ get; set; }
        public string Warrenty_Name { get; set; }
    }
}
