using Benaa2018.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Helper.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Benaa2018.Helper.Model;
using System;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Web;
using System.Text;

namespace Benaa2018.Controllers
{
    public class CostCategoryController : BaseController
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
        private readonly IToDoMasterDetailsHelper _todoMasterDetailsHelper;
        private readonly ITagMasterHelper _tagMasterHelper;
        private readonly IToDoAssignHelper _toDoAssignHelper;
        private readonly IToDoTagHelper _tagToDoHelper;
        private readonly IToDoCheckListHelper _toDoCheckListHelper;
        private readonly IToDoCheckListDetailsHelper _toDoCheckListDetailsHelper;
        private readonly IToDoMessageHelper _toDoMessageHelper;
        private readonly ICalendarScheduleHelper _calendarScheduleHelper;
        private readonly ICostCategoryHelper _costCategoryHelper;

        public CostCategoryController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper,
            IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper,
            IToDoMasterHelper toDoMasterHelper,
            IUserMasterHelper userMasterHelper,
            IWarrentyAlertHelper warrentyAlertHelper,
            IToDoMasterDetailsHelper tomasterDetails,
           ITagMasterHelper tagMasterHelper,
           IToDoTagHelper toDoTagHelper,
           IToDoAssignHelper toDoAssignHelper,
           IToDoCheckListHelper toDoCheckListHelper,
           IToDoCheckListDetailsHelper toDoCheckListDetailsHelper,
           IToDoMessageHelper toDoMessageHelper,
           ICostCategoryHelper costCategoryHelper,
            ICompanyMasterHelper companyMasterHelper, ICalendarScheduleHelper calendarScheduleHelper) : base(menuMasterHelper,
            ownerMasterHelper,
            projectColorHelper,
            projectGroupHelper,
            projectMasterHelper,
            projectScheduleMasterHelper,
            projectStatusMasterHelper,
            subContractorHelper,
            userMasterHelper,
            companyMasterHelper)
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
            _todoMasterDetailsHelper = tomasterDetails;
            _tagMasterHelper = tagMasterHelper;
            _toDoAssignHelper = toDoAssignHelper;
            _tagToDoHelper = toDoTagHelper;
            _toDoCheckListHelper = toDoCheckListHelper;
            _toDoCheckListDetailsHelper = toDoCheckListDetailsHelper;
            _toDoMessageHelper = toDoMessageHelper;
            _calendarScheduleHelper = calendarScheduleHelper;
            _costCategoryHelper = costCategoryHelper;
        }



        public async Task<IActionResult> Index()
        {
            CostCategoryViewModel costCategory = new CostCategoryViewModel();
            List<CostCategoryViewModel> lstCostCategoryDetails = new List<CostCategoryViewModel>();
            var costCategoryList = await _costCategoryHelper.GetCostCategoryDetails();
            if (costCategoryList != null)
            {
                foreach (var item in costCategoryList)
                {
                    CostCategoryViewModel costCategoryModel = new CostCategoryViewModel()
                    {
                        CostCategoryId = item.CostCategoryId,
                        CostCategoryTitle = item.CostCategoryTitle,
                        CostCategoryParentId = item.CostCategoryParentId,
                        CostCategoryDetails = item.CostCategoryDetails,
                        isDeleted = item.isDeleted
                    };
                    lstCostCategoryDetails.Add(costCategoryModel);
                }
            }
            CostCategoryViewModel model = new CostCategoryViewModel()
            {
                lstCostCategories = lstCostCategoryDetails
            };

            //return PartialView("_groupSetup", model);
            return Json(lstCostCategoryDetails);
        }
        
        public async Task<IActionResult> aaaa()
        {
            CostCategoryViewModel costCategory = new CostCategoryViewModel();
            List<CostCategoryViewModel> lstCostCategoryDetails = new List<CostCategoryViewModel>();
            var costCategoryList = await _costCategoryHelper.GetCostCategoryDetails();
            if (costCategoryList != null)
            {
                foreach (var item in costCategoryList)
                {
                    CostCategoryViewModel costCategoryModel = new CostCategoryViewModel()
                    {
                        CostCategoryId = item.CostCategoryId,
                        CostCategoryTitle = item.CostCategoryTitle,
                        CostCategoryParentId = item.CostCategoryParentId,
                        CostCategoryDetails = item.CostCategoryDetails,
                        isDeleted = item.isDeleted
                    };
                    lstCostCategoryDetails.Add(costCategoryModel);
                }
            }
            CostCategoryViewModel model = new CostCategoryViewModel()
            {
                lstCostCategories = lstCostCategoryDetails
            };
            return PartialView("_groupSetup", model);
        }
    }
}