using Benaa2018.Data.Interfaces;
using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMenuMasterHelper _menuMasterHelper;
        private readonly IOwnerMasterHelper _ownerMasterHelper;
        private readonly IProjectColorHelper _projectColorHelper;
        private readonly IProjectGroupHelper _projectGroupHelper;
        private readonly IProjectMasterHelper _projectMasterHelper;
        private readonly IProjectScheduleMasterHelper _projectScheduleMasterHelper;
        private readonly IProjectStatusMasterHelper _projectStatusMasterHelper;
        private readonly ISubContractorHelper _subContractorHelper;
        private readonly IToDoMasterHelper _toDoMasterHelper;
        private readonly IUserMasterHelper _userMasterHelper;
        private readonly IWarrentyAlertHelper _warrentyAlertHelper;
        private readonly ICompanyMasterHelper _companyMasterHelper;
        private readonly IHostingEnvironment _environment;
        public HomeController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper, IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper, IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper, IToDoMasterHelper toDoMasterHelper,
            IUserMasterHelper userMasterHelper, IWarrentyAlertHelper warrentyAlertHelper,
            ICompanyMasterHelper companyMasterHelper, IHostingEnvironment environment) : base(menuMasterHelper,
            ownerMasterHelper, projectColorHelper, projectGroupHelper, projectMasterHelper, projectScheduleMasterHelper,
            projectStatusMasterHelper, subContractorHelper, userMasterHelper, companyMasterHelper)
        {
            _menuMasterHelper = menuMasterHelper;
            _ownerMasterHelper = ownerMasterHelper;
            _projectColorHelper = projectColorHelper;
            _projectGroupHelper = projectGroupHelper;
            _projectMasterHelper = projectMasterHelper;
            _projectScheduleMasterHelper = projectScheduleMasterHelper;
            _projectStatusMasterHelper = projectStatusMasterHelper;
            _subContractorHelper = subContractorHelper;
            _toDoMasterHelper = toDoMasterHelper;
            _userMasterHelper = userMasterHelper;
            _warrentyAlertHelper = warrentyAlertHelper;
            _companyMasterHelper = companyMasterHelper;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeModel = new HomeViewModel
            {
                WarrentyAlertModels = await _warrentyAlertHelper.GetAllWarrenties(),
                ToDoMasterModels = await _toDoMasterHelper.GetAllToDoList()
            };
            return View(homeModel);
        }

       

        public void ExportToExcel()
        {

        }
        [HttpPost]
        public async Task<IActionResult> FilteredMainContentAsync(int projectId = 0)
        {
            HomeViewModel homeModel = new HomeViewModel
            {
                ToDoMasterModels = await _toDoMasterHelper.GetToDoListByProjectID(projectId),
                WarrentyAlertModels = await _warrentyAlertHelper.GetAllWarrenties()
            };
            return PartialView("_homeMainContent", homeModel);
        }

        [HttpPost]
        [RequestFormSizeLimit(valueCountLimit: 20000)]
        //[ValidateAntiForgeryToken(Order = 2)]
        //[RequestFormSizeLimit(valueCountLimit: 20000)]
        public async Task<IActionResult> SubmitProjectInfo(BaseViewModel homeContent)
        {
            if (homeContent != null && homeContent.ProjectMasterModel != null)
            {
                int projectId = 0;
                if (homeContent.ProjectMasterModel.ProjectID == 0)
                {
                    projectId = await _projectMasterHelper.SaveProjectMaster(1, homeContent.ProjectMasterModel);
                    await _userMasterHelper.SaveUserMaterConfig(1, projectId, homeContent.UserMasterViewModels);
                    await _projectScheduleMasterHelper.SaveProjectSchedules(1, projectId, homeContent.ProjectScheduleMasterModel);
                    await _ownerMasterHelper.SaveOwnerMasterAsync(projectId, homeContent.OwnerMasterModel);
                }
                else
                {
                    projectId = await _projectMasterHelper.UpdateProjectMaster(1, homeContent.ProjectMasterModel);
                    await _userMasterHelper.UpdateUserMaterConfig(projectId, homeContent.UserMasterViewModels);
                    await _projectScheduleMasterHelper.UpdateProjectSchedules(1, projectId, homeContent.ProjectScheduleMasterModel);
                    await _ownerMasterHelper.UpdateOwnerMaster(projectId, homeContent.OwnerMasterModel);
                }
                homeContent.Success = true;
            }
            return Json(homeContent.Success);
        }

        public async Task SaveFileAsync(OwnerMasterViewModel ownerMasterViewModel)
        {
            IFormFile fileInfo = null;
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var fileStream = new FileStream(Path.Combine(uploads, ""), FileMode.Create);
            await fileInfo.CopyToAsync(fileStream);
            //using (var fileStream = new FileStream(Path.Combine(uploads, ""), FileMode.Create))
            //{
            //    await fileInfo.CopyToAsync(fileStream);
            //}
            //fileInfo.CopyToAsync()
            //ownerMasterViewModel.ProfilePicture. = ownerMasterViewModel.FileName;
        }

        //[HttpPost]
        //public async Task<JsonResult> GetProjectInfoByProjectID(int projectID)
        //{
        //    BaseViewModel homeViewModel = new BaseViewModel
        //    {
        //        ProjectMasterModel = await _projectMasterHelper.GetProjectDetailsProjectId(projectID),
        //        OwnerMasterModel = await _ownerMasterHelper.GetOwnerInfoByInfo(projectID)
        //    };
        //    return Json(homeViewModel);
        //}

        [HttpGet]
        public JsonResult SaveProjectGroup(string jobGroupName)
        {
            var projectIngo = _projectGroupHelper.SaveProjectGroup(1, jobGroupName);
            return Json("success");
        }

        //[HttpPost]
        //public async Task<IActionResult> FilterProjectDetailsAsync(string[] projectGroupId, string[] managerID)
        //{
        //    BaseViewModel homeViewModel = new BaseViewModel
        //    {
        //        ProjectMasterModels = await _projectMasterHelper.FilterProjectInfo(projectGroupId, managerID),
        //        ProjectManagerMasterModels = await _projectMasterHelper.GetAllManagers(),
        //        ProjectGroupModels = await _projectGroupHelper.GetProjectGroupByUserID(1),
        //        ToDoMasterModels = await _toDoMasterHelper.GetAllToDoList()
        //    };
        //    return PartialView("_leftMenu", homeViewModel);
        //}

        [HttpPost]
        public async Task<IActionResult> FilterToDoListAsync(int days)
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                ToDoMasterModels = await _toDoMasterHelper.GetFilteredToDoList(days)
            };
            return PartialView("_toDoList", homeViewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> FilterProjectsAsync(string[] projectGroups,
        //    string[] projectManagers,
        //    string[] status,
        //    string[] projectTypes,
        //    string searchKeyWord,
        //    string[] mappedStatus,
        //    string searchText)
        //{
        //    BaseViewModel homeViewModel = new BaseViewModel();
        //    homeViewModel.ProjectMasterModels = await _projectMasterHelper.FilterProjectResults(projectGroups, projectManagers, status, projectTypes, searchKeyWord, mappedStatus, searchText);
        //    return PartialView("_infoModel", homeViewModel);
        //}

        [HttpPost]
        public async Task<JsonResult> GetProjectDetailsbyProjectIdAsync(int projectId)
        {
            var projectInfo = await _projectMasterHelper.GetProjectDetailsProjectId(projectId);
            return Json(projectInfo);
        }
    }
}
