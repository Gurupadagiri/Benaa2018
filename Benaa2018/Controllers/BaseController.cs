using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Infrastructure;

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
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!IsAjaxRequest())
            {
                Basemodel = new BaseViewModel
                {
                    UserMasterModel = await _userMasterHelper.GetUserByUserId(1),
                    ProjectTypeMasterModels = await _projectMasterHelper.GetAllProjectType(),
                    ProjectGroupModels = await _projectGroupHelper.GetProjectGroupByUserID(1),
                    ProjectSubcontractorConfigModels = await _subContractorHelper.GetAllSubContractorByOrg(1),
                    ProjctStatusMasterModels = await _projectStatusMasterHelper.GetAllProjectStatus(),
                    ProjectColorModels = await _projectColorHelper.GetAllProjectColor(),
                    CompanyMasterModel = await _companyMasterHelper.GetCompanyByID(1),
                    UserMasterViewModels = await _userMasterHelper.GetAllInternalUsers(),
                    ProjectMasterModels = await _projectMasterHelper.GetAllProjectByUserId(1),
                    ProjectManagerMasterModels = await _projectMasterHelper.GetAllManagers(),
                    MenuContents = await _menuMasterHelper.GetMenuItems()
                };
                Basemodel.ProjectGridModels = BindProjectGrid(Basemodel.ProjectMasterModels, Basemodel.ProjectManagerMasterModels);
                Basemodel.ProjectModelJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Basemodel.ProjectGridModels);
                ViewBag.Basemodel = Basemodel;
                ViewBag.UsersList = Basemodel.UserMasterViewModels;
            }
            else
            {
                Basemodel = new BaseViewModel
                {     
                    ProjectColorModels = await _projectColorHelper.GetAllProjectColor(),
                    UserMasterViewModels = await _userMasterHelper.GetAllInternalUsers(),
                    IsAjaxRequest = true
                };
                ViewBag.Basemodel = Basemodel;
            }
            base.OnActionExecuting(context);
            await next();
        }

        public List<ProjectGridModel> BindProjectGrid(List<ProjectMasterViewModel> ProjectMasterModels,
           List<ProjectManagerMasterViewModel> ProjectManagerMasterModels)
        {
            List<ProjectGridModel> lstGridModel = new List<ProjectGridModel>();
            ProjectMasterModels.ForEach(a =>
            {
                string managerName = string.Empty;
                if(a.ProjectManagerID != null)
                {
                    foreach (var item in a.ProjectManagerID)
                    {
                        managerName = managerName + ProjectManagerMasterModels.Where(b => b.ManagerID == Convert.ToInt32(item)).Select(b => b.ManagerName).FirstOrDefault() + ",";
                    }
                }         
                lstGridModel.Add(new ProjectGridModel
                {
                    ProjectName = a.ProjectName,
                    ProjectColor = a.ProjectScheduleMasterModel.JobColorID,
                    City = a.City,
                    ManagerName = managerName?.TrimEnd(','),
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

        public bool IsAjaxRequest()
        {
            return Request.IsAjaxRequest();
        }
    }
}