using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Project_User_Int_Config_Master")]
    public class ProjectUserIntConfigMaster
    {
        [Key]
        public int Internal_User_Con_Id { get; set; }
        public int Org_ID { get; set; }
        public int UserID { get; set; }
        public int Project_ID { get; set; }
        public string User_Name { get; set; }
        public bool View_Access { get; set; }
        public bool Recive_Notification { get; set; }       
    }
}
