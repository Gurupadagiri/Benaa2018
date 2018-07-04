using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Project_Group")]
    public class ProjectGroup :BaseModel
    {
        [Key]
        public int Project_Goup_ID { get; set; }
        public int User_ID { get; set; }
        public string Project_Group_Name { get; set; }
    }
}
