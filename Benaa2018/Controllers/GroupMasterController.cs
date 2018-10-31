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
    public class GroupMasterController : BaseController
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

        public GroupMasterController(IMenuMasterHelper menuMasterHelper,
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
            ICompanyMasterHelper companyMasterHelper) : base(menuMasterHelper, ownerMasterHelper, projectColorHelper,
            projectGroupHelper, projectMasterHelper, projectScheduleMasterHelper, projectStatusMasterHelper,
            subContractorHelper, userMasterHelper, companyMasterHelper)
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
            _groupMasterHelper = groupMasterHelper;
        }
        public async Task<IActionResult> Index()
        {
            var groupMasterList = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            List<GroupMasterViewModel> lstGrpMasters = new List<GroupMasterViewModel>();
            lstGrpMasters = groupMasterList;
            return View(lstGrpMasters);
        }

        public async Task<IActionResult> SaveGroupMaster(int groupId = 0)
        {
            GroupMasterViewModel grpItem = new GroupMasterViewModel();
            if (groupId > 0)
            {
                var groupMasterItem = await _groupMasterHelper.GetGroupMasterViewModelById(groupId);
                if (groupMasterItem.Count > 0)
                {
                    grpItem.GroupId = Convert.ToInt32(groupMasterItem[0].GroupId);
                    grpItem.GroupCode = groupMasterItem[0].GroupCode;
                    grpItem.GroupName = groupMasterItem[0].GroupName;
                    grpItem.Sequence = groupMasterItem[0].Sequence;
                    grpItem.Status = groupMasterItem[0].Status;
                    grpItem.IsDeleted = true;
                    grpItem.GroupDescription = groupMasterItem[0].GroupDescription;
                }
            }
            return PartialView("SaveGroupMaster", grpItem);
        }

        public async Task<IActionResult> InsertGroupMaster()
        {
            GroupMasterViewModel grpMaster = new GroupMasterViewModel();
            return PartialView("_groupSetup", grpMaster);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGroupMaster(GroupMasterViewModel groupMasterViewModel)
        {
            try
            {
                GroupMasterViewModel grpMaster = new GroupMasterViewModel
                {
                    GroupId = groupMasterViewModel.GroupId,
                    GroupCode = groupMasterViewModel.GroupCode,
                    GroupName = groupMasterViewModel.GroupName,
                    Sequence = groupMasterViewModel.Sequence,
                    OrgId = 1,
                    Status = groupMasterViewModel.Status,
                    IsDeleted = false,
                    GroupDescription = groupMasterViewModel.GroupDescription
                };
                #region validaate group code
                var groupMasterList = await _groupMasterHelper.GetGroupMasterViewModelDetails(grpMaster.GroupCode);
                #endregion

                if (grpMaster.GroupId == 0)
                {
                    if (groupMasterList?.Count == 0)
                    {
                        var objSaveGroupMaster = await _groupMasterHelper.SaveGroupMasterViewModelDetails(grpMaster);
                        if (objSaveGroupMaster.GroupId > 0)
                        {
                            groupMasterViewModel.Operation = "Insert";
                            groupMasterViewModel.Success = true;
                            groupMasterViewModel.Message = "Group code saved successfully!!!!!";
                        }
                        else
                        {
                            groupMasterViewModel.Success = false;
                            groupMasterViewModel.Message = "Group code did not saved successfully!!!!!";
                        }
                    }
                    else
                    {
                        groupMasterViewModel.Success = false;
                        groupMasterViewModel.Message = "Group code already exists!!!";
                    }
                }
                else
                {
                    if (groupMasterList?.Count < 2)
                    {
                        if (groupMasterList.Count == 1)
                        {
                            if (grpMaster.GroupCode == groupMasterList[0].GroupCode)
                            {
                                groupMasterViewModel.Success = false;
                                groupMasterViewModel.Message = "Group code did not saved successfully!!!!!";
                            }
                            else
                            {
                                var objSaveGroupMaster = await _groupMasterHelper.UpdateGroupMasterViewModelDetails(grpMaster);
                                if (objSaveGroupMaster.GroupId > 0)
                                {
                                    groupMasterViewModel.Operation = "Insert";
                                    groupMasterViewModel.Success = true;
                                    groupMasterViewModel.Message = "Group code saved successfully!!!!!";
                                }
                                else
                                {
                                    groupMasterViewModel.Success = false;
                                    groupMasterViewModel.Message = "Group code did not saved successfully!!!!!";
                                }
                            }
                        }
                        else
                        {


                            var objSaveGroupMaster = await _groupMasterHelper.UpdateGroupMasterViewModelDetails(grpMaster);
                            if (objSaveGroupMaster.GroupId > 0)
                            {
                                groupMasterViewModel.Operation = "Insert";
                                groupMasterViewModel.Success = true;
                                groupMasterViewModel.Message = "Group code saved successfully!!!!!";
                            }
                            else
                            {
                                groupMasterViewModel.Success = false;
                                groupMasterViewModel.Message = "Group code did not saved successfully!!!!!";
                            }
                        }
                    }
                    else
                    {
                        groupMasterViewModel.Success = false;
                        groupMasterViewModel.Message = "Group code already exists!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                groupMasterViewModel.Success = false;
                groupMasterViewModel.Message = "Group code did not saved successfully!!!!";
            }
            return Json(groupMasterViewModel);
        }

        public async Task<IActionResult> GetGroupMasters(string sidx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var groupMasterList = await _groupMasterHelper.GetGroupMasterViewModelDetails();
            int totalRecords = groupMasterList.Count;
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = groupMasterList
            };
            return Json(JsonConvert.SerializeObject(groupMasterList));
        }

        public async Task<IActionResult> UpdateGroupMaster(int group_id)
        {
            GroupMasterViewModel grpItem = new GroupMasterViewModel();
            var groupMasterItem = await _groupMasterHelper.GetGroupMasterViewModelById(group_id);
            if (groupMasterItem.Count > 0)
            {
                grpItem.GroupId = Convert.ToInt32(groupMasterItem[0].GroupId);
                grpItem.GroupCode = groupMasterItem[0].GroupCode;
                grpItem.GroupName = groupMasterItem[0].GroupName;
                grpItem.Sequence = groupMasterItem[0].Sequence;
                grpItem.Status = groupMasterItem[0].Status;
            }
            return View(grpItem);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGroupMaster(GroupMasterViewModel groupMasterView_Model)
        {
            GroupMasterViewModel grpMaster = new GroupMasterViewModel
            {
                GroupId = groupMasterView_Model.GroupId,
                GroupCode = groupMasterView_Model.GroupCode,
                GroupName = groupMasterView_Model.GroupName,
                Sequence = groupMasterView_Model.Sequence,
                OrgId = 1,
                Status = groupMasterView_Model.Status,
                IsDeleted = groupMasterView_Model.IsDeleted
            };
            var objSaveGroupMaster = await _groupMasterHelper.UpdateGroupMasterViewModelDetails(grpMaster);
            return View();
        }
        public async Task<ActionResult> DeleteGroupMaster(int group_id)
        {
            string result = string.Empty;

            GroupMasterViewModel grpItem = new GroupMasterViewModel();
            var groupMasterItem = await _groupMasterHelper.GetGroupMasterViewModelById(group_id);
            if (groupMasterItem.Count > 0)
            {
                grpItem.GroupId = Convert.ToInt32(groupMasterItem[0].GroupId);
                grpItem.GroupCode = groupMasterItem[0].GroupCode;
                grpItem.GroupName = groupMasterItem[0].GroupName;
                grpItem.Sequence = groupMasterItem[0].Sequence;
                grpItem.Status = groupMasterItem[0].Status;
                grpItem.IsDeleted = true;
            }
            var objSaveGroupMaster = await _groupMasterHelper.UpdateGroupMasterViewModelDetails(grpItem);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteGroupMaster(GroupMasterViewModel groupMasterViewModel)
        {
            string result = string.Empty;
            GroupMasterViewModel grpItem = new GroupMasterViewModel()
            {
                GroupId = Convert.ToInt32(groupMasterViewModel.GroupId),
                GroupCode = groupMasterViewModel.GroupCode,
                GroupName = groupMasterViewModel.GroupName,
                Sequence = groupMasterViewModel.Sequence,
                Status = groupMasterViewModel.Status,
                IsDeleted = true
            };
            var objDeleteGroupMaster = await _groupMasterHelper.UpdateGroupMasterViewModelDetails(grpItem);
            if (objDeleteGroupMaster.GroupId > 0)
            {
                groupMasterViewModel.Operation = "Insert";
                groupMasterViewModel.Success = true;
                groupMasterViewModel.Message = "Group code deleted successfully!!!!!";
            }
            else
            {
                groupMasterViewModel.Success = false;
                groupMasterViewModel.Message = "Group code did not deleted successfully!!!!!";
            }
            return Json(groupMasterViewModel);
        }
    }
}