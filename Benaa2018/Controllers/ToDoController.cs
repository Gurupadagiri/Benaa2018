using Benaa2018.Helper;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Controllers
{
    public class ToDoController : BaseController
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
        private readonly IHostingEnvironment _hostingEnvironment;

        public ToDoController(IMenuMasterHelper menuMasterHelper,
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
            ICompanyMasterHelper companyMasterHelper, ICalendarScheduleHelper calendarScheduleHelper, IHostingEnvironment hostingEnvironment) : base(menuMasterHelper,
            ownerMasterHelper, projectColorHelper, projectGroupHelper, projectMasterHelper, projectScheduleMasterHelper, projectStatusMasterHelper,
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
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.leftMenuText = "todoleftmenu";
            ToDoAllViewModel todoModel = new ToDoAllViewModel();
            var tagsList = await GetAllTags();
            ViewBag.TagsList = tagsList;
            ViewBag.UserBaseToDoModel = JsonConvert.SerializeObject(string.Empty);

            ViewBag.SubContractorsList = await GetAllDifferentUsers();
            for (int i = 0; i <= 2; i++)
            {
                todoModel.lstCheckListDetail.Add(new ToDochecklistDetailsViewModel
                {
                    ToDoCheckListId = i,
                });
            }

            todoModel.CalendarScheduledItemModel.CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1, 1, DateTime.MinValue);
            todoModel.CalendarScheduledItemModel.CalendarPhaseModels = await _calendarScheduleHelper.GetAllPhaseAsync(1, 1);
            todoModel.CalendarScheduledItemModel.CalendarTagModels = await _calendarScheduleHelper.GetAllTagAsync(1, 1);

            todoModel.CalendarScheduledItemModel.PredecessorInformationModels.Add(new PredecessorInformationViewModel
            {
                ScheduledItemId = 0,
                Lag = 0,
                TimeFrame = "1"
            });
            return View(todoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveToDo(ToDoAllViewModel toDoAllView)
        {
            try
            {
                var objToDoPrimary = await _todoMasterDetailsHelper.SaveToDoMasterDetails(toDoAllView.ToDoDetails);
                int todoDetailsId = objToDoPrimary.TodoDetailsID;
                if (todoDetailsId > 0)
                {
                    #region Checklist
                    ToDochecklistViewModel toDoCheckListViewModel = new ToDochecklistViewModel
                    {
                        TodoDetailsID = todoDetailsId,
                        ToDoAssignIsCheckListItem = toDoAllView.ToDoCheckList.ToDoAssignIsCheckListItem,
                        ToDoAssignIFilesCheckListItem = toDoAllView.ToDoCheckList.ToDoAssignIFilesCheckListItem
                    };
                    var objToDoCheckList = await SaveToDochecklistDetails(toDoCheckListViewModel);
                    if (toDoAllView.lstCheckListDetail.Count > 0)
                    {
                        foreach (var item in toDoAllView.lstCheckListDetail)
                        {
                            var objToDoDetailsList = await _toDoCheckListDetailsHelper.SaveToDochecklistDetailsDescription(item);
                        }
                    }
                    #endregion

                    toDoAllView.ToDoAllModels = await GetAllToDoDetails(toDoAllView.ToDoDetails.Project_ID);
                    toDoAllView.ToDoListContent = Newtonsoft.Json.JsonConvert.SerializeObject(toDoAllView.ToDoAllModels);
                    toDoAllView.Success = true;
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                toDoAllView.Success = false;
            }
            return Json(toDoAllView);
        }

        public async Task<IActionResult> SearchToDobyProject(int projectId = 0)
        {
            try
            {
                var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
            }
            catch (Exception ex)
            {
                return Json(string.Empty);
            }
        }

        public async Task<IActionResult> SaveTag(string tagTitle)
        {
            string result = string.Empty;
            TagMasterViewModel tagMasterView = new TagMasterViewModel()
            {
                TagName = tagTitle
            };
            var saveTag = await _tagMasterHelper.SaveTagMasterDetails(tagMasterView);
            if (saveTag != null && saveTag.TagId > 0)
            {
                result = "success";
            }
            return Json(result);
        }

        public async Task<IActionResult> PopulateTodoInfo(int todoDetailsId = 0)
        {
            ToDoAllViewModel toDoAllView = new ToDoAllViewModel();
            var tagsList = await GetAllTags();
            ViewBag.TagsList = tagsList;
            List<ToDoAllViewModel> lstToDoModel = new List<ToDoAllViewModel>();
            lstToDoModel = await GetAllToDoDetails1(todoDetailsId);
            if (lstToDoModel != null && lstToDoModel.Count > 0)
            {
                toDoAllView = lstToDoModel[0];
            }

            if (toDoAllView.lstCheckListDetail.Count == 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    toDoAllView.lstCheckListDetail.Add(new ToDochecklistDetailsViewModel
                    {
                        ToDoCheckListId = i,
                    });
                }
            }
            toDoAllView.CalendarScheduledItemModel.CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1, 1, DateTime.MinValue);
            toDoAllView.CalendarScheduledItemModel.CalendarPhaseModels = await _calendarScheduleHelper.GetAllPhaseAsync(1, 1);
            toDoAllView.CalendarScheduledItemModel.CalendarTagModels = await _calendarScheduleHelper.GetAllTagAsync(1, 1);
            toDoAllView.CalendarScheduledItemModel.PredecessorInformationModels.Add(new PredecessorInformationViewModel
            {
                ScheduledItemId = 0,
                Lag = 0,
                TimeFrame = "1"
            });

            var differentUsersList = await GetAllDifferentUsers();
            ViewBag.SubContractorsList = differentUsersList;
            toDoAllView.Operation = "Update";
            return PartialView("_toDoAddNew", toDoAllView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateToDo(ToDoAllViewModel toDoAllView)
        {
            string result = string.Empty;
            try
            {
                var objTags = await _tagToDoHelper.GetAllTags(toDoAllView.ToDoDetails.TodoDetailsID);
                string AllTagNames = string.Empty;
                if (objTags.Count > 0)
                {
                    ToDoTagViewModel TagsDetails = new ToDoTagViewModel();
                    foreach (var tag in objTags)
                    {
                        ToDoTagViewModel todoTagViewMdl = new ToDoTagViewModel()
                        {
                            ToDoTagid = tag.ToDoTagid,
                            TodoDetailsID = tag.TodoDetailsID,
                            Tagid = tag.Tagid

                        };
                        var objToTagSave = await _tagToDoHelper.DeleteToDoTagDetails(todoTagViewMdl);
                    }
                    int todoDetailsId = toDoAllView.ToDoDetails.TodoDetailsID;
                    if (todoDetailsId > 0)
                    {
                        if (toDoAllView.TagIds != null)
                        {
                            if (toDoAllView.TagIds.Length > 0)
                            {
                                foreach (var item in toDoAllView.TagIds)
                                {
                                    ToDoTagViewModel tagview = new ToDoTagViewModel()
                                    {
                                        Tagid = (int)item,
                                        TodoDetailsID = todoDetailsId
                                    };
                                    var objToTagSave = await _tagToDoHelper.SaveToDoTagDetails(tagview);
                                }
                            }
                        }

                        #region Assign user
                        #region GetAssignUser and Delete

                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(toDoAllView.ToDoDetails.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                ToDoAssignViewModel todoAssignUser = new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                };

                                var deleteAsignUser = _toDoAssignHelper.DeleteToDoAssignDetails(todoAssignUser);

                            }
                        }
                        #endregion

                        ToDoAssignViewModel todoAssignViewModel = new ToDoAssignViewModel
                        {
                            TodoDetailsID = todoDetailsId,
                            ToDoAssignID = 1,
                            ToDoUserAssignTypeId = 1
                        };
                        var objToUserAssign = await SaveToDoAssignDetails(todoAssignViewModel);
                        #endregion

                        #region get and delete checklist
                        #region GetCheckList


                        var objCheckList = await _toDoCheckListHelper.GetAllCheclistDetails(toDoAllView.ToDoDetails.TodoDetailsID);
                        string AllCheckLists = string.Empty;
                        List<ToDochecklistViewModel> lstChecklistModels = new List<ToDochecklistViewModel>();
                        List<ToDochecklistDetailsViewModel> lstCheckListDetails = new List<ToDochecklistDetailsViewModel>();
                        if (objCheckList.Count > 0)
                        {
                            ToDochecklistViewModel toDoCheckLsit = new ToDochecklistViewModel();

                            foreach (var checkList in objCheckList)
                            {
                                ToDochecklistViewModel todoChklst = new ToDochecklistViewModel()
                                {
                                    ToDoCheckListId = checkList.ToDoCheckListId,
                                    TodoDetailsID = checkList.TodoDetailsID,
                                    ToDoAssignIsCheckListItem = checkList.ToDoAssignIsCheckListItem,
                                    ToDoAssignIFilesCheckListItem = checkList.ToDoAssignIFilesCheckListItem
                                };

                                var deleteCheckList = await _toDoCheckListHelper.DeleteToDochecklistDetails(todoChklst);

                                var objCheckListDetails = await _toDoCheckListDetailsHelper.GetAllCheclistDetailsDescription(checkList.ToDoCheckListId);
                                if (objCheckListDetails.Count > 0)
                                {
                                    ToDochecklistDetailsViewModel toCheckListDetails = new ToDochecklistDetailsViewModel();
                                    foreach (var checkListDetails in objCheckListDetails)
                                    {
                                        ToDochecklistDetailsViewModel todoCheckListDetais = new ToDochecklistDetailsViewModel()
                                        {
                                            ToDochecklistDetailsViewModelId = checkListDetails.ToDochecklistDetailsViewModelId,
                                            ToDoCheckListId = checkListDetails.ToDoCheckListId,
                                            ToDoIsCheckList = checkListDetails.ToDoIsCheckList,
                                            ToDoCheckListTitle = checkListDetails.ToDoCheckListTitle,
                                            ToDoCheckListUserType = checkListDetails.ToDoCheckListUserType,
                                            ToDoCheckListUserId = checkListDetails.ToDoCheckListUserId
                                        };
                                        await _toDoCheckListDetailsHelper.DeleteToDochecklistDetailsDescription(todoCheckListDetais);
                                    }
                                }
                            }
                        }
                        #endregion

                        #endregion

                        #region Checklist
                        ToDochecklistViewModel toDoCheckListViewModel = new ToDochecklistViewModel
                        {
                            TodoDetailsID = todoDetailsId,
                            ToDoAssignIsCheckListItem = toDoAllView.ToDoCheckList.ToDoAssignIsCheckListItem,
                            ToDoAssignIFilesCheckListItem = toDoAllView.ToDoCheckList.ToDoAssignIFilesCheckListItem
                        };

                        //  var objToDoCheckList = _toDoCheckListHelper.SaveToDochecklistDetails(toDoCheckListViewModel);
                        var objToDoCheckList = await SaveToDochecklistDetails(toDoCheckListViewModel);

                        for (int k = 0; k < toDoAllView.ToDoCheckListItemIndex; k++)
                        {
                            ToDochecklistDetailsViewModel toDoCheckListDetailsViewModel = new ToDochecklistDetailsViewModel
                            {
                                ToDoCheckListId = objToDoCheckList.ToDoCheckListId,
                                ToDoIsCheckList = toDoAllView.lstCheckListDetail[k].ToDoIsCheckList,
                                ToDoCheckListTitle = toDoAllView.lstCheckListDetail[k].ToDoCheckListTitle,
                                ToDoCheckListUserType = 1,
                                ToDoCheckListUserId = toDoAllView.lstCheckListDetail[k].ToDoCheckListUserId

                            };
                            var objToDoDetailsList = await SaveToDochecklistDetailDetails(toDoCheckListDetailsViewModel);
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result);
        }

        public async Task<IActionResult> SearchToDo(string keywords, string assignedto, int usersAssignedTo, int status, string priority, string tags = "", int selectedProjectId = 0)
        {
            string result = string.Empty;
            var lstToDoSearchDetails = await GetAllToDoDetailsSearch(keywords, status, priority, tags, selectedProjectId);
            ViewBag.UserBaseToDoModel = null;
            ViewBag.UserBaseToDoModel = JsonConvert.SerializeObject(lstToDoSearchDetails);
            result = "success";
            return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
        }


        public async Task<ActionResult> DeleteToDo(string[] ToDoDetailsId, int projectId)
        {
            if (ToDoDetailsId != null)
            {
                foreach (var item in ToDoDetailsId)
                {
                    int todoDetailsIdperRow = Convert.ToInt32(item);
                    await _todoMasterDetailsHelper.DeleteToDoMasterDetails(Convert.ToString(todoDetailsIdperRow));
                    var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                    return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
                }
            }
            return Json(string.Empty);
        }
        public async Task<IActionResult> CopyToDo(string[] todoDetailIds, int projectId)
        {
            string result = string.Empty;
            if (todoDetailIds != null)
            {
                foreach (var item in todoDetailIds)
                {
                    List<ToDoAllViewModel> lstToDoModel = new List<ToDoAllViewModel>();
                    lstToDoModel = await GetAllToDoDetails1(Convert.ToInt32(item));
                    if (lstToDoModel.Count > 0)
                    {
                        var saveToDoCopy = await SaveToDoCopy(lstToDoModel);
                    }
                    var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                    return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
                }
            }
            return Json(result);
        }

        public async Task<IActionResult> SaveToDoIsComplete(string[] ToDoDetailsId)
        {
            try
            {
                if (ToDoDetailsId != null)
                {
                    foreach (var item in ToDoDetailsId)
                    {
                        int todoDetailsIdperRow = Convert.ToInt32(item);
                        var tododetailsId = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(todoDetailsIdperRow);
                        if (tododetailsId != null)
                        {
                            ToDoMasterDetailsViewModel todoDetails1 = new ToDoMasterDetailsViewModel()
                            {
                                TodoDetailsID = tododetailsId.TodoDetailsID,
                                Project_ID = tododetailsId.Project_ID,
                                Project_Site = tododetailsId.Project_Site,
                                Title = tododetailsId.Title,
                                Org_ID = tododetailsId.Org_ID,
                                TypeNote = tododetailsId.TypeNote,
                                IsMarkedComplete = true,
                                Priority = tododetailsId.Priority,
                                Duedate = tododetailsId.Duedate,
                                DueDatetime = tododetailsId.DueDatetime,
                                LinkToUnit = tododetailsId.LinkToUnit,
                                LinkToDaysStatus = tododetailsId.LinkToDaysStatus,
                                TillingWorkId = tododetailsId.TillingWorkId,
                                TillingDate = tododetailsId.TillingDate
                            };
                            var objToTagSave = await _todoMasterDetailsHelper.UpdateToDoMasterDetails(todoDetails1);
                            var lstToDoSearchDetails = await GetAllToDoDetails(objToTagSave.Project_ID);
                            return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(string.Empty);
        }

        public async Task<IActionResult> AssignToDoUser(string[] userids, string[] toDoDetailsId, bool isNotify,int projectId)
        {
            string result = string.Empty;
            try
            {
                if (toDoDetailsId != null)
                {
                    foreach (var todoId in toDoDetailsId)
                    {
                        var todoMaster = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(Convert.ToInt32(todoId));
                        ToDoMasterDetailsViewModel updateModel = null;
                        if (todoMaster != null && todoMaster.TodoDetailsID != 0)
                        {
                            todoMaster.AssignedUsers = userids;
                            updateModel = await _todoMasterDetailsHelper.UpdateToDoMasterDetails(todoMaster);
                        }
                        if (isNotify && updateModel != null)
                        {
                            string projectName = string.Empty;
                            if (todoMaster.Project_ID != 0)
                            {
                                projectName = await _projectMasterHelper.GetNameByProjectId(todoMaster.Project_ID);
                            }
                            var currentUser = await _userMasterHelper.GetUserByUserId(1);
                            var userInfo = await GetEmailFromUserId(userids);
                            Utility.SendAssignedMail(todoMaster.Title, projectName, currentUser.FullName,
                                _hostingEnvironment, userInfo);
                        }
                        var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                        return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result);
        }

        public async Task<List<Tuple<string, string>>> GetEmailFromUserId(string[] userIds)
        {
            List<Tuple<string, string>> tupleUserInfo = new List<Tuple<string, string>>();
            foreach (var user in userIds)
            {
                var id = Convert.ToInt32(user.Split("|")[0]);
                var userTypeId = Convert.ToInt32(user.Split("|")[1]);
                if (userTypeId == (int)AssignedUserType.Owner)
                {
                    var owerInfo = await _ownerMasterHelper.GetOwnerByOwnerId(id);
                    if (owerInfo == null) continue;
                    tupleUserInfo.Add(new Tuple<string, string>(owerInfo.Email, owerInfo.OwnerName));
                }
                else if (userTypeId == (int)AssignedUserType.InternalUser)
                {
                    var userInfo = await _userMasterHelper.GetUserByUserId(id);
                    if (userInfo == null) continue;
                    tupleUserInfo.Add(new Tuple<string, string>(userInfo.UserEmail, userInfo.FullName));
                }
                else if (userTypeId == (int)AssignedUserType.SubContractor)
                {
                    var subcontractorInfo = await _subContractorHelper.GetSubContractorBySubcontractId(id);
                    if (subcontractorInfo == null) continue;
                    tupleUserInfo.Add(new Tuple<string, string>(subcontractorInfo.Email, subcontractorInfo.Name));
                }
            }
            return tupleUserInfo;
        }

        public async Task<List<UserOwnerDifferentTypeViewModel>> GetAllDifferentUsers()
        {
            List<UserOwnerDifferentTypeViewModel> lstUserTypes = new List<UserOwnerDifferentTypeViewModel>();
            try
            {
                int index = 0;
                var lstOwners = await GetAllOwners();
                var lstInternalUsers = await GetAllUsers();
                var lstSubContractors = await GetAllSubContractors();
                if (lstOwners.Count > 0)
                {
                    foreach (var item in lstOwners)
                    {
                        index = index + 1;
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index,
                            UserOriginalId = item.OwnerID,
                            UserOriginaTypeId = (int)AssignedUserType.Owner,
                            UserOriginaTypeText = "Owners",
                            UserOwnerDifferentTypeValue = item.OwnerName
                        };
                        lstUserTypes.Add(item1);
                    }
                }
                if (lstInternalUsers.Count > 0)
                {
                    foreach (var item in lstInternalUsers)
                    {
                        index = index + 1;
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index,
                            UserOriginalId = item.UserID,
                            UserOriginaTypeId = (int)AssignedUserType.InternalUser,
                            UserOriginaTypeText = "Internal Users",
                            UserOwnerDifferentTypeValue = item.FullName
                        };
                        lstUserTypes.Add(item1);
                    }
                }
                if (lstSubContractors.Count > 0)
                {
                    foreach (var item in lstSubContractors)
                    {
                        index = index + 1;
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index,
                            UserOriginalId = item.SubContractorID,
                            UserOriginaTypeId = (int)AssignedUserType.SubContractor,
                            UserOriginaTypeText = "Subs",
                            UserOwnerDifferentTypeValue = item.SubcontractorName
                        };
                        lstUserTypes.Add(item1);
                    }
                }

                List<DifferentUserWithType> lstDifferentUserWithType = new List<DifferentUserWithType>();
                if (lstUserTypes?.Count > 0)
                {
                    foreach (var item in lstUserTypes)
                    {
                        DifferentUserWithType usertype1 = new DifferentUserWithType()
                        {
                            DifferentUserWithTypeId = item.UserOwnerDifferentTypeId,
                            DifferentUserWithTypewithTypeId = item.UserOriginaTypeId,
                            DifferentUserWithTypeOriginalId = item.UserOriginalId
                        };
                        lstDifferentUserWithType.Add(usertype1);
                    }
                }
                StringBuilder sbMyValue = new StringBuilder("");
                if (lstDifferentUserWithType?.Count > 0)
                {
                    foreach (var item in lstDifferentUserWithType)
                    {
                        sbMyValue.Append(item.DifferentUserWithTypeId + "," + item.DifferentUserWithTypewithTypeId + "," + item.DifferentUserWithTypeOriginalId + "|");
                    }

                }
                string userDetailsList = Convert.ToString(sbMyValue);
                HttpContext.Response.Cookies.Append("UserDetailsListCookie", userDetailsList);

            }
            catch (System.Exception ex)
            {

            }
            return lstUserTypes;
        }

        private async Task<List<TagMasterViewModel>> GetAllTags()
        {
            List<TagMasterViewModel> lstTags = new List<TagMasterViewModel>();
            try
            {
                var obj1 = await _tagMasterHelper.GetAllTagMasterDetails();
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        TagMasterViewModel selectListTag = new TagMasterViewModel
                        {
                            TagId = item.TagId,
                            TagName = item.TagName
                        };
                        lstTags.Add(selectListTag);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstTags;
        }

        public async Task<List<OwnerMasterViewModel>> GetAllOwners()
        {
            List<OwnerMasterViewModel> lstOwners = new List<OwnerMasterViewModel>();
            try
            {
                var obj1 = await _ownerMasterHelper.GetAllOwner();
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        OwnerMasterViewModel selectListOwner = new OwnerMasterViewModel
                        {
                            OwnerID = item.OwnerID,
                            OwnerName = item.OwnerName
                        };
                        lstOwners.Add(selectListOwner);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstOwners;
        }

        private async Task<List<ProjectSubcontractorConfigViewModel>> GetAllSubContractors()
        {
            List<ProjectSubcontractorConfigViewModel> lstSubContractors = new List<ProjectSubcontractorConfigViewModel>();
            try
            {
                var obj1 = await _subContractorHelper.GetAllSubContractorByOrg();
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        ProjectSubcontractorConfigViewModel selectListOwner = new ProjectSubcontractorConfigViewModel
                        {
                            SubContractorID = item.SubContractorID,
                            SubcontractorName = item.SubcontractorName
                        };
                        lstSubContractors.Add(selectListOwner);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstSubContractors;
        }

        private async Task<List<UserMasterViewModel>> GetAllUsers()
        {
            List<UserMasterViewModel> lstUsers = new List<UserMasterViewModel>();
            try
            {
                var obj1 = await _userMasterHelper.GetFullUserName();
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        UserMasterViewModel selectListUser = new UserMasterViewModel
                        {
                            UserID = item.UserID,
                            FullName = item.FullName
                        };
                        lstUsers.Add(selectListUser);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstUsers;
        }


        private async Task<List<ToDoAllViewModel>> GetAllToDoDetails(int projectId = 0)
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetails(projectId);
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        int totalNumberOfMessages = 0;
                        ToDoAllViewModel toDoView = new ToDoAllViewModel();
                        ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                        {
                            TodoDetailsID = item.TodoDetailsID,
                            Project_ID = item.Project_ID,
                            Project_Site = item.Project_Site,
                            Title = item.Title,
                            Org_ID = item.Org_ID,
                            TypeNote = item.TypeNote,
                            IsMarkedComplete = item.IsMarkedComplete,
                            Priority = item.Priority,
                            Duedate = item.Duedate,
                            DueDatetime = item.DueDatetime,
                            LinkToUnit = item.LinkToUnit,
                            LinkToDaysStatus = item.LinkToDaysStatus,
                            TillingWorkId = item.TillingWorkId,
                            TillingDate = item.TillingDate,
                            TillingTime = item.TillingTime,
                            ReminderId = item.ReminderId,
                            CreatedBy = "Test User",
                            IsCheckedList = true
                        };
                        var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        string AllTagNames = string.Empty;
                        List<TagMasterViewModel> lstTagMasters = new List<TagMasterViewModel>();
                        if (objTags.Count > 0)
                        {
                            TagMasterViewModel TagsDetails = new TagMasterViewModel();
                            foreach (var tag in objTags)
                            {
                                int tagids = tag.Tagid;
                                List<TagMasterViewModel> lstTagMaster = new List<TagMasterViewModel>();
                                lstTagMaster = await _tagMasterHelper.GetAllTagMasterDetails(tagids);
                                if (lstTagMaster.Count > 0)
                                {
                                    string tagName = lstTagMaster[0].TagName.ToString();
                                    TagMasterViewModel tagMaster = new TagMasterViewModel
                                    {
                                        TagId = tagids,
                                        TagName = tagName
                                    };
                                    lstTagMasters.Add(tagMaster);
                                    AllTagNames = AllTagNames + tagName + ",";
                                }
                            }
                            toDoView.TotalTagCount = objTags.Count;
                        }
                        #region GetAssign
                        string UserDetails = string.Empty;
                        int UserDetailsCount = 0;
                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(item.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                lstAssignModels.Add(new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                });
                            }

                            if (lstAssignModels.Count > 0)
                            {
                                foreach (var itemUser in lstAssignModels)
                                {
                                    if (itemUser.UserID == 0) continue;
                                    switch (itemUser.ToDoUserAssignTypeId)
                                    {
                                        case 1:
                                            if (itemUser.UserID != 0) { }
                                            var UserOwner = await _ownerMasterHelper.GetOwnerByOwnerId(itemUser.UserID);
                                            UserDetails = UserOwner.OwnerName + " ," + UserDetails;
                                            break;
                                        case 2:
                                            var users = await _userMasterHelper.GetUserByUserId(itemUser.UserID);
                                            UserDetails = users.UserName + " ," + UserDetails;
                                            break;

                                        case 3:
                                            var subContract = await _subContractorHelper.GetSubContractorBySubcontractId(itemUser.UserID);
                                            UserDetails = subContract.Name + " ," + UserDetails;
                                            break;
                                    }
                                }
                                UserDetailsCount = lstAssignModels.Count - 1;
                            }

                        }
                        #endregion
                        #region Total number of messages
                        var objToDoMessage = await _toDoMessageHelper.GetAllToDoMessageDetailsById(item.TodoDetailsID);
                        if (objToDoMessage != null && objToDoMessage.Count > 0)
                        {
                            totalNumberOfMessages = objToDoMessage.Count;
                        }
                        #endregion
                        toDoView.ToDoDetails = todoMasterDetails;
                        toDoView.TotalNumberOfMessages = totalNumberOfMessages;
                        toDoView.lstTags = lstTagMasters;
                        toDoView.TagNames = AllTagNames.TrimEnd(',');
                        toDoView.UserNames = UserDetails.TrimEnd(',');
                        toDoView.TotalUserNameCount = UserDetailsCount;
                        lstToDos.Add(toDoView);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstToDos;
        }

        private async Task<List<ToDoAllViewModel>> GetAllToDoDetailsSearch(string title = "", int status = 0, string priority = "", string tags = "", int selectedProjectId = 0)
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                List<ToDoMasterDetailsViewModel> lstToDoSearchDetails = new List<ToDoMasterDetailsViewModel>();
                var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsByTitle(selectedProjectId, title, status, priority);
                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        ToDoAllViewModel toDoView = new ToDoAllViewModel();
                        ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                        {
                            TodoDetailsID = item.TodoDetailsID,
                            Project_ID = item.Project_ID,
                            Project_Site = item.Project_Site,
                            Title = item.Title,
                            Org_ID = item.Org_ID,
                            TypeNote = item.TypeNote,
                            IsMarkedComplete = item.IsMarkedComplete,
                            Priority = item.Priority,
                            Duedate = item.Duedate,
                            DueDatetime = item.DueDatetime,
                            LinkToUnit = item.LinkToUnit,
                            LinkToDaysStatus = item.LinkToDaysStatus,
                            TillingWorkId = item.TillingWorkId,
                            TillingDate = item.TillingDate,
                            TillingTime = item.TillingTime,
                            ReminderId = item.ReminderId,
                            CreatedBy = "Test User",
                            IsCheckedList = true
                        };
                        var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        string AllTagNames = string.Empty;
                        List<TagMasterViewModel> lstTagMasters = new List<TagMasterViewModel>();
                        if (objTags.Count > 0)
                        {
                            TagMasterViewModel TagsDetails = new TagMasterViewModel();
                            foreach (var tag in objTags)
                            {
                                int tagids = tag.Tagid;
                                List<TagMasterViewModel> lstTagMaster = new List<TagMasterViewModel>();
                                lstTagMaster = await _tagMasterHelper.GetAllTagMasterDetails(tagids);
                                if (lstTagMaster.Count > 0)
                                {
                                    string tagName = lstTagMaster[0].TagName.ToString();
                                    TagMasterViewModel tagMaster = new TagMasterViewModel
                                    {
                                        TagId = tagids,
                                        TagName = tagName
                                    };
                                    lstTagMasters.Add(tagMaster);
                                    AllTagNames = AllTagNames + tagName + ",";
                                }
                            }
                            toDoView.TotalTagCount = objTags.Count;
                        }
                        #region GetAssign
                        string UserDetails = string.Empty;
                        int UserDetailsCount = 0;
                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(item.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                lstAssignModels.Add(new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                });
                            }
                            if (lstAssignModels.Count > 0)
                            {
                                foreach (var itemUser in lstAssignModels)
                                {
                                    var Users = _userMasterHelper.GetUserByUserId(itemUser.UserID);
                                    UserDetails = Users.Result.UserName + " ," + UserDetails;
                                }
                                UserDetailsCount = lstAssignModels.Count - 1;
                            }
                        }
                        #endregion
                        toDoView.ToDoDetails = todoMasterDetails;
                        toDoView.TotalNumberOfMessages = 0;
                        toDoView.lstTags = lstTagMasters;
                        toDoView.TagNames = AllTagNames;
                        toDoView.UserNames = UserDetails;
                        toDoView.TotalUserNameCount = UserDetailsCount;
                        lstToDos.Add(toDoView);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lstToDos;
        }

        public async Task<ToDoAssignViewModel> SaveToDoAssignDetails(ToDoAssignViewModel todoAssignViewModel)
        {
            ToDoAssignViewModel toDoAssignView = new ToDoAssignViewModel();
            try
            {
                var item = await _toDoAssignHelper.SaveToDoAssignDetails(todoAssignViewModel);
                if (item.ToDoAssignID > 0)
                {
                    toDoAssignView.ToDoAssignID = item.ToDoAssignID;
                }
            }
            catch (Exception ex)
            {
                toDoAssignView = null;
            }
            return toDoAssignView;
        }

        public async Task<IActionResult> SearchToDoMessage(int ToDoDetailsId)
        {
            string result = string.Empty;
            List<ToDoMessageViewModel> lstTodoMessages = new List<ToDoMessageViewModel>();
            var lstToDoMessage = await _toDoMessageHelper.GetAllToDoMessageDetailsById(ToDoDetailsId);
            if (lstToDoMessage != null && lstToDoMessage.Count > 0)
            {
                foreach (var item in lstToDoMessage)
                {
                    ToDoMessageViewModel toDoMessage = new ToDoMessageViewModel()
                    {
                        ToDoMessageId = item.ToDoMessageId,
                        ToDoDetailsId = item.ToDoDetailsId,
                        ToDoMessageTitle = item.ToDoMessageTitle,
                        IsOwner = item.IsOwner,
                        IsSub = item.IsSub,
                        CreatdDate = item.CreatdDate,
                        CreatedBy = item.CreatedBy
                    };
                    lstTodoMessages.Add(toDoMessage);
                }
            }
            result = "success";
            return Json(JsonConvert.SerializeObject(lstTodoMessages));
        }

        public async Task<IActionResult> SaveToDoMessage(int todoDetailsId, string titleMessage, bool owner, bool notify, bool sub)
        {
            string result = string.Empty;
            ToDoMessageViewModel todoMessages = new ToDoMessageViewModel()
            {
                ToDoDetailsId = todoDetailsId,
                ToDoMessageTitle = titleMessage,
                IsOwner = owner,
                IsSub = sub
            };
            var saveToDoMessage = await _toDoMessageHelper.SaveToDoMessage(todoMessages);
            if (saveToDoMessage != null && saveToDoMessage.ToDoMessageId > 0)
            {
                result = "success";
            }
            return Json(result);
        }

        private async Task<ToDochecklistViewModel> SaveToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel)
        {
            ToDochecklistViewModel toDoCheckListView = new ToDochecklistViewModel();
            try
            {
                var item = await _toDoCheckListHelper.SaveToDochecklistDetails(toDochecklistViewModel);
                if (item.ToDoCheckListId > 0)
                {
                    toDoCheckListView.ToDoCheckListId = item.ToDoCheckListId;
                }
            }
            catch (Exception ex)
            {
                toDoCheckListView = null;
            }
            return toDoCheckListView;
        }

        private async Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailDetails(ToDochecklistDetailsViewModel toDochecklistDetailsViewModel)
        {
            ToDochecklistDetailsViewModel toDochecklistDetailsl = new ToDochecklistDetailsViewModel();
            try
            {
                var item = await _toDoCheckListDetailsHelper.SaveToDochecklistDetailsDescription(toDochecklistDetailsViewModel);
                if (item.ToDochecklistDetailsViewModelId > 0)
                {
                    toDochecklistDetailsl.ToDochecklistDetailsViewModelId = item.ToDochecklistDetailsViewModelId;
                }
            }
            catch (Exception ex)
            {
                toDochecklistDetailsl = null;
            }
            return toDochecklistDetailsl;
        }

        private async Task<List<ToDoAllViewModel>> GetAllToDoDetails1(int todoDetailsId = 0)
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                var todoDetails = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(todoDetailsId);
                if (todoDetails != null)
                {
                    List<ToDoTagViewModel> lstTagMasters = new List<ToDoTagViewModel>();
                    ToDoAllViewModel toDoView = new ToDoAllViewModel();
                    ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                    {
                        TodoDetailsID = todoDetails.TodoDetailsID,
                        Project_ID = todoDetails.Project_ID,
                        Project_Site = todoDetails.Project_Site,
                        Title = todoDetails.Title,
                        Org_ID = todoDetails.Org_ID,
                        TypeNote = todoDetails.TypeNote,
                        IsMarkedComplete = todoDetails.IsMarkedComplete,
                        Priority = todoDetails.Priority,
                        Duedate = todoDetails.Duedate,
                        DueDatetime = todoDetails.DueDatetime,
                        LinkToUnit = todoDetails.LinkToUnit,
                        LinkToDaysStatus = todoDetails.LinkToDaysStatus,
                        TillingWorkId = todoDetails.TillingWorkId,
                        TillingDate = todoDetails.TillingDate,
                        TillingTime = todoDetails.TillingTime,
                        ReminderId = todoDetails.ReminderId
                    };
                    var objTags = await _tagToDoHelper.GetAllTags(todoDetails.TodoDetailsID);
                    string AllTagNames = string.Empty;
                    if (objTags.Count > 0)
                    {
                        ToDoTagViewModel TagsDetails = new ToDoTagViewModel();
                        foreach (var tag in objTags)
                        {
                            lstTagMasters.Add(new ToDoTagViewModel()
                            {
                                TodoDetailsID = tag.TodoDetailsID,
                                Tagid = tag.Tagid
                            });
                        }
                        toDoView.TotalTagCount = objTags.Count;
                        toDoView.lstToDoDetails = lstTagMasters;
                    }
                    #region GetAssign

                    var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(todoDetails.TodoDetailsID);
                    string AllAssignNames = string.Empty;
                    List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                    if (objAssign.Count > 0)
                    {
                        ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                        foreach (var assign in objAssign)
                        {
                            lstAssignModels.Add(new ToDoAssignViewModel()
                            {
                                ToDoAssignID = assign.ToDoAssignID,
                                UserID = assign.UserID,
                                TodoDetailsID = assign.TodoDetailsID,
                                ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                            });
                        }
                    }
                    #endregion

                    #region GetCheckList
                    var objCheckList = await _toDoCheckListHelper.GetAllCheclistDetails(todoDetails.TodoDetailsID);
                    string AllCheckLists = string.Empty;
                    List<ToDochecklistViewModel> lstChecklistModels = new List<ToDochecklistViewModel>();
                    List<ToDochecklistDetailsViewModel> lstCheckListDetails = new List<ToDochecklistDetailsViewModel>();
                    if (objCheckList.Count > 0)
                    {
                        ToDochecklistViewModel toDoCheckLsit = new ToDochecklistViewModel();
                        foreach (var checkList in objCheckList)
                        {
                            var objCheckListDetails = await _toDoCheckListDetailsHelper.GetAllCheclistDetailsDescription(checkList.ToDoCheckListId);
                            if (objCheckListDetails.Count > 0)
                            {
                                ToDochecklistDetailsViewModel toCheckListDetails = new ToDochecklistDetailsViewModel();
                                foreach (var checkListDetails in objCheckListDetails)
                                {
                                    lstCheckListDetails.Add(new ToDochecklistDetailsViewModel()
                                    {
                                        ToDochecklistDetailsViewModelId = checkListDetails.ToDochecklistDetailsViewModelId,
                                        ToDoCheckListId = checkListDetails.ToDoCheckListId,
                                        ToDoIsCheckList = checkListDetails.ToDoIsCheckList,
                                        ToDoCheckListTitle = checkListDetails.ToDoCheckListTitle,
                                        ToDoCheckListUserType = checkListDetails.ToDoCheckListUserType,
                                        ToDoCheckListUserId = checkListDetails.ToDoCheckListUserId
                                    });
                                }
                            }

                            lstChecklistModels.Add(new ToDochecklistViewModel()
                            {
                                ToDoCheckListId = checkList.ToDoCheckListId,
                                TodoDetailsID = checkList.TodoDetailsID,
                                ToDoAssignIsCheckListItem = checkList.ToDoAssignIsCheckListItem,
                                ToDoAssignIFilesCheckListItem = checkList.ToDoAssignIFilesCheckListItem
                            });
                        }
                    }
                    #endregion

                    toDoView.ToDoDetails = todoMasterDetails;
                    toDoView.TotalNumberOfMessages = 1;
                    toDoView.lstToDoDetails = lstTagMasters;
                    toDoView.TagNames = AllTagNames;
                    toDoView.lstAssigns = lstAssignModels;
                    toDoView.lstCheckLists = lstChecklistModels;
                    toDoView.lstCheckListDetails = lstCheckListDetails;
                    toDoView.lstCheckListDetail = lstCheckListDetails;
                    lstToDos.Add(toDoView);
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstToDos;
        }

        private async Task<int> SaveToDoCopy(List<ToDoAllViewModel> lstTodoView)
        {
            int result = 0;
            try
            {
                if (lstTodoView.Count > 0)
                {
                    foreach (var toDoItem in lstTodoView)
                    {
                        if (toDoItem.ToDoDetails != null)
                        {
                            var insertToDoDetails = await _todoMasterDetailsHelper.SaveToDoMasterDetails(toDoItem.ToDoDetails);

                            if (insertToDoDetails.TodoDetailsID > 0)
                            {
                                #region SaveTags
                                if (toDoItem.lstToDoDetails != null)
                                {
                                    foreach (var itemTag in toDoItem.lstToDoDetails)
                                    {
                                        ToDoTagViewModel todoTag = new ToDoTagViewModel()
                                        {
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoTagid = itemTag.Tagid
                                        };
                                        var objToTagSave = await _tagToDoHelper.SaveToDoTagDetails(todoTag);
                                    }
                                }
                                #endregion

                                #region SaveAssign
                                if (toDoItem.lstAssigns != null)
                                {
                                    foreach (var itemAssign in toDoItem.lstAssigns)
                                    {
                                        ToDoAssignViewModel toDoAssignView = new ToDoAssignViewModel()
                                        {
                                            UserID = itemAssign.UserID,
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoUserAssignTypeId = itemAssign.ToDoUserAssignTypeId
                                        };
                                        var assignItem = await SaveToDoAssignDetails(toDoAssignView);
                                    }
                                }

                                #endregion

                                #region SaveCheckList
                                if (toDoItem.lstCheckLists != null)
                                {
                                    foreach (var itemAssign in toDoItem.lstCheckLists)
                                    {
                                        ToDochecklistViewModel toDoCheckLsit = new ToDochecklistViewModel()
                                        {
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoAssignIsCheckListItem = itemAssign.ToDoAssignIsCheckListItem,
                                            ToDoAssignIFilesCheckListItem = itemAssign.ToDoAssignIFilesCheckListItem
                                        };
                                        var assignCheckList = await SaveToDochecklistDetails(toDoCheckLsit);
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<IActionResult> IsToDoComplete(int todoId, int projectId)
        {
            try
            {
                var todoMaster = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(todoId);
                if (todoMaster != null && todoMaster.TodoDetailsID != 0)
                {
                    todoMaster.IsMarkedComplete = true;
                    await _todoMasterDetailsHelper.UpdateToDoMasterDetails(todoMaster);
                }
                var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
            }
            catch (Exception ex)
            {
                var lstToDoSearchDetails = await GetAllToDoDetails(projectId);
                return Json(JsonConvert.SerializeObject(lstToDoSearchDetails));
            }
        }
    }
}