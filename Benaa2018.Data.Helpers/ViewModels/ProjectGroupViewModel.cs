using Benaa2018.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectGroupViewModel
    {
        public IProjectGroupRepository _projectGroupRepository;
        public ProjectGroupViewModel()
        {

        }
        public ProjectGroupViewModel(IProjectGroupRepository projectGroupRepository)
        {
            _projectGroupRepository = projectGroupRepository;
        }
        public Int64 ProjectGroupID { get; set; }

        public int UserID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Group Name")]
        public string ProjectGroupName { get; set; }
    }
}
