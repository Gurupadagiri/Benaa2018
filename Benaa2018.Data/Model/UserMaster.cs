using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("User_Master")]
    public class UserMaster : BaseModel
    {
        [Key]
        public int UserID { get; set; }
        public Int32 Org_ID { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Email { get; set; }
        public bool User_Enabled { get; set; }
        public bool User_Login_Enabled { get; set; }
        public string User_Phone { get; set; }
        public string User_Cell_Email { get; set; }
        public string User_Contact_Info { get; set; }
        public int User_Default_Time_Clock { get; set; }
        public string User_Default_Labour_Cost { get; set; }
        public bool User_Is_Alert { get; set; }
        public int User_Alert_Schedule { get; set; }
        public bool User_Is_Automatic_Access { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool User_Is_Forum_Handle { get; set; }
        public string User_Forum_Handle { get; set; }
    }
}
