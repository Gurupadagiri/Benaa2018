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

namespace Benaa2018.Controllers
{
    public class VarianceController : BaseController
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
        private readonly IGroupMasterHelper _groupMasterHelper;
        private readonly IMainActivityMasterHelper _mainActivityMasterHelper;
        private readonly IActivityMasterHelper _activityMasterHelper;
        private readonly IVarianceMasterHelper _varianceMasterHelper;

        public VarianceController(IMenuMasterHelper menuMasterHelper,
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
           IGroupMasterHelper groupMasterHelper,
           IMainActivityMasterHelper mainActivityMasterHelper,
           IActivityMasterHelper activityMasterHelper,
           IVarianceMasterHelper varianceMasterHelper,
            ICompanyMasterHelper companyMasterHelper) : base(menuMasterHelper,
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
            _mainActivityMasterHelper = mainActivityMasterHelper;
            _companyMasterHelper = companyMasterHelper;
            _todoMasterDetailsHelper = tomasterDetails;
            _tagMasterHelper = tagMasterHelper;
            _toDoAssignHelper = toDoAssignHelper;
            _tagToDoHelper = toDoTagHelper;
            _toDoCheckListHelper = toDoCheckListHelper;
            _toDoCheckListDetailsHelper = toDoCheckListDetailsHelper;
            _groupMasterHelper = groupMasterHelper;
            _activityMasterHelper = activityMasterHelper;
            _varianceMasterHelper = varianceMasterHelper;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SaveVarianceMaster(int varianceId = 0)
        {
            var mainActivityMasters = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMaster = new List<MainActivityMasterViewModel>();
            VarianceMasterViewModel variMasterModel = new VarianceMasterViewModel();
            if (mainActivityMasters != null)
            {
                foreach (var item in mainActivityMasters)
                {
                    lstMainActivityMaster.Add(new MainActivityMasterViewModel()
                    {
                        MainActivityId = item.MainActivityId,
                        MainActivityCode = item.MainActivityCode
                    });
                }
            }

            if (varianceId > 0)
            {
                var varianceMasterList = await _varianceMasterHelper.GetAllVarianceMasterDetails("", varianceId, 0);
                if (varianceMasterList != null)
                {
                    variMasterModel.VarianceId = varianceMasterList[0].VarianceId;
                    variMasterModel.MainActivityId = varianceMasterList[0].MainActivityId;
                    variMasterModel.VarianceName = varianceMasterList[0].VarianceName;
                    variMasterModel.VarianceCode = varianceMasterList[0].VarianceCode;
                    variMasterModel.ParentId = varianceMasterList[0].ParentId;
                    variMasterModel.OrgId = varianceMasterList[0].OrgId;
                    variMasterModel.Status = varianceMasterList[0].Status;
                    variMasterModel.Sequence = varianceMasterList[0].Sequence;
                    variMasterModel.IsDeleted = varianceMasterList[0].IsDeleted;
                    variMasterModel.VarianceDescription = varianceMasterList[0].VarianceDescription;
                }
            }
            variMasterModel.lstMainActivityMaster = lstMainActivityMaster;

            return PartialView("SaveVarianceMaster", variMasterModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveVarianceMaster(VarianceMasterViewModel varianceMaster)
        {
            try
            {

                VarianceMasterViewModel varianceModel = new VarianceMasterViewModel()
                {
                    VarianceId = varianceMaster.VarianceId,
                    MainActivityId = varianceMaster.MainActivityId,
                    VarianceName = varianceMaster.VarianceName,
                    VarianceCode = varianceMaster.VarianceCode,
                    OrgId = 1,
                    ParentId = 1,
                    Sequence = varianceMaster.Sequence,
                    Status = varianceMaster.Status,
                    IsDeleted = false,
                    VarianceDescription = varianceMaster.VarianceDescription
                };
                #region validaate group code
                var varianceMasterList = await _varianceMasterHelper.GetAllVarianceMasterDetails(varianceMaster.VarianceCode);

                #endregion

                if (varianceModel.VarianceId == 0)
                {
                    if (varianceMasterList?.Count == 0)
                    {
                        var objSaveVarianceMaster = await _varianceMasterHelper.SaveVarianceMasterDetails(varianceModel);
                        if (objSaveVarianceMaster.VarianceId > 0)
                        {
                            varianceMaster.Success = true;
                            varianceMaster.Message = "Variance master saved successfully!!!!!";
                        }

                    }
                    else
                    {
                        varianceMaster.Success = false;
                        varianceMaster.Message = "Variance master code already exists!!!";
                    }
                }
                else
                {
                    if (varianceMasterList?.Count < 2)
                    {
                        var objSaveActivityMaster = await _varianceMasterHelper.UpdateActivityMasterDetails(varianceModel);
                        if (objSaveActivityMaster.VarianceId > 0)
                        {
                            varianceMaster.Success = true;
                            varianceMaster.Message = "Variance master saved successfully!!!!!";
                        }
                    }
                    else
                    {
                        varianceMaster.Success = false;
                        varianceMaster.Message = "Variance master code already exists for other items!!!";
                    }
                }

            }
            catch (Exception ex)
            {
                varianceMaster.Success = false;
                varianceMaster.Message = "Main  activity master did not saved successfully!!!!";
            }

            return Json(varianceMaster);
        }


        [HttpPost]
        public async Task<ActionResult> DeleteVarianceMaster(VarianceMasterViewModel varianceMaster)
        {
            string result = string.Empty;

            VarianceMasterViewModel varianceModel = new VarianceMasterViewModel()
            {
                VarianceId = varianceMaster.VarianceId,
                MainActivityId = varianceMaster.MainActivityId,
                VarianceName = varianceMaster.VarianceName,
                VarianceCode = varianceMaster.VarianceCode,
                OrgId = 1,
                ParentId = 1,
                Sequence = varianceMaster.Sequence,
                Status = varianceMaster.Status,
                IsDeleted = true,
                VarianceDescription = varianceMaster.VarianceDescription
            };


            var objSaveVarianceMaster = await _varianceMasterHelper.UpdateActivityMasterDetails(varianceModel);

            if (objSaveVarianceMaster.VarianceId > 0)
            {
                varianceMaster.Success = true;
                varianceMaster.Message = "Variance master deleted successfully!!!!!";
            }
            else
            {
                varianceMaster.Success = false;
                varianceMaster.Message = "Variance master did not  saved successfully!!!!!";
            }
            return Json(varianceMaster);
        }
    }
}