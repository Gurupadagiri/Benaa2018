﻿using Benaa2018.Helper;
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
    public class ActivityController : BaseController
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


        public ActivityController(IMenuMasterHelper menuMasterHelper,
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

        }


        public async Task<IActionResult> Index()
        {

            var mainActivityMasterList = await _activityMasterHelper.GetAllActivityMasterDetails();
            List<ActivityMasterViewModel> lstactivityMasters = new List<ActivityMasterViewModel>();
            //lstMainActivityMasters = mainActivityMasterList;
            if (mainActivityMasterList.Count > 0)
            {
                foreach (var item in mainActivityMasterList)
                {
                    string mainActivityName = string.Empty;
                    var mainActivityDetails = await _mainActivityMasterHelper.GetAllMainActivityMasterById(item.MainActivityId);
                    if (mainActivityDetails != null)
                    {
                        mainActivityName = mainActivityDetails[0].GroupName;
                    }
                    ActivityMasterViewModel mainActivity = new ActivityMasterViewModel()
                    {
                        ActivityId = item.ActivityId,
                        MainActivityId = item.MainActivityId,
                        MainActivityName = mainActivityName,
                        ActivityName = item.ActivityName,
                        ParentId = item.ParentId,
                        OrgId = item.OrgId,
                        Status = item.Status,
                        Sequence = item.Sequence,
                        IsDeleted = item.IsDeleted
                    };
                    lstactivityMasters.Add(mainActivity);
                }
            }
            return View(lstactivityMasters);
        }

        public async Task<IActionResult> SaveActivityMaster(int activityId = 0)
        {
            var mainActivityMasters = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMaster = new List<MainActivityMasterViewModel>();
            ActivityMasterViewModel activityMasterModel = new ActivityMasterViewModel();
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

            if (activityId > 0)
            {
                var activityMasterList = await _activityMasterHelper.GetAllActivityMasterDetails("", activityId, 1);
                if (activityMasterList != null)
                {
                    activityMasterModel.ActivityId = activityMasterList[0].ActivityId;
                    activityMasterModel.MainActivityId = activityMasterList[0].MainActivityId;
                    activityMasterModel.ActivityName = activityMasterList[0].ActivityName;
                    activityMasterModel.ActivityCode = activityMasterList[0].ActivityCode;
                    activityMasterModel.OrgId = 1;
                    activityMasterModel.ParentId = 1;
                    activityMasterModel.Sequence = activityMasterList[0].Sequence;
                    activityMasterModel.Status = activityMasterList[0].Status;
                    activityMasterModel.IsDeleted = false;
                    activityMasterModel.ActivityDescription = activityMasterList[0].ActivityDescription;
                }
            }
            activityMasterModel.lstMainActivityMaster = lstMainActivityMaster;
            //ActivityMasterViewModel activityMasterModel = new ActivityMasterViewModel()
            //{
            //    lstMainActivityMaster = lstMainActivityMaster
            //};
            return PartialView("SaveActivityMaster", activityMasterModel);
        }


        public async Task<IActionResult> InsertActivityMaster()
        {
            var mainActivityMasters = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMaster = new List<MainActivityMasterViewModel>();
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
            ActivityMasterViewModel activityMasterModel = new ActivityMasterViewModel()
            {
                lstMainActivityMaster = lstMainActivityMaster
            };
            return PartialView("InsertActivityMaster", activityMasterModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertActivityMaster(ActivityMasterViewModel activityMasterViewModel)
        {
            try
            {

                ActivityMasterViewModel mainActivityModel = new ActivityMasterViewModel()
                {
                    ActivityId = activityMasterViewModel.ActivityId,
                    MainActivityId = activityMasterViewModel.MainActivityId,
                    ActivityName = activityMasterViewModel.ActivityName,
                    ActivityCode = activityMasterViewModel.ActivityCode,
                    OrgId = 1,
                    ParentId = 1,
                    Sequence = activityMasterViewModel.Sequence,
                    Status = activityMasterViewModel.Status,
                    IsDeleted = false,
                    ActivityDescription = activityMasterViewModel.ActivityDescription
                };
                #region validaate group code
                var activityMasterList = await _activityMasterHelper.GetAllActivityMasterDetails(activityMasterViewModel.ActivityCode);

                #endregion

                if (mainActivityModel.ActivityId == 0)
                {
                    if (activityMasterList?.Count == 0)
                    {
                        var objSaveActivityMaster = await _activityMasterHelper.SaveActivityMasterDetails(mainActivityModel);
                        if (objSaveActivityMaster.ActivityId > 0)
                        {
                            activityMasterViewModel.Success = true;
                            activityMasterViewModel.Message = "Activity master saved successfully!!!!!";
                        }

                    }
                    else
                    {
                        activityMasterViewModel.Success = false;
                        activityMasterViewModel.Message = "Activity  activity master code already exists!!!";
                    }
                }
                else
                {
                    if (activityMasterList?.Count <2)
                    {
                        var objSaveActivityMaster = await _activityMasterHelper.UpdateActivityMasterDetails(mainActivityModel);
                        if (objSaveActivityMaster.ActivityId > 0)
                        {
                            activityMasterViewModel.Success = true;
                            activityMasterViewModel.Message = "Activity master saved successfully!!!!!";
                        }
                    }
                    else
                    {
                        activityMasterViewModel.Success = false;
                        activityMasterViewModel.Message = "Activity  activity master code already exists for other items!!!";
                    }
                }

            }
            catch (Exception ex)
            {
                activityMasterViewModel.Success = false;
                activityMasterViewModel.Message = "Main  activity master did not saved successfully!!!!";
            }

            return Json(activityMasterViewModel);
        }

        public async Task<ActionResult> DeleteActivityMaster(int activity_id)
        {
            string result = string.Empty;

            ActivityMasterViewModel activityItem = new ActivityMasterViewModel();
            var activityItems = await _activityMasterHelper.GetAllActivityMasterById(activity_id);
            if (activityItems.Count > 0)
            {
                activityItem.ActivityId = Convert.ToInt32(activityItems[0].ActivityId);
                activityItem.MainActivityId = Convert.ToInt32(activityItems[0].MainActivityId);

                //activityItem.MainActivityName = activityItems[0].MainActivityName;
                activityItem.ActivityName = activityItems[0].ActivityName;
                activityItem.ParentId = activityItems[0].ParentId;
                activityItem.OrgId = activityItems[0].OrgId;
                activityItem.Sequence = activityItems[0].Sequence;
                activityItem.Status = activityItems[0].Status;
                activityItem.IsDeleted = true;

            }
            var objSaveActivityMaster = await _activityMasterHelper.UpdateActivityMasterDetails(activityItem);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteActivityMaster(ActivityMasterViewModel activityMasterViewModel)
        {
            string result = string.Empty;

            ActivityMasterViewModel activityItem = new ActivityMasterViewModel();
            
            
                activityItem.ActivityId = Convert.ToInt32(activityMasterViewModel.ActivityId);
                activityItem.MainActivityId = Convert.ToInt32(activityMasterViewModel.MainActivityId);

                //activityItem.MainActivityName = activityItems[0].MainActivityName;
                activityItem.ActivityName = activityMasterViewModel.ActivityName;
                activityItem.ParentId = activityMasterViewModel.ParentId;
                activityItem.OrgId = activityMasterViewModel.OrgId;
                activityItem.Sequence = activityMasterViewModel.Sequence;
                activityItem.Status = activityMasterViewModel.Status;
                activityItem.IsDeleted = true;

            
            var objSaveActivityMaster = await _activityMasterHelper.UpdateActivityMasterDetails(activityItem);

            if (objSaveActivityMaster.ActivityId > 0)
            {
                objSaveActivityMaster.Success = true;
                objSaveActivityMaster.Message = "Activity master saved successfully!!!!!";
            }
            else
            {
                objSaveActivityMaster.Success = false;
                objSaveActivityMaster.Message = "Activity master did not  saved successfully!!!!!";
            }
            return Json(objSaveActivityMaster);
        }

        public async Task<IActionResult> UpdateActivityMaster(int activity_id)
        {
            ActivityMasterViewModel activityItem = new ActivityMasterViewModel();
            var activityItems = await _activityMasterHelper.GetAllActivityMasterById(activity_id);
            if (activityItems.Count > 0)
            {
                activityItem.ActivityId = Convert.ToInt32(activityItems[0].ActivityId);
                activityItem.MainActivityId = Convert.ToInt32(activityItems[0].MainActivityId);

                //activityItem.MainActivityName = activityItems[0].MainActivityName;
                activityItem.ActivityName = activityItems[0].ActivityName;
                activityItem.ParentId = activityItems[0].ParentId;
                activityItem.OrgId = activityItems[0].OrgId;
                activityItem.Sequence = activityItems[0].Sequence;
                activityItem.Status = activityItems[0].Status;
                activityItem.IsDeleted = true;

            }

            #region DDL
            var mainActivityMasters = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMaster = new List<MainActivityMasterViewModel>();
            if (mainActivityMasters != null)
            {
                foreach (var item in mainActivityMasters)
                {
                    lstMainActivityMaster.Add(new MainActivityMasterViewModel()
                    {
                        MainActivityId = item.MainActivityId,
                        MainActivityName = item.MainActivityName
                    });
                }
            }
            ViewBag.listofGroup = lstMainActivityMaster;
            #endregion
            return View(activityItem);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivityMaster(ActivityMasterViewModel activityMasterViewModel)
        {
            ActivityMasterViewModel mainActivityModel = new ActivityMasterViewModel()
            {
                ActivityId = Convert.ToInt32(activityMasterViewModel.ActivityId),
                MainActivityId = Convert.ToInt32(activityMasterViewModel.MainActivityId),

                //activityItem.MainActivityName = activityItems[0].MainActivityName;
                ActivityName = activityMasterViewModel.ActivityName,
                ParentId = activityMasterViewModel.ParentId,
                OrgId = activityMasterViewModel.OrgId,
                Sequence = activityMasterViewModel.Sequence,
                Status = activityMasterViewModel.Status,
                IsDeleted = activityMasterViewModel.IsDeleted
            };
            var objActivityMaster = await _activityMasterHelper.UpdateActivityMasterDetails(mainActivityModel);

            #region DDL
            var mainActivityMasters = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMaster = new List<MainActivityMasterViewModel>();
            if (mainActivityMasters != null)
            {
                foreach (var item in mainActivityMasters)
                {
                    lstMainActivityMaster.Add(new MainActivityMasterViewModel()
                    {
                        MainActivityId = item.MainActivityId,
                        MainActivityName = item.MainActivityName
                    });
                }
            }
            ViewBag.listofGroup = lstMainActivityMaster;
            #endregion

            return View();

        }
    }
}