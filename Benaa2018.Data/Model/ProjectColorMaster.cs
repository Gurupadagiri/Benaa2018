using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Project_Color")]
    public class ProjectColorMaster
    {
        [Key]
        public int ProjectColorId { get; set; }
        public string ProjectColorName { get; set; }
        public bool IsDisable { get; set; }
    }
}
