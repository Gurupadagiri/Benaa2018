using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectMasterViewModel
    {
        public ProjectMasterViewModel()
        {
            ProjectScheduleMasterModel = new ProjectScheduleMasterViewModel();
            OwnerMasterModel = new OwnerMasterViewModel();
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name*")]
        public string ProjectName { get; set; }
        public int ProjectID { get; set; }
        public int OrgID { get; set; }
        public int CountryID { get; set; }
        [Display(Name = "Project Status*")]
        public int ProjectStatusID { get; set; }
        public int UserID { get; set; }   

        [Display(Name = "Project Group*")]
        public string ProjectGroupID { get; set; }

        [Display(Name = "Project Type*")]
        public int ProjectTypeID { get; set; }

        [Display(Name = "Project Manager*")]
        public string ProjectManagerID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Street Address*")]
        public string StreetAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Zip")]
        public string Zip { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Jobsite Prefix")]
        public string JobsitePrefix { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Lot Info")]
        public string LotInfo { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Permit#")]
        public string Permit { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Contract Price")]
        public decimal ContractPrice { get; set; }
                
        public string SubNotes { get; set; }
        public string InternalNotes { get; set; }
        public IFormFile ProfilePicture { get; set; }

        public ProjectScheduleMasterViewModel ProjectScheduleMasterModel { get; set; }
        public OwnerMasterViewModel OwnerMasterModel { get; set; }
    }
}
