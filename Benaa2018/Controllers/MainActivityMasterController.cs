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
    public class MainActivityMasterController : BaseController
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

        public MainActivityMasterController(IMenuMasterHelper menuMasterHelper,
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

        public async Task<IActionResult> Index()
        {
            var mainActivityMasterList = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails();
            List<MainActivityMasterViewModel> lstMainActivityMasters = new List<MainActivityMasterViewModel>();
            //lstMainActivityMasters = mainActivityMasterList;
            if (mainActivityMasterList.Count > 0)
            {
                foreach (var item in mainActivityMasterList)
                {
                    string groupName = string.Empty;
                    var groupDetails = await _groupMasterHelper.GetGroupMasterViewModelById(item.GroupId);
                    if (groupDetails != null)
                    {
                        groupName = groupDetails[0].GroupName;
                    }
                    MainActivityMasterViewModel mainActivity = new MainActivityMasterViewModel()
                    {
                        MainActivityId = item.MainActivityId,
                        GroupId = item.GroupId,
                        GroupName = groupName,
                        MainActivityName = item.MainActivityName,
                        OrgId = item.OrgId,
                        Sequence = item.Sequence,
                        Status = item.Status,
                        IsDeleted = item.Status
                    };
                    lstMainActivityMasters.Add(mainActivity);
                }
            }
            return View(lstMainActivityMasters);
        }


        public async Task<IActionResult> SaveMainActivity(int mainActivityId = 0)
        {
            var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
            if (groupMasters != null)
            {
                foreach (var item in groupMasters)
                {
                    lstGroupMaster.Add(new GroupMasterViewModel()
                    {
                        GroupId = item.GroupId,
                        GroupName = item.GroupCode
                    });
                }
            }
            MainActivityMasterViewModel mainAcitivity = new MainActivityMasterViewModel();
            if (mainActivityId > 0)
            {
                var mainActivities = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails("", mainActivityId, 1);
                if (mainActivities != null)
                {
                    mainAcitivity.MainActivityId = mainActivities[0].MainActivityId;
                    mainAcitivity.GroupId = mainActivities[0].GroupId;
                    mainAcitivity.MainActivityName = mainActivities[0].MainActivityName;
                    mainAcitivity.MainActivityCode = mainActivities[0].MainActivityCode;
                    mainAcitivity.OrgId = mainActivities[0].OrgId;
                    mainAcitivity.Sequence = mainActivities[0].Sequence;
                    mainAcitivity.Status = mainActivities[0].Status;
                    mainAcitivity.MainActivityDescription = mainActivities[0].MainActivityDescription;

                }
            }
            GroupMasterViewModel grpitemdefault = new GroupMasterViewModel()
            {
                GroupId = 0,
                GroupName = "---Select---"
            };
            lstGroupMaster.Insert(0, grpitemdefault);
            mainAcitivity.lstGroupMaster = lstGroupMaster;
            //MainActivityMasterViewModel mainActivityModel = new MainActivityMasterViewModel()
            //{
            //    lstGroupMaster = lstGroupMaster
            //};
            return PartialView("SaveMainActivity", mainAcitivity);
        }

        //public async Task<IActionResult> SaveMainActivity()
        //{
        //    var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
        //    List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
        //    if (groupMasters != null)
        //    {
        //        foreach (var item in groupMasters)
        //        {
        //            lstGroupMaster.Add(new GroupMasterViewModel()
        //            {
        //                GroupId = item.GroupId,
        //                GroupName = item.GroupCode
        //            });
        //        }
        //    }

        //    MainActivityMasterViewModel mainActivityModel = new MainActivityMasterViewModel()
        //    {
        //        lstGroupMaster = lstGroupMaster
        //    };
        //    return PartialView("SaveMainActivity", mainActivityModel);
        //}

        public async Task<IActionResult> CostCode(int caseStat = 0)
        {
            var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            var mainActivities = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails("", 0, caseStat);
            var activityMasterList = await _activityMasterHelper.GetAllActivityMasterDetails("", 0, caseStat);
            var varianceMasterList = await _varianceMasterHelper.GetAllVarianceMasterDetails("", 0, caseStat);

            List<VarianceMasterViewModel> lstVarianceMaster = new List<VarianceMasterViewModel>();
            if (varianceMasterList?.Count > 0)
            {
                varianceMasterList.ForEach(item =>
                {
                    lstVarianceMaster.Add(new VarianceMasterViewModel
                    {
                        VarianceId = item.VarianceId,
                        VarianceCode = item.VarianceCode ?? string.Empty,
                        VarianceName = item.VarianceName ?? string.Empty,
                        Sequence = item.Sequence ?? string.Empty,
                        OrgId = item.OrgId,
                        Status = item.Status,
                        IsDeleted = item.IsDeleted,
                        VarianceDescription = item.VarianceDescription,
                        MainActivityId = item.MainActivityId
                    });
                });
            }

            List<GroupMasterViewModel> lstGrpMaster = new List<GroupMasterViewModel>();
            if (groupMasters?.Count > 0)
            {
                groupMasters.ForEach(item =>
                {
                    lstGrpMaster.Add(new GroupMasterViewModel
                    {
                        GroupId = item.GroupId,
                        GroupCode = item.GroupCode ?? string.Empty,
                        GroupName = item.GroupName ?? string.Empty,
                        Sequence = item.Sequence ?? string.Empty,
                        OrgId = item.OrgId,
                        Status = item.Status,
                        IsDeleted = item.IsDeleted,
                        GroupDescription = item.GroupDescription
                    });
                });
            }

            List<MainActivityMasterViewModel> lstMainMaster = new List<MainActivityMasterViewModel>();
            if (mainActivities?.Count > 0)
            {
                mainActivities.ForEach(item =>
                {
                    lstMainMaster.Add(new MainActivityMasterViewModel
                    {
                        MainActivityId = item.MainActivityId,
                        GroupId = item.GroupId,
                        GroupName = item.GroupName ?? string.Empty,
                        MainActivityName = item.MainActivityName ?? string.Empty,
                        MainActivityCode = item.MainActivityCode ?? string.Empty,
                        OrgId = item.OrgId,
                        Sequence = item.Sequence,
                        Status = item.Status,
                        IsDeleted = item.IsDeleted,
                        MainActivityDescription = item.MainActivityDescription
                    });
                });
            }
            CostListsModel costList = new CostListsModel();
            List<ActivityMasterViewModel> lstActivityMaster = new List<ActivityMasterViewModel>();
            if (activityMasterList?.Count > 0)
            {
                activityMasterList.ForEach(item =>
                {
                    lstActivityMaster.Add(new ActivityMasterViewModel
                    {
                        ActivityId = item.ActivityId,
                        MainActivityId = item.MainActivityId,
                        MainActivityName = item.MainActivityName,
                        ActivityName = item.ActivityName,
                        ActivityCode = item.ActivityCode,
                        ParentId = item.ParentId,
                        OrgId = item.OrgId,
                        Status = item.Status,
                        Sequence = item.Sequence,
                        IsDeleted = item.IsDeleted,
                        ActivityDescription = item.ActivityDescription
                    });


                });
            }
            bool checkStatus = false;
            if (caseStat == 0)
            {
                checkStatus = true;
            }
            else
            {
                checkStatus = false;
            }

            CostListsModel costLists = new CostListsModel()
            {
                lstGroupMaster = lstGrpMaster,
                lstMainActivityMaster = lstMainMaster,
                lstActivityMaster = lstActivityMaster,
                lstVarianceMaster = lstVarianceMaster,
                chkStatus = checkStatus
            };
            return PartialView("CostCode", costLists);
        }




        public async Task<IActionResult> InsertMainActivityMaster()
        {
            var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
            if (groupMasters != null)
            {
                foreach (var item in groupMasters)
                {
                    lstGroupMaster.Add(new GroupMasterViewModel()
                    {
                        GroupId = item.GroupId,
                        GroupName = item.GroupName
                    });
                }
            }
            ViewBag.listofGroup = lstGroupMaster;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertMainActivityMaster(MainActivityMasterViewModel mainActivityMasterViewModel)
        {
            try
            {

                MainActivityMasterViewModel mainActivityModel = new MainActivityMasterViewModel()
                {
                    MainActivityId = mainActivityMasterViewModel.MainActivityId,
                    GroupId = mainActivityMasterViewModel.GroupId,
                    MainActivityName = mainActivityMasterViewModel.MainActivityName,
                    MainActivityCode = mainActivityMasterViewModel.MainActivityCode,
                    OrgId = 1,
                    Sequence = mainActivityMasterViewModel.Sequence,
                    Status = mainActivityMasterViewModel.Status,
                    MainActivityDescription = mainActivityMasterViewModel.MainActivityDescription,
                    IsDeleted = false
                };
                #region validaate group code
                var mainActivityMasterList = await _mainActivityMasterHelper.GetAllMainActivityMasterDetails(mainActivityModel.MainActivityCode);

                #endregion

                if (mainActivityModel.MainActivityId > 0)
                {
                    if (mainActivityMasterList?.Count < 2)
                    {
                        var objUpdateGroupMaster = await _mainActivityMasterHelper.UpdateMainActivityMasterDetails(mainActivityModel);
                        if (objUpdateGroupMaster.MainActivityId > 0)
                        {
                            mainActivityMasterViewModel.Success = true;
                            mainActivityMasterViewModel.Message = "Main  activity master saved successfully!!!!!";
                        }

                    }
                    else
                    {
                        mainActivityMasterViewModel.Success = false;
                        mainActivityMasterViewModel.Message = "Main  activity master code already exists!!!";
                    }
                }
                else
                {
                    if (mainActivityMasterList?.Count == 0)
                    {
                        var objSaveGroupMaster = await _mainActivityMasterHelper.SaveMainActivityMasterDetails(mainActivityModel);
                        if (objSaveGroupMaster.MainActivityId > 0)
                        {
                            mainActivityMasterViewModel.Success = true;
                            mainActivityMasterViewModel.Message = "Main  activity master saved successfully!!!!!";
                        }
                    }
                    else
                    {
                        mainActivityMasterViewModel.Success = false;
                        mainActivityMasterViewModel.Message = "Main  activity master code already exists!!!";
                    }
                }


            }
            catch (Exception ex)
            {
                mainActivityMasterViewModel.Success = false;
                mainActivityMasterViewModel.Message = "Main  activity master did not saved successfully!!!!";
            }

            return Json(mainActivityMasterViewModel);
        }

        public async Task<ActionResult> DeleteMainActivityMaster(int main_activity_id)
        {
            string result = string.Empty;

            MainActivityMasterViewModel mainActivityItem = new MainActivityMasterViewModel();
            var mainMasterItem = await _mainActivityMasterHelper.GetAllMainActivityMasterById(main_activity_id);
            if (mainMasterItem.Count > 0)
            {
                mainActivityItem.MainActivityId = Convert.ToInt32(mainMasterItem[0].MainActivityId);
                mainActivityItem.GroupId = Convert.ToInt32(mainMasterItem[0].GroupId);
                mainActivityItem.MainActivityName = mainMasterItem[0].MainActivityName;
                mainActivityItem.OrgId = mainMasterItem[0].OrgId;
                mainActivityItem.Sequence = mainMasterItem[0].Sequence;
                mainActivityItem.Status = mainMasterItem[0].Status;
                mainActivityItem.IsDeleted = true;

            }
            var objSaveMainActivityMaster = await _mainActivityMasterHelper.UpdateMainActivityMasterDetails(mainActivityItem);
            if (objSaveMainActivityMaster.MainActivityId > 0)
            {
                objSaveMainActivityMaster.Success = true;
                objSaveMainActivityMaster.Message = "Main  activity master saved successfully!!!!!";
            }
            return Json(objSaveMainActivityMaster);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteMainActivityMaster(MainActivityMasterViewModel mainActivityMasterViewModel)
        {
            string result = string.Empty;
            //var mainMasterItem = await _mainActivityMasterHelper.GetAllMainActivityMasterById(main_activity_id);
            //if (mainMasterItem.Count > 0)
            MainActivityMasterViewModel mainActivityItem = new MainActivityMasterViewModel()
            {

                MainActivityId = Convert.ToInt32(mainActivityMasterViewModel.MainActivityId),
                MainActivityCode = mainActivityMasterViewModel.MainActivityCode,
                GroupId = Convert.ToInt32(mainActivityMasterViewModel.GroupId),
                MainActivityName = mainActivityMasterViewModel.MainActivityName,
                OrgId = mainActivityMasterViewModel.OrgId,
                Sequence = mainActivityMasterViewModel.Sequence,
                Status = mainActivityMasterViewModel.Status,
                IsDeleted = true

            };
            var objSaveMainActivityMaster = await _mainActivityMasterHelper.UpdateMainActivityMasterDetails(mainActivityItem);
            if (objSaveMainActivityMaster.MainActivityId > 0)
            {
                objSaveMainActivityMaster.Success = true;
                objSaveMainActivityMaster.Message = "Main  activity master saved successfully!!!!!";
            }
            return Json(objSaveMainActivityMaster);
        }
        public async Task<IActionResult> UpdateMainActivityMaster(int main_activity_id)
        {
            MainActivityMasterViewModel mainActivityItem = new MainActivityMasterViewModel();
            var mainMasterItem = await _mainActivityMasterHelper.GetAllMainActivityMasterById(main_activity_id);
            if (mainMasterItem.Count > 0)
            {
                mainActivityItem.MainActivityId = Convert.ToInt32(mainMasterItem[0].MainActivityId);
                mainActivityItem.GroupId = Convert.ToInt32(mainMasterItem[0].GroupId);
                mainActivityItem.MainActivityName = mainMasterItem[0].MainActivityName;
                mainActivityItem.OrgId = mainMasterItem[0].OrgId;
                mainActivityItem.Sequence = mainMasterItem[0].Sequence;
                mainActivityItem.Status = mainMasterItem[0].Status;
                mainActivityItem.IsDeleted = true;

            }

            #region DDL
            var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
            if (groupMasters != null)
            {
                foreach (var item in groupMasters)
                {
                    lstGroupMaster.Add(new GroupMasterViewModel()
                    {
                        GroupId = item.GroupId,
                        GroupName = item.GroupName
                    });
                }
            }
            ViewBag.listofGroup = lstGroupMaster;
            #endregion
            return View(mainActivityItem);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMainActivityMaster(MainActivityMasterViewModel mainActivityMasterViewModel)
        {
            MainActivityMasterViewModel mainActivityModel = new MainActivityMasterViewModel()
            {
                MainActivityId = mainActivityMasterViewModel.MainActivityId,
                GroupId = mainActivityMasterViewModel.GroupId,
                MainActivityName = mainActivityMasterViewModel.MainActivityName,
                OrgId = 1,
                Sequence = mainActivityMasterViewModel.Sequence,
                Status = mainActivityMasterViewModel.Status,
                IsDeleted = false
            };
            var objSaveGroupMaster = await _mainActivityMasterHelper.UpdateMainActivityMasterDetails(mainActivityModel);

            #region DDL
            var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
            if (groupMasters != null)
            {
                foreach (var item in groupMasters)
                {
                    lstGroupMaster.Add(new GroupMasterViewModel()
                    {
                        GroupId = item.GroupId,
                        GroupName = item.GroupName
                    });
                }
            }
            ViewBag.listofGroup = lstGroupMaster;
            #endregion

            return View();

        }

    }
}