using Benaa2018.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectManagerMasterViewModel
    {
        public ProjectManagerMasterViewModel()
        {
        }
        IProjectManagerMasterRepository _projectManagerMasterRepoisitory;
        public ProjectManagerMasterViewModel(IProjectManagerMasterRepository projectManagerMasterRepoisitory)
        {
            _projectManagerMasterRepoisitory = projectManagerMasterRepoisitory;
        }
        public int ManagerID { get; set; }
       
        public int OrgID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Id*")]
        public string ManagerName { get; set; }

       
    }
}
