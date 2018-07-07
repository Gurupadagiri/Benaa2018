using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Benaa2018.Controllers
{
    public abstract partial class BaseController : Controller
    {
        private readonly IMenuMasterHelper _menuMasterHelper;
        private readonly IOwnerMasterHelper _ownerMasterHelper;
        private readonly IProjectColorHelper _projectColorHelper;
        private readonly IProjectGroupHelper _projectGroupHelper;
        private readonly IProjectMasterHelper _projectMasterHelper;
        private readonly IProjectScheduleMasterHelper _projectScheduleMasterHelper;
        private readonly IProjectStatusMasterHelper _projectStatusMasterHelper;
        private readonly ISubContractorHelper _subContractorHelper;
        private readonly IUserMasterHelper _userMasterHelper;
        private readonly ICompanyMasterHelper _companyMasterHelper;
        public BaseViewModel Basemodel = null;
        public BaseController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper,
            IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper,
            IUserMasterHelper userMasterHelper,
            ICompanyMasterHelper companyMasterHelper)
        {
            _menuMasterHelper = menuMasterHelper;
            _ownerMasterHelper = ownerMasterHelper;
            _projectColorHelper = projectColorHelper;
            _projectGroupHelper = projectGroupHelper;
            _projectMasterHelper = projectMasterHelper;
            _projectScheduleMasterHelper = projectScheduleMasterHelper;
            _projectStatusMasterHelper = projectStatusMasterHelper;
            _subContractorHelper = subContractorHelper;
            _userMasterHelper = userMasterHelper;
            _companyMasterHelper = companyMasterHelper;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Basemodel = new BaseViewModel(_menuMasterHelper, _ownerMasterHelper,
               _projectColorHelper, _projectGroupHelper,
               _projectMasterHelper, _projectScheduleMasterHelper,
               _projectStatusMasterHelper, _subContractorHelper,
               _userMasterHelper, _companyMasterHelper);
            Basemodel.ProjectGridModels = BindProjectGrid(Basemodel.ProjectMasterModels, Basemodel.ProjectManagerMasterModels);
            Basemodel.ProjectModelJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Basemodel.ProjectGridModels);
            ViewBag.Basemodel = Basemodel;
            base.OnActionExecuting(filterContext);
        }

        public List<ProjectGridModel> BindProjectGrid(List<ProjectMasterViewModel> ProjectMasterModels,
           List<ProjectManagerMasterViewModel> ProjectManagerMasterModels)
        {
            List<ProjectGridModel> lstGridModel = new List<ProjectGridModel>();
            ProjectMasterModels.ForEach(a =>
            {
                lstGridModel.Add(new ProjectGridModel
                {
                    ProjectName = a.ProjectName,
                    City = a.City,
                    ManagerName = ProjectManagerMasterModels.Where(b => b.ManagerID.ToString() == a.ProjectManagerID).Select(b => b.ManagerName).FirstOrDefault(),
                    MobileNo = a.OwnerMasterModel.MobileNo,
                    OwnerName = a.OwnerMasterModel.OwnerName,
                    ProjectId = a.ProjectID,
                    State = a.State,
                    StreetAddress = a.StreetAddress,
                    Telephone = a.OwnerMasterModel.MobileNo,
                    Zip = a.Zip,
                    Active = a.OwnerMasterModel.Active
                });
            });
            return lstGridModel;
        }
    }
}