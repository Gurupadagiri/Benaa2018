using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Data.Interfaces;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectTypeMasterViewModel
    {
        public ProjectTypeMasterViewModel()
        {

        }
        public IProjectTypeMasterRepository _projectMasterRepository;
        public ProjectTypeMasterViewModel(IProjectTypeMasterRepository projectMasterRepository)
        {
            _projectMasterRepository = projectMasterRepository;
        }
        public int ProjectTypeID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Type Name")]
        public string ProjectTypeName { get; set; }
        public bool Active { get; set; }

        public List<ProjectTypeMasterViewModel> GetAllProjectType()
        {
            List<ProjectTypeMasterViewModel> ProjectTypeMasterModelLst = new List<ProjectTypeMasterViewModel>();
            var projectTypes = _projectMasterRepository.GetAllAsync().Result.ToList();
            projectTypes.ForEach(item => {
                ProjectTypeMasterModelLst.Add(new ProjectTypeMasterViewModel {
                    Active = item.Active,
                    ProjectTypeID = item.Project_Type_ID,
                    ProjectTypeName= item.Project_Type_Name
                });
            });
            return ProjectTypeMasterModelLst;
        }
    }
}
