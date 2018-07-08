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
            MenuContents = new List<MenuViewModel>();
            UserMasterModel = new UserMasterViewModel();
            ProjectTypeMasterModels = new List<ProjectTypeMasterViewModel>();
            ProjectGroupModels = new List<ProjectGroupViewModel>();
            ProjectSubcontractorConfigModels = new List<ProjectSubcontractorConfigViewModel>();
            ProjctStatusMasterModels = new List<ProjctStatusMasterViewModel>();
            ProjectColorModels = new List<ProjectColorViewModel>();
            CompanyMasterModel = new CompanyMasterViewModel();
            UserMasterViewModels = new List<UserMasterViewModel>();
            ProjectMasterModels = new List<ProjectMasterViewModel>();
            ProjectManagerMasterModels = new List<ProjectManagerMasterViewModel>();
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
