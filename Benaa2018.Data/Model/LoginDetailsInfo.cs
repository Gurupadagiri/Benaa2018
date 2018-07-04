using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Login_Details_Info")]
    public class LoginDetailsInfo
    {
        [Key]
        public int UserId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
