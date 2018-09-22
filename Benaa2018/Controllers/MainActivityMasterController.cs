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
                    OrgId = 1,
                    Sequence = mainActivityMasterViewModel.Sequence,
                    Status = mainActivityMasterViewModel.Status,
                    IsDeleted = false
                };
                var objSaveGroupMaster = await _mainActivityMasterHelper.SaveMainActivityMasterDetails(mainActivityModel);

                if (objSaveGroupMaster.MainActivityId > 0)
                {
                    mainActivityMasterViewModel.Success = true;
                }
            }
            catch (Exception ex)
            {
                mainActivityMasterViewModel.Success = false;
            }
            #region DDL
            //var groupMasters = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            //List<GroupMasterViewModel> lstGroupMaster = new List<GroupMasterViewModel>();
            //if (groupMasters != null)
            //{
            //    foreach (var item in groupMasters)
            //    {
            //        lstGroupMaster.Add(new GroupMasterViewModel()
            //        {
            //            GroupId = item.GroupId,
            //            GroupName = item.GroupName
            //        });
            //    }
            //}
            //ViewBag.listofGroup = lstGroupMaster;
            #endregion

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
            return Json(result);
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