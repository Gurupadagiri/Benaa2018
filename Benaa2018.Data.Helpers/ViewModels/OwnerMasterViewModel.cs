using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class OwnerMasterViewModel
    {      
        public int OrgID { get; set; }        
        public int OwnerID { get; set; }
        public int ProjectID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ProfilePicture { get; set; }
        public string OwnerInformation { get; set; }
        public string OwnerActivation { get; set; }
        public string AccessMethod { get; set; }
        public string OwnerCalendar { get; set; }
        public bool ShowProjectPrice { get; set; }
        public bool ShowBudgetPurchaseOrders { get; set; }
        public bool AllowOrderRequests { get; set; }
        public bool AllowLockedSelections { get; set; }
        public bool AllowWarrantyClaims { get; set; }
        public bool AllowPaymentsTab { get; set; }

        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        //public IFormFile ProfileImage { get; set; }
    }
}
