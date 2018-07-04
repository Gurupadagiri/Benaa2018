using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class LoginViewModel : CommonViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Id*")]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name*")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        [DataType(DataType.Password)]
        public bool RememberMe { get; set; }        
    }
}
