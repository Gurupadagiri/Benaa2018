using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Benaa2018.Helper.ViewModels
{
    public class UserMasterViewModel: CommonViewModel
    {
        //public int UserID { get; set; }
        //public int ProjectID { get; set; }
        //public Int32 OrgID { get; set; }
        //public string Password { get; set; }
        //public string UserName { get; set; }
        //public string FullName { get; set; }
        //public bool ViewAccess { get; set; }
        //public bool JobNotification { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public Int32 OrgID { get; set; }
        //public string Password { get; set; }
        //public string UserName { get; set; }
        public string FullName { get; set; }
        public bool ViewAccess { get; set; }
        public bool JobNotification { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        //[DataType(DataType.Custom)]
        [Display(Name = "User Enabled")]
        public bool UserEnabled { get; set; }

        [Display(Name = "Login Enabled")]
        public bool UserLoginEnabled { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Phone")]
        public string UserPhone { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Cell Email (SMS Text):")]
        public string UserCellEmail { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Contact Info:")]
        public string UserContactInfo { get; set; }

        //Enum will use
        [Display(Name = "Default Time Clock Labour Code:")]
        public int UserDefaultTimeClock { get; set; }

        [Display(Name = "Default Labour Cost:")]
        public string UserDefaultLabourCost { get; set; }

        public bool UserIsAlert { get; set; }
        public int UserAlertSchedule { get; set; }
        public bool UserIsAutomaticAccess { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        public bool UserIsForumHandle { get; set; }
        public string UserForumHandle { get; set; }
    }
}
