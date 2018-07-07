using Benaa2018.Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class BaseViewModel : CommonViewModel
    {
        public BaseViewModel(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper,
            IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMaster,
            ISubContractorHelper subContractorHelper,           
            IUserMasterHelper userMasterHelper,          
            ICompanyMasterHelper companyMasterHelper)
        {
            ProjectMasterModel = new ProjectMasterViewModel();
            OwnerMasterModel = new OwnerMasterViewModel();
            ProjectScheduleMasterModel = new ProjectScheduleMasterViewModel();
            ProjectGroupModel = new ProjectGroupViewModel();
            ProjectSubcontractorConfigModel = new ProjectSubcontractorConfigViewModel();
            ProjctStatusMasterModel = new ProjctStatusMasterViewModel();
            ProjectGridModels = new List<ProjectGridModel>();
            MenuContents = menuMasterHelper.GetMenuItems().GetAwaiter().GetResult();
            UserMasterModel = userMasterHelper.GetUserByUserId(1).GetAwaiter().GetResult();
            ProjectTypeMasterModels = projectMasterHelper.GetAllProjectType().GetAwaiter().GetResult();
            ProjectGroupModels = projectGroupHelper.GetProjectGroupByUserID(1).GetAwaiter().GetResult();
            ProjectSubcontractorConfigModels = subContractorHelper.GetAllSubContractorByOrg(1).GetAwaiter().GetResult();
            ProjctStatusMasterModels = projectStatusMaster.GetAllProjectStatus().GetAwaiter().GetResult();
            ProjectColorModels = projectColorHelper.GetAllProjectColor().GetAwaiter().GetResult();
            CompanyMasterModel = companyMasterHelper.GetCompanyByID(1).GetAwaiter().GetResult();
            UserMasterViewModels = userMasterHelper.GetAllInternalUsers().GetAwaiter().GetResult();
            ProjectMasterModels = projectMasterHelper.GetAllProjectByUserId(1).GetAwaiter().GetResult();
            ProjectManagerMasterModels = projectMasterHelper.GetAllManagers().GetAwaiter().GetResult();
        }
        public UserMasterViewModel UserMasterModel { get; set; }
        public List<MenuViewModel> MenuContents { get; set; }
        public List<ProjectColorViewModel> ProjectColorModels { get; set; }
        public List<ProjectSubcontractorConfigViewModel> ProjectSubcontractorConfigModels { get; set; }
        public List<ProjectManagerMasterViewModel> ProjectManagerMasterModels { get; set; }
        public List<ProjectTypeMasterViewModel> ProjectTypeMasterModels { get; set; }
        public List<ProjectGroupViewModel> ProjectGroupModels { get; set; }
        public List<ProjectScheduleMasterViewModel> ProjectScheduleMasterModels { get; set; }
        public List<ProjectMasterViewModel> ProjectMasterModels { get; set; }
        
        public List<ProjectSubcontractorMasterViewModel> ProjectSubcontractorMasterModels { get; set; }
        public List<UserMasterViewModel> UserMasterViewModels { get; set; }
        public List<ProjctStatusMasterViewModel> ProjctStatusMasterModels { get; set; }
       
        public CompanyMasterViewModel CompanyMasterModel { get; set; }


        public ProjectMasterViewModel ProjectMasterModel { get; set; }
        public ProjectScheduleMasterViewModel ProjectScheduleMasterModel { get; set; }
        public ProjctStatusMasterViewModel ProjctStatusMasterModel { get; set; }
        public OwnerMasterViewModel OwnerMasterModel { get; set; }
        public ProjectGroupViewModel ProjectGroupModel { get; set; }
        public ProjectTypeMasterViewModel ProjectTypeMasterModel { get; set; }
        public ProjectSubcontractorConfigViewModel ProjectSubcontractorConfigModel { get; set; }
             
        public List<ProjectGridModel> ProjectGridModels { get; set; }
        public string ProjectModelJsonString { get; set; }
    }
}
