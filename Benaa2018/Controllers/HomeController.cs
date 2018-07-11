using Benaa2018.Data.Interfaces;
using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

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
        private readonly IDetaildPermissionHelper _detaildPermissionHelper;
        private readonly IHostingEnvironment _environment;
        public HomeController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper, IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper, IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper, IToDoMasterHelper toDoMasterHelper,
            IUserMasterHelper userMasterHelper, IWarrentyAlertHelper warrentyAlertHelper,
            ICompanyMasterHelper companyMasterHelper, IDetaildPermissionHelper detaildPermissionHelper, IHostingEnvironment environment) : base(menuMasterHelper,
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
            _detaildPermissionHelper = detaildPermissionHelper;
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

        [HttpPost]
        public async Task<JsonResult> GetProjectInfoByProjectID(int projectID)
        {
            var projectInfo = new Tuple<ProjectMasterViewModel, OwnerMasterViewModel>(
                await _projectMasterHelper.GetProjectDetailsProjectId(projectID),
                await _ownerMasterHelper.GetOwnerInfoByInfo(projectID));
            return Json(projectInfo);
        }

        [HttpGet]
        public JsonResult SaveProjectGroup(string jobGroupName)
        {
            var projectIngo = _projectGroupHelper.SaveProjectGroup(1, jobGroupName);
            return Json("success");
        }

        [HttpPost]
        public async Task<IActionResult> FilterProjectDetailsAsync(string[] projectGroupId, string[] managerID)
        {
            BaseViewModel homeViewModel = new BaseViewModel
            {
                ProjectMasterModels = await _projectMasterHelper.FilterProjectInfo(projectGroupId, managerID),
                ProjectManagerMasterModels = await _projectMasterHelper.GetAllManagers(),
                ProjectGroupModels = await _projectGroupHelper.GetProjectGroupByUserID(1),
                //ToDoMasterModels = await _toDoMasterHelper.GetAllToDoList()
            };
            return PartialView("_leftMenu", homeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FilterToDoListAsync(int days)
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                ToDoMasterModels = await _toDoMasterHelper.GetFilteredToDoList(days)
            };
            return PartialView("_toDoList", homeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProjectsAsync(string[] projectGroups,
            string[] projectManagers,
            string[] status,
            string[] projectTypes,
            string searchKeyWord,
            string[] mappedStatus,
            string searchText)
        {
            BaseViewModel homeViewModel = new BaseViewModel
            {
                ProjectMasterModels = await _projectMasterHelper.FilterProjectResults(projectGroups, projectManagers, status, projectTypes, searchKeyWord, mappedStatus, searchText)
            };
            return PartialView("_infoModel", homeViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> GetProjectDetailsbyProjectIdAsync(int projectId)
        {
            var projectInfo = await _projectMasterHelper.GetProjectDetailsProjectId(projectId);
            return Json(projectInfo);
        }

        public async Task<IActionResult> UserPreferences()
        {
            //ViewModel mymodel = new ViewModel();
            //mymodel.Teachers = GetTeachers();
            //mymodel.Students = GetStudents();
            return View();
        }

        //[HttpPost]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> UserPreferences(UserPreferenceViewModel userPreferenceViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.result = 1;
        //        return View(userPreferenceViewModel);
        //        //return BadRequest(ModelState);
        //    }

        //    UserMasterViewModel userMasterViewModel = new UserMasterViewModel
        //    {
        //        UserFirstName = userPreferenceViewModel.usermasters.UserFirstName,
        //        UserLastName = userPreferenceViewModel.usermasters.UserLastName,
        //        UserEmail = userPreferenceViewModel.usermasters.UserEmail,
        //        UserEnabled = userPreferenceViewModel.usermasters.UserEnabled,
        //        UserLoginEnabled = userPreferenceViewModel.usermasters.UserLoginEnabled,
        //        UserPhone = userPreferenceViewModel.usermasters.UserPhone,
        //        UserCellEmail = userPreferenceViewModel.usermasters.UserCellEmail,
        //        UserContactInfo = userPreferenceViewModel.usermasters.UserContactInfo,
        //        UserDefaultTimeClock = userPreferenceViewModel.usermasters.UserDefaultTimeClock,
        //        UserDefaultLabourCost = userPreferenceViewModel.usermasters.UserDefaultLabourCost,
        //        UserIsAlert = userPreferenceViewModel.usermasters.UserIsAlert,
        //        UserAlertSchedule = userPreferenceViewModel.usermasters.UserAlertSchedule,
        //        UserIsAutomaticAccess = userPreferenceViewModel.usermasters.UserIsAutomaticAccess,
        //        UserName = userPreferenceViewModel.usermasters.UserName,
        //        UserPassword = userPreferenceViewModel.usermasters.UserPassword,
        //        UserIsForumHandle = userPreferenceViewModel.usermasters.UserIsForumHandle,
        //        UserForumHandle = userPreferenceViewModel.usermasters.UserForumHandle
        //    };


        //    var obj1 = await _userMasterHelper.GetUserByUserNameInDetails(userMasterViewModel.UserName);
        //    #region user name exists or not
        //    int userid = 0;
        //    if (obj1.Count > 0)
        //    {
        //        ViewBag.result = 2;
        //        return View(userPreferenceViewModel);
        //    }
        //    else
        //    {

        //        var obj = await _userMasterHelper.SaveUserMaster(userMasterViewModel);
        //        userid = Convert.ToInt32(obj.UserID);
        //    }
        //    #endregion

        //    if (userid > 1)
        //    {
        //        DetaildPermissionViewModel detailedPermissionViewModel = new DetaildPermissionViewModel
        //        {

        //            UserID = userid,
        //            IsViewAll = userPreferenceViewModel.permissions.IsViewAll,
        //            IsAddAll = userPreferenceViewModel.permissions.IsAddAll,
        //            IsEditall = userPreferenceViewModel.permissions.IsEditall,
        //            IsDeleteAll = userPreferenceViewModel.permissions.IsDeleteAll,
        //            IsJobInfoView = userPreferenceViewModel.permissions.IsJobInfoView,
        //            IsJobInfoAdd = userPreferenceViewModel.permissions.IsJobInfoAdd,
        //            IsJobInfoEdit = userPreferenceViewModel.permissions.IsJobInfoEdit,
        //            IsJobInfodelete = userPreferenceViewModel.permissions.IsJobInfodelete,
        //            IsViewOwnerSite = userPreferenceViewModel.permissions.IsViewOwnerSite,
        //            IsPriceViewing = userPreferenceViewModel.permissions.IsPriceViewing,
        //            IsOwnerPaymentsView = userPreferenceViewModel.permissions.IsOwnerPaymentsView,
        //            IsOwnerPaymentsAdd = userPreferenceViewModel.permissions.IsOwnerPaymentsAdd,
        //            IsOwnerPaymentsEdit = userPreferenceViewModel.permissions.IsOwnerPaymentsEdit,
        //            IsOwnerPaymentsDelete = userPreferenceViewModel.permissions.IsOwnerPaymentsDelete,
        //            IsLeadsView = userPreferenceViewModel.permissions.IsLeadsView,
        //            IsLeadsAdd = userPreferenceViewModel.permissions.IsLeadsAdd,
        //            IsLeadsEdit = userPreferenceViewModel.permissions.IsLeadsEdit,
        //            IsLeadsDelete = userPreferenceViewModel.permissions.IsLeadsDelete,
        //            IsLeadsAssignSalesperson = userPreferenceViewModel.permissions.IsLeadsAssignSalesperson,
        //            IsLeadsViewOtherSalesperson = userPreferenceViewModel.permissions.IsLeadsViewOtherSalesperson,
        //            IsLeadsConvertToJobsite = userPreferenceViewModel.permissions.IsLeadsConvertToJobsite,
        //            IsLeadsExportToExcel = userPreferenceViewModel.permissions.IsLeadsExportToExcel,
        //            IsCustomerContactsViewReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsViewReadOnly,
        //            IsCustomerContactsView = userPreferenceViewModel.permissions.IsCustomerContactsView,
        //            IsCustomerContactsAddReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsAddReadOnly,
        //            IsCustomerContactsAdd = userPreferenceViewModel.permissions.IsCustomerContactsAdd,
        //            IsCustomerContactsEdit = userPreferenceViewModel.permissions.IsCustomerContactsEdit,
        //            IsCustomerContactsDelete = userPreferenceViewModel.permissions.IsCustomerContactsDelete,

        //            IsViewAllCustomerContactsReadonly = userPreferenceViewModel.permissions.IsViewAllCustomerContactsReadonly,
        //            IsViewAllCustomerContacts = userPreferenceViewModel.permissions.IsViewAllCustomerContacts,
        //            IsCustomerContactsExportToExcel = userPreferenceViewModel.permissions.IsCustomerContactsExportToExcel,

        //            IsToDoView = userPreferenceViewModel.permissions.IsToDoView,
        //            IsToDoAdd = userPreferenceViewModel.permissions.IsToDoView,
        //            IsToDoEdit = userPreferenceViewModel.permissions.IsToDoEdit,
        //            IsToDoDelete = userPreferenceViewModel.permissions.IsToDoDelete,
        //            IsToDoAssignUsers = userPreferenceViewModel.permissions.IsToDoAssignUsers,
        //            IsToDoGlobal = userPreferenceViewModel.permissions.IsToDoGlobal,


        //            IsLogsView = userPreferenceViewModel.permissions.IsLogsView,
        //            IsLogsAdd = userPreferenceViewModel.permissions.IsLogsAdd,
        //            IsLogsEdit = userPreferenceViewModel.permissions.IsLogsEdit,
        //            IsLogsDelete = userPreferenceViewModel.permissions.IsLogsDelete,

        //            IsBidsView = userPreferenceViewModel.permissions.IsBidsView,
        //            IsBidsAdd = userPreferenceViewModel.permissions.IsBidsAdd,
        //            IsBidsEdit = userPreferenceViewModel.permissions.IsBidsEdit,
        //            IsBidsDelete = userPreferenceViewModel.permissions.IsBidsDelete,

        //            IsCalendarView = userPreferenceViewModel.permissions.IsCalendarView,
        //            IsCalendarAdd = userPreferenceViewModel.permissions.IsCalendarAdd,
        //            IsCalendarEdit = userPreferenceViewModel.permissions.IsCalendarEdit,
        //            IsCalendarDelete = userPreferenceViewModel.permissions.IsCalendarDelete,
        //            IsSetBaseline = userPreferenceViewModel.permissions.IsSetBaseline,

        //            IsDocumentsView = userPreferenceViewModel.permissions.IsDocumentsView,
        //            IsDocumentsAdd = userPreferenceViewModel.permissions.IsDocumentsAdd,
        //            IsDocumentsEdit = userPreferenceViewModel.permissions.IsDocumentsEdit,
        //            IsDocumentsDelete = userPreferenceViewModel.permissions.IsDocumentsDelete,

        //            IsDocumentsAccessSubOwner = userPreferenceViewModel.permissions.IsDocumentsAccessSubOwner,
        //            IsDocumentsSignature = userPreferenceViewModel.permissions.IsDocumentsSignature,

        //            IsVideosView = userPreferenceViewModel.permissions.IsVideosView,
        //            IsVideosAdd = userPreferenceViewModel.permissions.IsVideosAdd,
        //            IsVideosEdit = userPreferenceViewModel.permissions.IsVideosEdit,
        //            IsVideosDelete = userPreferenceViewModel.permissions.IsVideosDelete,

        //            IsPhotosView = userPreferenceViewModel.permissions.IsPhotosView,
        //            IsPhotosAdd = userPreferenceViewModel.permissions.IsPhotosAdd,
        //            IsPhotosEdit = userPreferenceViewModel.permissions.IsPhotosEdit,
        //            IsPhotosDelete = userPreferenceViewModel.permissions.IsPhotosDelete,

        //            IsMessagesView = userPreferenceViewModel.permissions.IsMessagesView,
        //            IsMessagesAdd = userPreferenceViewModel.permissions.IsMessagesAdd,
        //            IsMessagesAddReadonly = userPreferenceViewModel.permissions.IsMessagesAddReadonly,
        //            IsMessagesEdit = userPreferenceViewModel.permissions.IsMessagesEdit,
        //            IsMessagesEditReadonly = userPreferenceViewModel.permissions.IsMessagesEditReadonly,
        //            IsMessagesDelete = userPreferenceViewModel.permissions.IsMessagesDelete,
        //            IsMessageGlobal = userPreferenceViewModel.permissions.IsMessageGlobal,

        //            IsRFIView = userPreferenceViewModel.permissions.IsRFIView,
        //            IsRFIAdd = userPreferenceViewModel.permissions.IsRFIAdd,
        //            IsRFIEdit = userPreferenceViewModel.permissions.IsRFIEdit,
        //            IsRFIDelete = userPreferenceViewModel.permissions.IsRFIDelete,

        //            IsChangeOrdersView = userPreferenceViewModel.permissions.IsChangeOrdersView,
        //            IsChangeOrdersAdd = userPreferenceViewModel.permissions.IsChangeOrdersAdd,
        //            IsChangeOrdersEdit = userPreferenceViewModel.permissions.IsChangeOrdersEdit,
        //            IsChangeOrdersDelete = userPreferenceViewModel.permissions.IsChangeOrdersDelete,
        //            IsChangeOrdersCostViewing = userPreferenceViewModel.permissions.IsChangeOrdersCostViewing,

        //            IsSelectionsView = userPreferenceViewModel.permissions.IsSelectionsView,
        //            IsSelectionsAdd = userPreferenceViewModel.permissions.IsSelectionsAdd,
        //            IsSelectionsEdit = userPreferenceViewModel.permissions.IsSelectionsEdit,
        //            IsSelectionsDelete = userPreferenceViewModel.permissions.IsSelectionsDelete,
        //            IsSelectionsCostViewing = userPreferenceViewModel.permissions.IsSelectionsCostViewing,

        //            IsBillView = userPreferenceViewModel.permissions.IsBillView,
        //            IsBillAdd = userPreferenceViewModel.permissions.IsBillAdd,
        //            IsBillEdit = userPreferenceViewModel.permissions.IsBillEdit,
        //            IsBillDelete = userPreferenceViewModel.permissions.IsBillDelete,
        //            IsBillAccounting = userPreferenceViewModel.permissions.IsBillAccounting,
        //            IsBillNoPriceLimit = userPreferenceViewModel.permissions.IsBillNoPriceLimit,
        //            IsBillCostViewing = userPreferenceViewModel.permissions.IsBillCostViewing,

        //            IsWarrantyView = userPreferenceViewModel.permissions.IsWarrantyView,
        //            IsWarrantyAdd = userPreferenceViewModel.permissions.IsWarrantyAdd,
        //            IsWarrantyEdit = userPreferenceViewModel.permissions.IsWarrantyEdit,
        //            IsWarrantyDelete = userPreferenceViewModel.permissions.IsWarrantyDelete,

        //            IsTimeClockView = userPreferenceViewModel.permissions.IsTimeClockView,
        //            IsTimeClockAdd = userPreferenceViewModel.permissions.IsTimeClockAdd,
        //            IsTimeClockEdit = userPreferenceViewModel.permissions.IsTimeClockEdit,
        //            IsTimeClockDelete = userPreferenceViewModel.permissions.IsTimeClockDelete,
        //            IsTimeClockViewOtherUser = userPreferenceViewModel.permissions.IsTimeClockViewOtherUser,
        //            IsTimeClockAdjustOtherUser = userPreferenceViewModel.permissions.IsTimeClockAdjustOtherUser,
        //            IsTimeClockCostViewing = userPreferenceViewModel.permissions.IsTimeClockCostViewing,
        //            IsTimeClockReviewAndApprove = userPreferenceViewModel.permissions.IsTimeClockReviewAndApprove,

        //            IsEstimateGIView = userPreferenceViewModel.permissions.IsEstimateGIView,
        //            IsEstimateGIAdd = userPreferenceViewModel.permissions.IsEstimateGIAdd,
        //            IsEstimateGIEdit = userPreferenceViewModel.permissions.IsEstimateGIEdit,
        //            IsEstimateGIDelete = userPreferenceViewModel.permissions.IsEstimateGIDelete,
        //            IsEstimateGIPriceViewing = userPreferenceViewModel.permissions.IsEstimateGIPriceViewing,

        //            IsSurveyView = userPreferenceViewModel.permissions.IsSurveyView,
        //            IsSurveyAdd = userPreferenceViewModel.permissions.IsSurveyAdd,
        //            IsSurveyEdit = userPreferenceViewModel.permissions.IsSurveyEdit,
        //            IsSurveyDelete = userPreferenceViewModel.permissions.IsSurveyDelete,
        //            IsSurveyAddReviewWebsite = userPreferenceViewModel.permissions.IsSurveyAddReviewWebsite,

        //            IsSubsView = userPreferenceViewModel.permissions.IsSubsView,
        //            IsSubsAdd = userPreferenceViewModel.permissions.IsSubsAdd,
        //            IsSubsEdit = userPreferenceViewModel.permissions.IsSubsEdit,
        //            IsSubsDelete = userPreferenceViewModel.permissions.IsSubsDelete,

        //            IsAdminView = userPreferenceViewModel.permissions.IsAdminView,
        //            IsAdminViewReadonly = userPreferenceViewModel.permissions.IsAdminViewReadonly,
        //            IsAdminAdd = userPreferenceViewModel.permissions.IsAdminAdd,
        //            IsAdminAddReadonly = userPreferenceViewModel.permissions.IsAdminAddReadonly,
        //            IsAdminEdit = userPreferenceViewModel.permissions.IsAdminEdit,
        //            IsAdminEditReadonly = userPreferenceViewModel.permissions.IsAdminEditReadonly,
        //            IsAdminDelete = userPreferenceViewModel.permissions.IsAdminDelete,
        //            IsAdminDeleteReadonly = userPreferenceViewModel.permissions.IsAdminDeleteReadonly,

        //            ImportNotificationId = userPreferenceViewModel.permissions.ImportNotificationId,
        //            IsEmailAll = userPreferenceViewModel.permissions.IsEmailAll,
        //            IsTextAll = userPreferenceViewModel.permissions.IsTextAll,
        //            IsPushOn = userPreferenceViewModel.permissions.IsPushOn,
        //            IsAllUsers = userPreferenceViewModel.permissions.IsAllUsers,

        //            IsOwnerActivatedEmail = userPreferenceViewModel.permissions.IsOwnerActivatedEmail,

        //            IsOwnerPaymentUpdatedEmail = userPreferenceViewModel.permissions.
        //  IsOwnerPaymentUpdatedText = userPreferenceViewModel.permissions.
        //  IsOwnerPaymentUpdatedPush = userPreferenceViewModel.permissions.

        //  IsOwnerPaymentReminderEmail = userPreferenceViewModel.permissions.IsOwnerPaymentReminderEmail,
        //            IsOwnerPaymentReminderText = userPreferenceViewModel.permissions.IsOwnerPaymentReminderText,
        //            IsOwnerPaymentReminderPush = userPreferenceViewModel.permissions.IsOwnerPaymentReminderPush,


        //            IsOwnerPaymentPastDueEmail = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueEmail,
        //            IsOwnerPaymentPastDueText = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueText,
        //            IsOwnerPaymentPastDuePush = userPreferenceViewModel.permissions.IsOwnerPaymentPastDuePush,


        //            IsOwnerPaymentDiscussionEmail = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionEmail,
        //            IsOwnerPaymentDiscussionText = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionText,
        //            IsOwnerPaymentDiscussionPush = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionPush,

        //            IsOwnerPaymentAddedEmail = userPreferenceViewModel.permissions.IsOwnerPaymentAddedEmail,
        //            IsOwnerPaymentAddedText = userPreferenceViewModel.permissions.IsOwnerPaymentAddedText,
        //            IsOwnerPaymentAddedPush = userPreferenceViewModel.permissions.IsOwnerPaymentAddedPush,

        //            IsOtherEmployeeContactEmail = userPreferenceViewModel.permissions.IsOtherEmployeeContactEmail,
        //            IsOtherEmployeeContactText = userPreferenceViewModel.permissions.IsOtherEmployeeContactText,

        //            IsNewLeadEmail = userPreferenceViewModel.permissions.IsNewLeadEmail,
        //            IsNewLeadText = userPreferenceViewModel.permissions.IsNewLeadText,
        //            IsNewLeadPush = userPreferenceViewModel.permissions.IsNewLeadPush,

        //            IsLeadNotifyEmail = userPreferenceViewModel.permissions.IsLeadNotifyEmail,
        //            IsLeadNotifyText = userPreferenceViewModel.permissions.IsLeadNotifyText,
        //            IsLeadNotifyPush = userPreferenceViewModel.permissions.IsLeadNotifyPush,
        //            IsActivityRemainderEmail = userPreferenceViewModel.permissions.IsActivityRemainderEmail,
        //            IsActivityRemainderText = userPreferenceViewModel.permissions.IsActivityRemainderText,
        //            IsActivityRemainderPush = userPreferenceViewModel.permissions.IsActivityRemainderPush,
        //            IsActivityRemainderAllUsers = userPreferenceViewModel.permissions.IsActivityRemainderAllUsers,

        //            IsEmailQuotesAlertEmail = userPreferenceViewModel.permissions.IsEmailQuotesAlertEmail,
        //            IsEmailQuotesAlertText = userPreferenceViewModel.permissions.IsEmailQuotesAlertText,
        //            IsAssignedToLeadActivityEmail = userPreferenceViewModel.permissions.IsAssignedToLeadActivityEmail,
        //            IsAssignedToLeadActivityText = userPreferenceViewModel.permissions.IsAssignedToLeadActivityText,
        //            IsAssignedToLeadActivityPush = userPreferenceViewModel.permissions.IsAssignedToLeadActivityPush,

        //            IsLeadProposalAcceptedEmail = userPreferenceViewModel.permissions.IsLeadProposalAcceptedEmail,
        //            IsLeadProposalAcceptedText = userPreferenceViewModel.permissions.IsLeadProposalAcceptedText,
        //            IsLeadProposalAcceptedPush = userPreferenceViewModel.permissions.IsLeadProposalAcceptedPush,
        //            IsLeadProposalAcceptedAllUsers = userPreferenceViewModel.permissions.IsLeadProposalAcceptedAllUsers,

        //            IsLeadProposalViewedEmail = userPreferenceViewModel.permissions.IsLeadProposalViewedEmail,
        //            IsLeadProposalViewedText = userPreferenceViewModel.permissions.IsLeadProposalViewedText,
        //            IsLeadProposalViewedPush = userPreferenceViewModel.permissions.IsLeadProposalViewedPush,


        //            IsLinkedClickedByLeadEmail = userPreferenceViewModel.permissions.IsLinkedClickedByLeadEmail,
        //            IsLinkedClickedByLeadText = userPreferenceViewModel.permissions.IsLinkedClickedByLeadText,

        //            IsToDoCompletedEmail = userPreferenceViewModel.permissions.IsToDoCompletedEmail,
        //            IsToDoCompletedText = userPreferenceViewModel.permissions.IsToDoCompletedText,
        //            IsToDoCompletedPush = userPreferenceViewModel.permissions.IsToDoCompletedPush,
        //            IsToDoDiscussionAddedEmail = userPreferenceViewModel.permissions.IsToDoDiscussionAddedEmail,
        //            IsToDoDiscussionAddedText = userPreferenceViewModel.permissions.IsToDoDiscussionAddedText,
        //            IsToDoDiscussionAddedPush = userPreferenceViewModel.permissions.IsToDoDiscussionAddedPush,

        //            IsDailyLogNotificationEmail = userPreferenceViewModel.permissions.IsDailyLogNotificationEmail,
        //            IsDailyLogNotificationText = userPreferenceViewModel.permissions.IsDailyLogNotificationText,
        //            IsDailyLogNotificationPush = userPreferenceViewModel.permissions.IsDailyLogNotificationPush,
        //            IsDailyLogDiscussionAddedEmail = userPreferenceViewModel.permissions.IsDailyLogDiscussionAddedEmail,
        //            IsDailyLogNotificationAddedText = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedText,
        //            IsDailyLogNotificationAddedPush = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedPush,

        //            IsBidSubmittedEmail = userPreferenceViewModel.permissions.IsBidSubmittedEmail,
        //            IsBidSubmittedText = userPreferenceViewModel.permissions.IsBidSubmittedText,
        //            IsBidSubmittedPush = userPreferenceViewModel.permissions.IsBidSubmittedPush,
        //            IsSubConfirmationEmail = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
        //            IsSubConfirmationText = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
        //            IsSubConfirmationPush = userPreferenceViewModel.permissions.IsSubConfirmationPush,
        //            IsBidResubmittedEmail = userPreferenceViewModel.permissions.IsBidResubmittedEmail,
        //            IsBidResubmittedText = userPreferenceViewModel.permissions.IsBidResubmittedText,
        //            IsBidResubmittedPush = userPreferenceViewModel.permissions.IsBidResubmittedPush,
        //            IsBidDiscussionAddedEmail = userPreferenceViewModel.permissions.IsBidDiscussionAddedEmail,
        //            IsBidDiscussionAddedText = userPreferenceViewModel.permissions.IsBidDiscussionAddedText,
        //            IsBidDiscussionAddedPush = userPreferenceViewModel.permissions.IsBidDiscussionAddedPush,
        //            IsBidAcceptedBuilderEmail = userPreferenceViewModel.permissions.IsBidAcceptedBuilderEmail,
        //            IsBidAcceptedBuilderText = userPreferenceViewModel.permissions.IsBidAcceptedBuilderText,
        //            IsBidAcceptedBuilderPush = userPreferenceViewModel.permissions.IsBidAcceptedBuilderPush,


        //            IsUserNeedToConfirmChangeEmail = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeEmail,
        //            IsUserNeedToConfirmChangeText = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeText,
        //            IsUserNeedToConfirmChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangeEmail,
        //            IsUserConfirmedChangeEmail = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
        //            IsUserConfirmedChangeText = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
        //            IsUserConfirmedChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangePush,
        //            IsUserDeclinedChangeEmail = userPreferenceViewModel.permissions.IsUserDeclinedChangeEmail,
        //            IsUserDeclinedChangeText = userPreferenceViewModel.permissions.IsUserDeclinedChangeText,
        //            IsUserDeclinedChangePush = userPreferenceViewModel.permissions.IsUserDeclinedChangePush,
        //            IsScheduleItemDiscussionEmail = userPreferenceViewModel.permissions.IsScheduleItemDiscussionEmail,
        //            IsScheduleItemDiscussionText = userPreferenceViewModel.permissions.IsScheduleItemDiscussionText,
        //            IsScheduleItemDiscussionPush = userPreferenceViewModel.permissions.IsScheduleItemDiscussionPush,
        //            IsScheduleItemDiscussionAllUsers = userPreferenceViewModel.permissions.IsScheduleItemDiscussionAllUsers,

        //            IsDocumentCommentaddedEmail = userPreferenceViewModel.permissions.IsDocumentCommentaddedEmail,
        //            IsDocumentCommentaddedText = userPreferenceViewModel.permissions.IsDocumentCommentaddedText,
        //            IsDocumentCommentaddedPush = userPreferenceViewModel.permissions.IsDocumentCommentaddedPush,
        //            IsSubAndOwnerUploadedEmail = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedEmail,
        //            IsSubAndOwnerUploadedText = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedText,
        //            IsSubAndOwnerUploadedPush = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedPush,
        //            IsSignatureRequestSignedEmail = userPreferenceViewModel.permissions.IsSignatureRequestSignedEmail,
        //            IsSignatureRequestSignedPush = userPreferenceViewModel.permissions.IsSignatureRequestSignedPush,
        //            IsSignatureRequestPastDueEmail = userPreferenceViewModel.permissions.IsSignatureRequestPastDueEmail,
        //            IsSignatureRequestPastDuePush = userPreferenceViewModel.permissions.IsSignatureRequestPastDuePush,

        //            IsVideoCommentAddedEmail = userPreferenceViewModel.permissions.IsVideoCommentAddedEmail,
        //            IsVideoCommentAddedText = userPreferenceViewModel.permissions.IsVideoCommentAddedText,
        //            IsVideoCommentAddedPush = userPreferenceViewModel.permissions.IsVideoCommentAddedPush,
        //            IsPhotoCommentAddedEmail = userPreferenceViewModel.permissions.IsPhotoCommentAddedEmail,
        //            IsPhotoCommentAddedText = userPreferenceViewModel.permissions.IsPhotoCommentAddedText,
        //            IsPhotoCommentAddedPush = userPreferenceViewModel.permissions.IsPhotoCommentAddedPush,

        //            IsNewMessageEmail = userPreferenceViewModel.permissions.IsNewMessageEmail,
        //            IsNewMessageText = userPreferenceViewModel.permissions.IsNewMessageText,
        //            IsNewMessagePush = userPreferenceViewModel.permissions.IsNewMessagePush,
        //            IsNewMessageAllUsers = userPreferenceViewModel.permissions.IsNewMessageAllUsers,

        //            IsRFIAddedByBuilderEmail = userPreferenceViewModel.permissions.IsRFIAddedByBuilderEmail,
        //            IsRFIAddedByBuilderText = userPreferenceViewModel.permissions.IsRFIAddedByBuilderText,
        //            IsRFIAddedByBuilderPush = userPreferenceViewModel.permissions.IsRFIAddedByBuilderPush,
        //            IsRFIResponseAddedEmail = userPreferenceViewModel.permissions.IsRFIResponseAddedEmail,
        //            IsRFIResponseAddedText = userPreferenceViewModel.permissions.IsRFIResponseAddedText,
        //            IsRFIResponseAddedPush = userPreferenceViewModel.permissions.IsRFIResponseAddedPush,
        //            IsRFIAddedEmail = userPreferenceViewModel.permissions.IsRFIAddedEmail,
        //            IsRFIAddedText = userPreferenceViewModel.permissions.IsRFIAddedText,
        //            IsRFIAddedPush = userPreferenceViewModel.permissions.IsRFIAddedPush,
        //            IsRFICompletedEmail = userPreferenceViewModel.permissions.IsRFICompletedEmail,
        //            IsRFICompletedText = userPreferenceViewModel.permissions.IsRFICompletedText,
        //            IsRFICompletedPush = userPreferenceViewModel.permissions.IsRFICompletedPush,
        //            IsRFIPastDueEmail = userPreferenceViewModel.permissions.IsRFIPastDueEmail,
        //            IsRFIPastDueText = userPreferenceViewModel.permissions.IsRFIPastDueText,


        //            IsChangeOrderapprovedEmail = userPreferenceViewModel.permissions.IsChangeOrderapprovedEmail,
        //            IsChangeOrderapprovedText = userPreferenceViewModel.permissions.IsChangeOrderapprovedText,
        //            IsChangeOrderapprovedPush = userPreferenceViewModel.permissions.IsChangeOrderapprovedPush,
        //            IsChangeOrderaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderaddedEmail,
        //            IsChangeOrderaddedText = userPreferenceViewModel.permissions.IsChangeOrderaddedText,
        //            IsChangeOrderaddedPush = userPreferenceViewModel.permissions.IsChangeOrderaddedPush,
        //            IsChangeOrderfilesaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedEmail,
        //            IsChangeOrderfilesaddedText = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedText,
        //            IsChangeOrderfilesaddedPush = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedPush,
        //            IsChangeOrderDiscussionaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedEmail,
        //            IsChangeOrderDiscussionaddedText = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedText,
        //            IsChangeOrderDiscussionaddedPush = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedPush,
        //            IsChangeOrderDiscussionaddedAllUsers = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedAllUsers,
        //            IsChangeOrderApprovedInternallyEmail = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyEmail,
        //            IsChangeOrderApprovedInternallyText = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyText,
        //            IsChangeOrderApprovedInternallyPush = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyPush,
        //            IsOwnerRequestedChangeOrderEmail = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderEmail,
        //            IsOwnerRequestedChangeOrderText = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderText,
        //            IsOwnerRequestedChangeOrderPush = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderPush,
        //            IsChangeOrderPastDueEmail = userPreferenceViewModel.permissions.IsChangeOrderPastDueEmail,
        //            IsChangeOrderPastDueText = userPreferenceViewModel.permissions.IsChangeOrderPastDueText,

        //            IsSelectionApprovedEmail = userPreferenceViewModel.permissions.IsSelectionApprovedEmail,
        //            IsSelectionApprovedText = userPreferenceViewModel.permissions.IsSelectionApprovedText,
        //            IsSelectionApprovedPush = userPreferenceViewModel.permissions.IsSelectionApprovedPush,
        //            IsSelectionDeadlineReminderEmail = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderEmail,
        //            IsSelectionDeadlineReminderPush = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderPush,
        //            IsSelectionDiscussionAddedEmail = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedEmail,
        //            IsSelectionDiscussionAddedText = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedText,
        //            IsSelectionDiscussionAddedPush = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedPush,
        //            IsSelectionChoiceAddedEmail = userPreferenceViewModel.permissions.IsSelectionChoiceAddedEmail,
        //            IsSelectionChoiceAddedText = userPreferenceViewModel.permissions.IsSelectionChoiceAddedText,
        //            IsSelectionChoiceAddedPush = userPreferenceViewModel.permissions.IsSelectionChoiceAddedPush,
        //            IsSelectionOwnerPriceEmail = userPreferenceViewModel.permissions.IsSelectionOwnerPriceEmail,
        //            IsSelectionOwnerPriceText = userPreferenceViewModel.permissions.IsSelectionOwnerPriceText,
        //            IsSelectionOwnerPricePush = userPreferenceViewModel.permissions.IsSelectionOwnerPricePush,
        //            IsSelectionApprovedInternallyEmail = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyText,
        //            IsSelectionApprovedInternallyText = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
        //            IsSelectionApprovedInternallyPush = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
        //            IsSelectionSubPriceEmail = userPreferenceViewModel.permissions.IsSelectionSubPriceEmail,
        //            IsSelectionSubPriceText = userPreferenceViewModel.permissions.IsSelectionSubPriceText,
        //            IsSelectionSubPricePush = userPreferenceViewModel.permissions.IsSelectionSubPricePush,

        //            IsPOApprovedEmail = userPreferenceViewModel.permissions.IsPOApprovedEmail,
        //            IsPOApprovedText = userPreferenceViewModel.permissions.IsPOApprovedText,
        //            IsPOApprovedPush = userPreferenceViewModel.permissions.IsPOApprovedPush,
        //            IsPOPaymentMarkedEmail = userPreferenceViewModel.permissions.IsPOPaymentMarkedEmail,
        //            IsLienWaiverAcceptedEmail = userPreferenceViewModel.permissions.IsLienWaiverAcceptedEmail,
        //            IsLienWaiverAcceptedText = userPreferenceViewModel.permissions.IsLienWaiverAcceptedText,
        //            IsLienWaiverDeclinedEmail = userPreferenceViewModel.permissions.IsLienWaiverDeclinedEmail,
        //            IsLienWaiverDeclinedText = userPreferenceViewModel.permissions.IsLienWaiverDeclinedText,
        //            IsPOApprovedInternallyEmail = userPreferenceViewModel.permissions.IsPOApprovedInternallyEmail,
        //            IsPOApprovedInternallyText = userPreferenceViewModel.permissions.IsPOApprovedInternallyText,
        //            IsPOApprovedInternallyPush = userPreferenceViewModel.permissions.IsPOApprovedInternallyPush,
        //            IsPODeclinedEmail = userPreferenceViewModel.permissions.IsPODeclinedEmail,
        //            IsPODeclinedText = userPreferenceViewModel.permissions.IsPODeclinedText,
        //            IsPODeclinedPush = userPreferenceViewModel.permissions.IsPODeclinedPush,
        //            IsPOAssignedInternallyEmail = userPreferenceViewModel.permissions.IsPOAssignedInternallyEmail,
        //            IsPOAssignedInternallyText = userPreferenceViewModel.permissions.IsPOAssignedInternallyText,
        //            IsPOInspectionEmail = userPreferenceViewModel.permissions.IsPOInspectionEmail,
        //            IsPOInspectionPush = userPreferenceViewModel.permissions.IsPOInspectionPush,
        //            IsPOWorkcompletedEmail = userPreferenceViewModel.permissions.IsPOWorkcompletedEmail,
        //            IsPOPaymentMadeEmail = userPreferenceViewModel.permissions.IsPOPaymentMadeEmail,
        //            IsPODiscussionAddedEmail = userPreferenceViewModel.permissions.IsPODiscussionAddedEmail,
        //            IsPODiscussionAddedText = userPreferenceViewModel.permissions.IsPODiscussionAddedText,
        //            IsPODiscussionAddedPush = userPreferenceViewModel.permissions.IsPODiscussionAddedPush,
        //            IsPOFileAddedEmail = userPreferenceViewModel.permissions.IsPOFileAddedEmail,
        //            IsPOInspectionReminderEmail = userPreferenceViewModel.permissions.IsPOInspectionReminderEmail,
        //            IsPOInspectionReminderText = userPreferenceViewModel.permissions.IsPOInspectionReminderText,
        //            IsPOInspectionReminderPush = userPreferenceViewModel.permissions.IsPOInspectionReminderPush,
        //            IsPOWorkCompleteEmail = userPreferenceViewModel.permissions.IsPOWorkCompleteEmail,
        //            IsPOWorkCompleteText = userPreferenceViewModel.permissions.IsPOWorkCompleteText,
        //            IsPOWorkCompletePush = userPreferenceViewModel.permissions.IsPOWorkCompletePush,
        //            IsBillPaymentReminderEmail = userPreferenceViewModel.permissions.IsBillPaymentReminderEmail,

        //            IsWarrantyAddedEmail = userPreferenceViewModel.permissions.IsWarrantyAddedEmail,
        //            IsWarrantyAddedText = userPreferenceViewModel.permissions.IsWarrantyAddedText,
        //            IsWarrantyAddedPush = userPreferenceViewModel.permissions.IsWarrantyAddedPush,
        //            IsWarrantyFollowUpEmail = userPreferenceViewModel.permissions.IsWarrantyFollowUpEmail,
        //            IsWarrantyFollowUpText = userPreferenceViewModel.permissions.IsWarrantyFollowUpText,
        //            IsWarrantyFollowUpAllUsers = userPreferenceViewModel.permissions.IsWarrantyFollowUpAllUsers,
        //            IsWarrantyUpdatedEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedEmail,
        //            IsWarrantyUpdatedText = userPreferenceViewModel.permissions.IsWarrantyUpdatedText,
        //            IsWarrantyHasFeedbackEmail = userPreferenceViewModel.permissions.IsWarrantyHasFeedbackEmail,
        //            IsWarrantyUpdatedApptEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptEmail,
        //            IsWarrantyUpdatedApptText = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptText,
        //            IsWarrantyScheduleChangedEmail = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedEmail,
        //            IsWarrantyScheduleChangedText = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedText,
        //            IsWarrantyAddedInternallyEmail = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyEmail,
        //            IsWarrantyAddedInternallyText = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyText,
        //            IsWarrantyAddedInternallyPush = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyPush,
        //            IsWarrantyDiscussionAddedEmail = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedEmail,
        //            IsWarrantyDiscussionAddedText = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedText,
        //            IsWarrantyDiscussionAddedPush = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedPush,
        //            IsWarrantyDiscussionAddedAllUsers = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedAllUsers,
        //            IsWarrantyServiceInternallyAssignedEmail = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedEmail,
        //            IsWarrantyServiceInternallyAssignedText = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedText,



        //            IsTimeSheetAdjustmentEmail = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentEmail,
        //            IsTimeSheetAdjustmentText = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentText,
        //            IsTimeSheetAdjustmentPush = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentPush,
        //            IsTimeSheetAdjustmentAllUsers = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentAllUsers,
        //            IsOverTimeReachedEmail = userPreferenceViewModel.permissions.IsOverTimeReachedEmail,
        //            IsOverTimeReachedText = userPreferenceViewModel.permissions.IsOverTimeReachedText,
        //            IsOverTimeReachedPush = userPreferenceViewModel.permissions.IsOverTimeReachedPush,
        //            IsOverTimeReachedAllUsers = userPreferenceViewModel.permissions.IsOverTimeReachedAllUsers,


        //            IsEstimateAcceptedEmail = userPreferenceViewModel.permissions.IsEstimateAcceptedEmail,
        //            IsEstimateAcceptedText = userPreferenceViewModel.permissions.IsEstimateAcceptedText,
        //            IsEstimateViewedEmail = userPreferenceViewModel.permissions.IsEstimateViewedEmail,
        //            IsEstimateViewedText = userPreferenceViewModel.permissions.IsEstimateViewedText,


        //            IsOwnerSumittedSurveyEmail = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyEmail,
        //            IsOwnerSumittedSurveyText = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyText,

        //            IsSubInsuranceRemiderEmail = userPreferenceViewModel.permissions.IsSubInsuranceRemiderEmail,
        //            IsSubActivatedEmail = userPreferenceViewModel.permissions.IsSubActivatedEmail,
        //            IsTradeAgreementActionTakenEmail = userPreferenceViewModel.permissions.IsTradeAgreementActionTakenEmail

        //        };
        //        #region DetailedPermissions
        //        if (userid > 0)
        //        {
        //            var obj2 = await _detaildPermissionHelper.SaveUserDetailsAsync(detailedPermissionViewModel);
        //        }
        //    }
        //    #endregion
        //    //  var result = userMAsterViewModel;
        //    //ViewBag.result = 1;
        //    return View(userPreferenceViewModel);
        //}


        [HttpPost]
        public async Task<JsonResult> UserPreferences(UserPreferenceViewModel userPreferenceViewModel)
        {
            int result = 0;
            if (!ModelState.IsValid)
            {
                ViewBag.result = 1;
                // return View(userPreferenceViewModel);
                //return BadRequest(ModelState);
            }

            UserMasterViewModel userMasterViewModel = new UserMasterViewModel
            {
                UserFirstName = userPreferenceViewModel.usermasters.UserFirstName,
                UserLastName = userPreferenceViewModel.usermasters.UserLastName,
                UserEmail = userPreferenceViewModel.usermasters.UserEmail,
                UserEnabled = userPreferenceViewModel.usermasters.UserEnabled,
                UserLoginEnabled = userPreferenceViewModel.usermasters.UserLoginEnabled,
                UserPhone = userPreferenceViewModel.usermasters.UserPhone,
                UserCellEmail = userPreferenceViewModel.usermasters.UserCellEmail,
                UserContactInfo = userPreferenceViewModel.usermasters.UserContactInfo,
                UserDefaultTimeClock = userPreferenceViewModel.usermasters.UserDefaultTimeClock,
                UserDefaultLabourCost = userPreferenceViewModel.usermasters.UserDefaultLabourCost,
                UserIsAlert = userPreferenceViewModel.usermasters.UserIsAlert,
                UserAlertSchedule = userPreferenceViewModel.usermasters.UserAlertSchedule,
                UserIsAutomaticAccess = userPreferenceViewModel.usermasters.UserIsAutomaticAccess,
                UserName = userPreferenceViewModel.usermasters.UserName,
                UserPassword = userPreferenceViewModel.usermasters.UserPassword,
                UserIsForumHandle = userPreferenceViewModel.usermasters.UserIsForumHandle,
                UserForumHandle = userPreferenceViewModel.usermasters.UserForumHandle
            };


            var obj1 = await _userMasterHelper.GetUserByUserName(userMasterViewModel.UserName);
            #region user name exists or not
            int userid = 0;
            if (obj1.Count > 0)
            {
                ViewBag.result = 2;
                //return View(userPreferenceViewModel);
            }
            else
            {

                var obj = await _userMasterHelper.SaveUserMaster(userMasterViewModel);
                userid = Convert.ToInt32(obj.UserID);
            }
            #endregion

            if (userid > 1)
            {
                DetaildPermissionViewModel detailedPermissionViewModel = new DetaildPermissionViewModel
                {

                    UserID = userid,
                    IsViewAll = userPreferenceViewModel.permissions.IsViewAll,
                    IsAddAll = userPreferenceViewModel.permissions.IsAddAll,
                    IsEditall = userPreferenceViewModel.permissions.IsEditall,
                    IsDeleteAll = userPreferenceViewModel.permissions.IsDeleteAll,
                    IsJobInfoView = userPreferenceViewModel.permissions.IsJobInfoView,
                    IsJobInfoAdd = userPreferenceViewModel.permissions.IsJobInfoAdd,
                    IsJobInfoEdit = userPreferenceViewModel.permissions.IsJobInfoEdit,
                    IsJobInfodelete = userPreferenceViewModel.permissions.IsJobInfodelete,
                    IsViewOwnerSite = userPreferenceViewModel.permissions.IsViewOwnerSite,
                    IsPriceViewing = userPreferenceViewModel.permissions.IsPriceViewing,
                    IsOwnerPaymentsView = userPreferenceViewModel.permissions.IsOwnerPaymentsView,
                    IsOwnerPaymentsAdd = userPreferenceViewModel.permissions.IsOwnerPaymentsAdd,
                    IsOwnerPaymentsEdit = userPreferenceViewModel.permissions.IsOwnerPaymentsEdit,
                    IsOwnerPaymentsDelete = userPreferenceViewModel.permissions.IsOwnerPaymentsDelete,
                    IsLeadsView = userPreferenceViewModel.permissions.IsLeadsView,
                    IsLeadsAdd = userPreferenceViewModel.permissions.IsLeadsAdd,
                    IsLeadsEdit = userPreferenceViewModel.permissions.IsLeadsEdit,
                    IsLeadsDelete = userPreferenceViewModel.permissions.IsLeadsDelete,
                    IsLeadsAssignSalesperson = userPreferenceViewModel.permissions.IsLeadsAssignSalesperson,
                    IsLeadsViewOtherSalesperson = userPreferenceViewModel.permissions.IsLeadsViewOtherSalesperson,
                    IsLeadsConvertToJobsite = userPreferenceViewModel.permissions.IsLeadsConvertToJobsite,
                    IsLeadsExportToExcel = userPreferenceViewModel.permissions.IsLeadsExportToExcel,
                    IsCustomerContactsViewReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsViewReadOnly,
                    IsCustomerContactsView = userPreferenceViewModel.permissions.IsCustomerContactsView,
                    IsCustomerContactsAddReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsAddReadOnly,
                    IsCustomerContactsAdd = userPreferenceViewModel.permissions.IsCustomerContactsAdd,
                    IsCustomerContactsEdit = userPreferenceViewModel.permissions.IsCustomerContactsEdit,
                    IsCustomerContactsDelete = userPreferenceViewModel.permissions.IsCustomerContactsDelete,

                    IsViewAllCustomerContactsReadonly = userPreferenceViewModel.permissions.IsViewAllCustomerContactsReadonly,
                    IsViewAllCustomerContacts = userPreferenceViewModel.permissions.IsViewAllCustomerContacts,
                    IsCustomerContactsExportToExcel = userPreferenceViewModel.permissions.IsCustomerContactsExportToExcel,

                    IsToDoView = userPreferenceViewModel.permissions.IsToDoView,
                    IsToDoAdd = userPreferenceViewModel.permissions.IsToDoView,
                    IsToDoEdit = userPreferenceViewModel.permissions.IsToDoEdit,
                    IsToDoDelete = userPreferenceViewModel.permissions.IsToDoDelete,
                    IsToDoAssignUsers = userPreferenceViewModel.permissions.IsToDoAssignUsers,
                    IsToDoGlobal = userPreferenceViewModel.permissions.IsToDoGlobal,


                    IsLogsView = userPreferenceViewModel.permissions.IsLogsView,
                    IsLogsAdd = userPreferenceViewModel.permissions.IsLogsAdd,
                    IsLogsEdit = userPreferenceViewModel.permissions.IsLogsEdit,
                    IsLogsDelete = userPreferenceViewModel.permissions.IsLogsDelete,

                    IsBidsView = userPreferenceViewModel.permissions.IsBidsView,
                    IsBidsAdd = userPreferenceViewModel.permissions.IsBidsAdd,
                    IsBidsEdit = userPreferenceViewModel.permissions.IsBidsEdit,
                    IsBidsDelete = userPreferenceViewModel.permissions.IsBidsDelete,

                    IsCalendarView = userPreferenceViewModel.permissions.IsCalendarView,
                    IsCalendarAdd = userPreferenceViewModel.permissions.IsCalendarAdd,
                    IsCalendarEdit = userPreferenceViewModel.permissions.IsCalendarEdit,
                    IsCalendarDelete = userPreferenceViewModel.permissions.IsCalendarDelete,
                    IsSetBaseline = userPreferenceViewModel.permissions.IsSetBaseline,

                    IsDocumentsView = userPreferenceViewModel.permissions.IsDocumentsView,
                    IsDocumentsAdd = userPreferenceViewModel.permissions.IsDocumentsAdd,
                    IsDocumentsEdit = userPreferenceViewModel.permissions.IsDocumentsEdit,
                    IsDocumentsDelete = userPreferenceViewModel.permissions.IsDocumentsDelete,

                    IsDocumentsAccessSubOwner = userPreferenceViewModel.permissions.IsDocumentsAccessSubOwner,
                    IsDocumentsSignature = userPreferenceViewModel.permissions.IsDocumentsSignature,

                    IsVideosView = userPreferenceViewModel.permissions.IsVideosView,
                    IsVideosAdd = userPreferenceViewModel.permissions.IsVideosAdd,
                    IsVideosEdit = userPreferenceViewModel.permissions.IsVideosEdit,
                    IsVideosDelete = userPreferenceViewModel.permissions.IsVideosDelete,

                    IsPhotosView = userPreferenceViewModel.permissions.IsPhotosView,
                    IsPhotosAdd = userPreferenceViewModel.permissions.IsPhotosAdd,
                    IsPhotosEdit = userPreferenceViewModel.permissions.IsPhotosEdit,
                    IsPhotosDelete = userPreferenceViewModel.permissions.IsPhotosDelete,

                    IsMessagesView = userPreferenceViewModel.permissions.IsMessagesView,
                    IsMessagesAdd = userPreferenceViewModel.permissions.IsMessagesAdd,
                    IsMessagesAddReadonly = userPreferenceViewModel.permissions.IsMessagesAddReadonly,
                    IsMessagesEdit = userPreferenceViewModel.permissions.IsMessagesEdit,
                    IsMessagesEditReadonly = userPreferenceViewModel.permissions.IsMessagesEditReadonly,
                    IsMessagesDelete = userPreferenceViewModel.permissions.IsMessagesDelete,
                    IsMessageGlobal = userPreferenceViewModel.permissions.IsMessageGlobal,

                    IsRFIView = userPreferenceViewModel.permissions.IsRFIView,
                    IsRFIAdd = userPreferenceViewModel.permissions.IsRFIAdd,
                    IsRFIEdit = userPreferenceViewModel.permissions.IsRFIEdit,
                    IsRFIDelete = userPreferenceViewModel.permissions.IsRFIDelete,

                    IsChangeOrdersView = userPreferenceViewModel.permissions.IsChangeOrdersView,
                    IsChangeOrdersAdd = userPreferenceViewModel.permissions.IsChangeOrdersAdd,
                    IsChangeOrdersEdit = userPreferenceViewModel.permissions.IsChangeOrdersEdit,
                    IsChangeOrdersDelete = userPreferenceViewModel.permissions.IsChangeOrdersDelete,
                    IsChangeOrdersCostViewing = userPreferenceViewModel.permissions.IsChangeOrdersCostViewing,

                    IsSelectionsView = userPreferenceViewModel.permissions.IsSelectionsView,
                    IsSelectionsAdd = userPreferenceViewModel.permissions.IsSelectionsAdd,
                    IsSelectionsEdit = userPreferenceViewModel.permissions.IsSelectionsEdit,
                    IsSelectionsDelete = userPreferenceViewModel.permissions.IsSelectionsDelete,
                    IsSelectionsCostViewing = userPreferenceViewModel.permissions.IsSelectionsCostViewing,

                    IsBillView = userPreferenceViewModel.permissions.IsBillView,
                    IsBillAdd = userPreferenceViewModel.permissions.IsBillAdd,
                    IsBillEdit = userPreferenceViewModel.permissions.IsBillEdit,
                    IsBillDelete = userPreferenceViewModel.permissions.IsBillDelete,
                    IsBillAccounting = userPreferenceViewModel.permissions.IsBillAccounting,
                    IsBillNoPriceLimit = userPreferenceViewModel.permissions.IsBillNoPriceLimit,
                    IsBillCostViewing = userPreferenceViewModel.permissions.IsBillCostViewing,

                    IsWarrantyView = userPreferenceViewModel.permissions.IsWarrantyView,
                    IsWarrantyAdd = userPreferenceViewModel.permissions.IsWarrantyAdd,
                    IsWarrantyEdit = userPreferenceViewModel.permissions.IsWarrantyEdit,
                    IsWarrantyDelete = userPreferenceViewModel.permissions.IsWarrantyDelete,

                    IsTimeClockView = userPreferenceViewModel.permissions.IsTimeClockView,
                    IsTimeClockAdd = userPreferenceViewModel.permissions.IsTimeClockAdd,
                    IsTimeClockEdit = userPreferenceViewModel.permissions.IsTimeClockEdit,
                    IsTimeClockDelete = userPreferenceViewModel.permissions.IsTimeClockDelete,
                    IsTimeClockViewOtherUser = userPreferenceViewModel.permissions.IsTimeClockViewOtherUser,
                    IsTimeClockAdjustOtherUser = userPreferenceViewModel.permissions.IsTimeClockAdjustOtherUser,
                    IsTimeClockCostViewing = userPreferenceViewModel.permissions.IsTimeClockCostViewing,
                    IsTimeClockReviewAndApprove = userPreferenceViewModel.permissions.IsTimeClockReviewAndApprove,

                    IsEstimateGIView = userPreferenceViewModel.permissions.IsEstimateGIView,
                    IsEstimateGIAdd = userPreferenceViewModel.permissions.IsEstimateGIAdd,
                    IsEstimateGIEdit = userPreferenceViewModel.permissions.IsEstimateGIEdit,
                    IsEstimateGIDelete = userPreferenceViewModel.permissions.IsEstimateGIDelete,
                    IsEstimateGIPriceViewing = userPreferenceViewModel.permissions.IsEstimateGIPriceViewing,

                    IsSurveyView = userPreferenceViewModel.permissions.IsSurveyView,
                    IsSurveyAdd = userPreferenceViewModel.permissions.IsSurveyAdd,
                    IsSurveyEdit = userPreferenceViewModel.permissions.IsSurveyEdit,
                    IsSurveyDelete = userPreferenceViewModel.permissions.IsSurveyDelete,
                    IsSurveyAddReviewWebsite = userPreferenceViewModel.permissions.IsSurveyAddReviewWebsite,

                    IsSubsView = userPreferenceViewModel.permissions.IsSubsView,
                    IsSubsAdd = userPreferenceViewModel.permissions.IsSubsAdd,
                    IsSubsEdit = userPreferenceViewModel.permissions.IsSubsEdit,
                    IsSubsDelete = userPreferenceViewModel.permissions.IsSubsDelete,

                    IsAdminView = userPreferenceViewModel.permissions.IsAdminView,
                    IsAdminViewReadonly = userPreferenceViewModel.permissions.IsAdminViewReadonly,
                    IsAdminAdd = userPreferenceViewModel.permissions.IsAdminAdd,
                    IsAdminAddReadonly = userPreferenceViewModel.permissions.IsAdminAddReadonly,
                    IsAdminEdit = userPreferenceViewModel.permissions.IsAdminEdit,
                    IsAdminEditReadonly = userPreferenceViewModel.permissions.IsAdminEditReadonly,
                    IsAdminDelete = userPreferenceViewModel.permissions.IsAdminDelete,
                    IsAdminDeleteReadonly = userPreferenceViewModel.permissions.IsAdminDeleteReadonly,

                    ImportNotificationId = userPreferenceViewModel.permissions.ImportNotificationId,
                    IsEmailAll = userPreferenceViewModel.permissions.IsEmailAll,
                    IsTextAll = userPreferenceViewModel.permissions.IsTextAll,
                    IsPushOn = userPreferenceViewModel.permissions.IsPushOn,
                    IsAllUsers = userPreferenceViewModel.permissions.IsAllUsers,

                    IsOwnerActivatedEmail = userPreferenceViewModel.permissions.IsOwnerActivatedEmail,

                    IsOwnerPaymentUpdatedEmail = userPreferenceViewModel.permissions.
          IsOwnerPaymentUpdatedText = userPreferenceViewModel.permissions.
          IsOwnerPaymentUpdatedPush = userPreferenceViewModel.permissions.

          IsOwnerPaymentReminderEmail = userPreferenceViewModel.permissions.IsOwnerPaymentReminderEmail,
                    IsOwnerPaymentReminderText = userPreferenceViewModel.permissions.IsOwnerPaymentReminderText,
                    IsOwnerPaymentReminderPush = userPreferenceViewModel.permissions.IsOwnerPaymentReminderPush,


                    IsOwnerPaymentPastDueEmail = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueEmail,
                    IsOwnerPaymentPastDueText = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueText,
                    IsOwnerPaymentPastDuePush = userPreferenceViewModel.permissions.IsOwnerPaymentPastDuePush,


                    IsOwnerPaymentDiscussionEmail = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionEmail,
                    IsOwnerPaymentDiscussionText = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionText,
                    IsOwnerPaymentDiscussionPush = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionPush,

                    IsOwnerPaymentAddedEmail = userPreferenceViewModel.permissions.IsOwnerPaymentAddedEmail,
                    IsOwnerPaymentAddedText = userPreferenceViewModel.permissions.IsOwnerPaymentAddedText,
                    IsOwnerPaymentAddedPush = userPreferenceViewModel.permissions.IsOwnerPaymentAddedPush,

                    IsOtherEmployeeContactEmail = userPreferenceViewModel.permissions.IsOtherEmployeeContactEmail,
                    IsOtherEmployeeContactText = userPreferenceViewModel.permissions.IsOtherEmployeeContactText,

                    IsNewLeadEmail = userPreferenceViewModel.permissions.IsNewLeadEmail,
                    IsNewLeadText = userPreferenceViewModel.permissions.IsNewLeadText,
                    IsNewLeadPush = userPreferenceViewModel.permissions.IsNewLeadPush,

                    IsLeadNotifyEmail = userPreferenceViewModel.permissions.IsLeadNotifyEmail,
                    IsLeadNotifyText = userPreferenceViewModel.permissions.IsLeadNotifyText,
                    IsLeadNotifyPush = userPreferenceViewModel.permissions.IsLeadNotifyPush,
                    IsActivityRemainderEmail = userPreferenceViewModel.permissions.IsActivityRemainderEmail,
                    IsActivityRemainderText = userPreferenceViewModel.permissions.IsActivityRemainderText,
                    IsActivityRemainderPush = userPreferenceViewModel.permissions.IsActivityRemainderPush,
                    IsActivityRemainderAllUsers = userPreferenceViewModel.permissions.IsActivityRemainderAllUsers,

                    IsEmailQuotesAlertEmail = userPreferenceViewModel.permissions.IsEmailQuotesAlertEmail,
                    IsEmailQuotesAlertText = userPreferenceViewModel.permissions.IsEmailQuotesAlertText,
                    IsAssignedToLeadActivityEmail = userPreferenceViewModel.permissions.IsAssignedToLeadActivityEmail,
                    IsAssignedToLeadActivityText = userPreferenceViewModel.permissions.IsAssignedToLeadActivityText,
                    IsAssignedToLeadActivityPush = userPreferenceViewModel.permissions.IsAssignedToLeadActivityPush,

                    IsLeadProposalAcceptedEmail = userPreferenceViewModel.permissions.IsLeadProposalAcceptedEmail,
                    IsLeadProposalAcceptedText = userPreferenceViewModel.permissions.IsLeadProposalAcceptedText,
                    IsLeadProposalAcceptedPush = userPreferenceViewModel.permissions.IsLeadProposalAcceptedPush,
                    IsLeadProposalAcceptedAllUsers = userPreferenceViewModel.permissions.IsLeadProposalAcceptedAllUsers,

                    IsLeadProposalViewedEmail = userPreferenceViewModel.permissions.IsLeadProposalViewedEmail,
                    IsLeadProposalViewedText = userPreferenceViewModel.permissions.IsLeadProposalViewedText,
                    IsLeadProposalViewedPush = userPreferenceViewModel.permissions.IsLeadProposalViewedPush,


                    IsLinkedClickedByLeadEmail = userPreferenceViewModel.permissions.IsLinkedClickedByLeadEmail,
                    IsLinkedClickedByLeadText = userPreferenceViewModel.permissions.IsLinkedClickedByLeadText,

                    IsToDoCompletedEmail = userPreferenceViewModel.permissions.IsToDoCompletedEmail,
                    IsToDoCompletedText = userPreferenceViewModel.permissions.IsToDoCompletedText,
                    IsToDoCompletedPush = userPreferenceViewModel.permissions.IsToDoCompletedPush,
                    IsToDoDiscussionAddedEmail = userPreferenceViewModel.permissions.IsToDoDiscussionAddedEmail,
                    IsToDoDiscussionAddedText = userPreferenceViewModel.permissions.IsToDoDiscussionAddedText,
                    IsToDoDiscussionAddedPush = userPreferenceViewModel.permissions.IsToDoDiscussionAddedPush,

                    IsDailyLogNotificationEmail = userPreferenceViewModel.permissions.IsDailyLogNotificationEmail,
                    IsDailyLogNotificationText = userPreferenceViewModel.permissions.IsDailyLogNotificationText,
                    IsDailyLogNotificationPush = userPreferenceViewModel.permissions.IsDailyLogNotificationPush,
                    IsDailyLogDiscussionAddedEmail = userPreferenceViewModel.permissions.IsDailyLogDiscussionAddedEmail,
                    IsDailyLogNotificationAddedText = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedText,
                    IsDailyLogNotificationAddedPush = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedPush,

                    IsBidSubmittedEmail = userPreferenceViewModel.permissions.IsBidSubmittedEmail,
                    IsBidSubmittedText = userPreferenceViewModel.permissions.IsBidSubmittedText,
                    IsBidSubmittedPush = userPreferenceViewModel.permissions.IsBidSubmittedPush,
                    IsSubConfirmationEmail = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
                    IsSubConfirmationText = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
                    IsSubConfirmationPush = userPreferenceViewModel.permissions.IsSubConfirmationPush,
                    IsBidResubmittedEmail = userPreferenceViewModel.permissions.IsBidResubmittedEmail,
                    IsBidResubmittedText = userPreferenceViewModel.permissions.IsBidResubmittedText,
                    IsBidResubmittedPush = userPreferenceViewModel.permissions.IsBidResubmittedPush,
                    IsBidDiscussionAddedEmail = userPreferenceViewModel.permissions.IsBidDiscussionAddedEmail,
                    IsBidDiscussionAddedText = userPreferenceViewModel.permissions.IsBidDiscussionAddedText,
                    IsBidDiscussionAddedPush = userPreferenceViewModel.permissions.IsBidDiscussionAddedPush,
                    IsBidAcceptedBuilderEmail = userPreferenceViewModel.permissions.IsBidAcceptedBuilderEmail,
                    IsBidAcceptedBuilderText = userPreferenceViewModel.permissions.IsBidAcceptedBuilderText,
                    IsBidAcceptedBuilderPush = userPreferenceViewModel.permissions.IsBidAcceptedBuilderPush,


                    IsUserNeedToConfirmChangeEmail = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeEmail,
                    IsUserNeedToConfirmChangeText = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeText,
                    IsUserNeedToConfirmChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangeEmail,
                    IsUserConfirmedChangeEmail = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
                    IsUserConfirmedChangeText = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
                    IsUserConfirmedChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangePush,
                    IsUserDeclinedChangeEmail = userPreferenceViewModel.permissions.IsUserDeclinedChangeEmail,
                    IsUserDeclinedChangeText = userPreferenceViewModel.permissions.IsUserDeclinedChangeText,
                    IsUserDeclinedChangePush = userPreferenceViewModel.permissions.IsUserDeclinedChangePush,
                    IsScheduleItemDiscussionEmail = userPreferenceViewModel.permissions.IsScheduleItemDiscussionEmail,
                    IsScheduleItemDiscussionText = userPreferenceViewModel.permissions.IsScheduleItemDiscussionText,
                    IsScheduleItemDiscussionPush = userPreferenceViewModel.permissions.IsScheduleItemDiscussionPush,
                    IsScheduleItemDiscussionAllUsers = userPreferenceViewModel.permissions.IsScheduleItemDiscussionAllUsers,

                    IsDocumentCommentaddedEmail = userPreferenceViewModel.permissions.IsDocumentCommentaddedEmail,
                    IsDocumentCommentaddedText = userPreferenceViewModel.permissions.IsDocumentCommentaddedText,
                    IsDocumentCommentaddedPush = userPreferenceViewModel.permissions.IsDocumentCommentaddedPush,
                    IsSubAndOwnerUploadedEmail = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedEmail,
                    IsSubAndOwnerUploadedText = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedText,
                    IsSubAndOwnerUploadedPush = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedPush,
                    IsSignatureRequestSignedEmail = userPreferenceViewModel.permissions.IsSignatureRequestSignedEmail,
                    IsSignatureRequestSignedPush = userPreferenceViewModel.permissions.IsSignatureRequestSignedPush,
                    IsSignatureRequestPastDueEmail = userPreferenceViewModel.permissions.IsSignatureRequestPastDueEmail,
                    IsSignatureRequestPastDuePush = userPreferenceViewModel.permissions.IsSignatureRequestPastDuePush,

                    IsVideoCommentAddedEmail = userPreferenceViewModel.permissions.IsVideoCommentAddedEmail,
                    IsVideoCommentAddedText = userPreferenceViewModel.permissions.IsVideoCommentAddedText,
                    IsVideoCommentAddedPush = userPreferenceViewModel.permissions.IsVideoCommentAddedPush,
                    IsPhotoCommentAddedEmail = userPreferenceViewModel.permissions.IsPhotoCommentAddedEmail,
                    IsPhotoCommentAddedText = userPreferenceViewModel.permissions.IsPhotoCommentAddedText,
                    IsPhotoCommentAddedPush = userPreferenceViewModel.permissions.IsPhotoCommentAddedPush,

                    IsNewMessageEmail = userPreferenceViewModel.permissions.IsNewMessageEmail,
                    IsNewMessageText = userPreferenceViewModel.permissions.IsNewMessageText,
                    IsNewMessagePush = userPreferenceViewModel.permissions.IsNewMessagePush,
                    IsNewMessageAllUsers = userPreferenceViewModel.permissions.IsNewMessageAllUsers,

                    IsRFIAddedByBuilderEmail = userPreferenceViewModel.permissions.IsRFIAddedByBuilderEmail,
                    IsRFIAddedByBuilderText = userPreferenceViewModel.permissions.IsRFIAddedByBuilderText,
                    IsRFIAddedByBuilderPush = userPreferenceViewModel.permissions.IsRFIAddedByBuilderPush,
                    IsRFIResponseAddedEmail = userPreferenceViewModel.permissions.IsRFIResponseAddedEmail,
                    IsRFIResponseAddedText = userPreferenceViewModel.permissions.IsRFIResponseAddedText,
                    IsRFIResponseAddedPush = userPreferenceViewModel.permissions.IsRFIResponseAddedPush,
                    IsRFIAddedEmail = userPreferenceViewModel.permissions.IsRFIAddedEmail,
                    IsRFIAddedText = userPreferenceViewModel.permissions.IsRFIAddedText,
                    IsRFIAddedPush = userPreferenceViewModel.permissions.IsRFIAddedPush,
                    IsRFICompletedEmail = userPreferenceViewModel.permissions.IsRFICompletedEmail,
                    IsRFICompletedText = userPreferenceViewModel.permissions.IsRFICompletedText,
                    IsRFICompletedPush = userPreferenceViewModel.permissions.IsRFICompletedPush,
                    IsRFIPastDueEmail = userPreferenceViewModel.permissions.IsRFIPastDueEmail,
                    IsRFIPastDueText = userPreferenceViewModel.permissions.IsRFIPastDueText,


                    IsChangeOrderapprovedEmail = userPreferenceViewModel.permissions.IsChangeOrderapprovedEmail,
                    IsChangeOrderapprovedText = userPreferenceViewModel.permissions.IsChangeOrderapprovedText,
                    IsChangeOrderapprovedPush = userPreferenceViewModel.permissions.IsChangeOrderapprovedPush,
                    IsChangeOrderaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderaddedEmail,
                    IsChangeOrderaddedText = userPreferenceViewModel.permissions.IsChangeOrderaddedText,
                    IsChangeOrderaddedPush = userPreferenceViewModel.permissions.IsChangeOrderaddedPush,
                    IsChangeOrderfilesaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedEmail,
                    IsChangeOrderfilesaddedText = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedText,
                    IsChangeOrderfilesaddedPush = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedPush,
                    IsChangeOrderDiscussionaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedEmail,
                    IsChangeOrderDiscussionaddedText = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedText,
                    IsChangeOrderDiscussionaddedPush = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedPush,
                    IsChangeOrderDiscussionaddedAllUsers = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedAllUsers,
                    IsChangeOrderApprovedInternallyEmail = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyEmail,
                    IsChangeOrderApprovedInternallyText = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyText,
                    IsChangeOrderApprovedInternallyPush = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyPush,
                    IsOwnerRequestedChangeOrderEmail = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderEmail,
                    IsOwnerRequestedChangeOrderText = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderText,
                    IsOwnerRequestedChangeOrderPush = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderPush,
                    IsChangeOrderPastDueEmail = userPreferenceViewModel.permissions.IsChangeOrderPastDueEmail,
                    IsChangeOrderPastDueText = userPreferenceViewModel.permissions.IsChangeOrderPastDueText,

                    IsSelectionApprovedEmail = userPreferenceViewModel.permissions.IsSelectionApprovedEmail,
                    IsSelectionApprovedText = userPreferenceViewModel.permissions.IsSelectionApprovedText,
                    IsSelectionApprovedPush = userPreferenceViewModel.permissions.IsSelectionApprovedPush,
                    IsSelectionDeadlineReminderEmail = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderEmail,
                    IsSelectionDeadlineReminderPush = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderPush,
                    IsSelectionDiscussionAddedEmail = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedEmail,
                    IsSelectionDiscussionAddedText = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedText,
                    IsSelectionDiscussionAddedPush = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedPush,
                    IsSelectionChoiceAddedEmail = userPreferenceViewModel.permissions.IsSelectionChoiceAddedEmail,
                    IsSelectionChoiceAddedText = userPreferenceViewModel.permissions.IsSelectionChoiceAddedText,
                    IsSelectionChoiceAddedPush = userPreferenceViewModel.permissions.IsSelectionChoiceAddedPush,
                    IsSelectionOwnerPriceEmail = userPreferenceViewModel.permissions.IsSelectionOwnerPriceEmail,
                    IsSelectionOwnerPriceText = userPreferenceViewModel.permissions.IsSelectionOwnerPriceText,
                    IsSelectionOwnerPricePush = userPreferenceViewModel.permissions.IsSelectionOwnerPricePush,
                    IsSelectionApprovedInternallyEmail = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyText,
                    IsSelectionApprovedInternallyText = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
                    IsSelectionApprovedInternallyPush = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
                    IsSelectionSubPriceEmail = userPreferenceViewModel.permissions.IsSelectionSubPriceEmail,
                    IsSelectionSubPriceText = userPreferenceViewModel.permissions.IsSelectionSubPriceText,
                    IsSelectionSubPricePush = userPreferenceViewModel.permissions.IsSelectionSubPricePush,

                    IsPOApprovedEmail = userPreferenceViewModel.permissions.IsPOApprovedEmail,
                    IsPOApprovedText = userPreferenceViewModel.permissions.IsPOApprovedText,
                    IsPOApprovedPush = userPreferenceViewModel.permissions.IsPOApprovedPush,
                    IsPOPaymentMarkedEmail = userPreferenceViewModel.permissions.IsPOPaymentMarkedEmail,
                    IsLienWaiverAcceptedEmail = userPreferenceViewModel.permissions.IsLienWaiverAcceptedEmail,
                    IsLienWaiverAcceptedText = userPreferenceViewModel.permissions.IsLienWaiverAcceptedText,
                    IsLienWaiverDeclinedEmail = userPreferenceViewModel.permissions.IsLienWaiverDeclinedEmail,
                    IsLienWaiverDeclinedText = userPreferenceViewModel.permissions.IsLienWaiverDeclinedText,
                    IsPOApprovedInternallyEmail = userPreferenceViewModel.permissions.IsPOApprovedInternallyEmail,
                    IsPOApprovedInternallyText = userPreferenceViewModel.permissions.IsPOApprovedInternallyText,
                    IsPOApprovedInternallyPush = userPreferenceViewModel.permissions.IsPOApprovedInternallyPush,
                    IsPODeclinedEmail = userPreferenceViewModel.permissions.IsPODeclinedEmail,
                    IsPODeclinedText = userPreferenceViewModel.permissions.IsPODeclinedText,
                    IsPODeclinedPush = userPreferenceViewModel.permissions.IsPODeclinedPush,
                    IsPOAssignedInternallyEmail = userPreferenceViewModel.permissions.IsPOAssignedInternallyEmail,
                    IsPOAssignedInternallyText = userPreferenceViewModel.permissions.IsPOAssignedInternallyText,
                    IsPOInspectionEmail = userPreferenceViewModel.permissions.IsPOInspectionEmail,
                    IsPOInspectionPush = userPreferenceViewModel.permissions.IsPOInspectionPush,
                    IsPOWorkcompletedEmail = userPreferenceViewModel.permissions.IsPOWorkcompletedEmail,
                    IsPOPaymentMadeEmail = userPreferenceViewModel.permissions.IsPOPaymentMadeEmail,
                    IsPODiscussionAddedEmail = userPreferenceViewModel.permissions.IsPODiscussionAddedEmail,
                    IsPODiscussionAddedText = userPreferenceViewModel.permissions.IsPODiscussionAddedText,
                    IsPODiscussionAddedPush = userPreferenceViewModel.permissions.IsPODiscussionAddedPush,
                    IsPOFileAddedEmail = userPreferenceViewModel.permissions.IsPOFileAddedEmail,
                    IsPOInspectionReminderEmail = userPreferenceViewModel.permissions.IsPOInspectionReminderEmail,
                    IsPOInspectionReminderText = userPreferenceViewModel.permissions.IsPOInspectionReminderText,
                    IsPOInspectionReminderPush = userPreferenceViewModel.permissions.IsPOInspectionReminderPush,
                    IsPOWorkCompleteEmail = userPreferenceViewModel.permissions.IsPOWorkCompleteEmail,
                    IsPOWorkCompleteText = userPreferenceViewModel.permissions.IsPOWorkCompleteText,
                    IsPOWorkCompletePush = userPreferenceViewModel.permissions.IsPOWorkCompletePush,
                    IsBillPaymentReminderEmail = userPreferenceViewModel.permissions.IsBillPaymentReminderEmail,

                    IsWarrantyAddedEmail = userPreferenceViewModel.permissions.IsWarrantyAddedEmail,
                    IsWarrantyAddedText = userPreferenceViewModel.permissions.IsWarrantyAddedText,
                    IsWarrantyAddedPush = userPreferenceViewModel.permissions.IsWarrantyAddedPush,
                    IsWarrantyFollowUpEmail = userPreferenceViewModel.permissions.IsWarrantyFollowUpEmail,
                    IsWarrantyFollowUpText = userPreferenceViewModel.permissions.IsWarrantyFollowUpText,
                    IsWarrantyFollowUpAllUsers = userPreferenceViewModel.permissions.IsWarrantyFollowUpAllUsers,
                    IsWarrantyUpdatedEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedEmail,
                    IsWarrantyUpdatedText = userPreferenceViewModel.permissions.IsWarrantyUpdatedText,
                    IsWarrantyHasFeedbackEmail = userPreferenceViewModel.permissions.IsWarrantyHasFeedbackEmail,
                    IsWarrantyUpdatedApptEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptEmail,
                    IsWarrantyUpdatedApptText = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptText,
                    IsWarrantyScheduleChangedEmail = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedEmail,
                    IsWarrantyScheduleChangedText = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedText,
                    IsWarrantyAddedInternallyEmail = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyEmail,
                    IsWarrantyAddedInternallyText = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyText,
                    IsWarrantyAddedInternallyPush = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyPush,
                    IsWarrantyDiscussionAddedEmail = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedEmail,
                    IsWarrantyDiscussionAddedText = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedText,
                    IsWarrantyDiscussionAddedPush = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedPush,
                    IsWarrantyDiscussionAddedAllUsers = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedAllUsers,
                    IsWarrantyServiceInternallyAssignedEmail = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedEmail,
                    IsWarrantyServiceInternallyAssignedText = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedText,



                    IsTimeSheetAdjustmentEmail = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentEmail,
                    IsTimeSheetAdjustmentText = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentText,
                    IsTimeSheetAdjustmentPush = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentPush,
                    IsTimeSheetAdjustmentAllUsers = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentAllUsers,
                    IsOverTimeReachedEmail = userPreferenceViewModel.permissions.IsOverTimeReachedEmail,
                    IsOverTimeReachedText = userPreferenceViewModel.permissions.IsOverTimeReachedText,
                    IsOverTimeReachedPush = userPreferenceViewModel.permissions.IsOverTimeReachedPush,
                    IsOverTimeReachedAllUsers = userPreferenceViewModel.permissions.IsOverTimeReachedAllUsers,


                    IsEstimateAcceptedEmail = userPreferenceViewModel.permissions.IsEstimateAcceptedEmail,
                    IsEstimateAcceptedText = userPreferenceViewModel.permissions.IsEstimateAcceptedText,
                    IsEstimateViewedEmail = userPreferenceViewModel.permissions.IsEstimateViewedEmail,
                    IsEstimateViewedText = userPreferenceViewModel.permissions.IsEstimateViewedText,


                    IsOwnerSumittedSurveyEmail = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyEmail,
                    IsOwnerSumittedSurveyText = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyText,

                    IsSubInsuranceRemiderEmail = userPreferenceViewModel.permissions.IsSubInsuranceRemiderEmail,
                    IsSubActivatedEmail = userPreferenceViewModel.permissions.IsSubActivatedEmail,
                    IsTradeAgreementActionTakenEmail = userPreferenceViewModel.permissions.IsTradeAgreementActionTakenEmail

                };
                #region DetailedPermissions
                if (userid > 0)
                {
                    var obj2 = await _detaildPermissionHelper.SaveUserDetailsAsync(detailedPermissionViewModel);
                    if (obj2.DetaildPermissionId > 0)
                    {
                        ViewBag.result = 1;
                        //return Json(null);
                        result = 1;
                    }
                }
            }
            #endregion
            //  var result = userMAsterViewModel;
            //ViewBag.result = 1;
            //  return View(userPreferenceViewModel);
            return Json(result);
        }

        //[HttpPost]
        //public async Task<JsonResult> UserPreferencesDetails(UserPreferenceViewModel userPreferenceViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.result = 1;
        //        return View(userPreferenceViewModel);
        //        //return BadRequest(ModelState);
        //    }

        //    UserMasterViewModel userMasterViewModel = new UserMasterViewModel
        //    {
        //        UserFirstName = userPreferenceViewModel.usermasters.UserFirstName,
        //        UserLastName = userPreferenceViewModel.usermasters.UserLastName,
        //        UserEmail = userPreferenceViewModel.usermasters.UserEmail,
        //        UserEnabled = userPreferenceViewModel.usermasters.UserEnabled,
        //        UserLoginEnabled = userPreferenceViewModel.usermasters.UserLoginEnabled,
        //        UserPhone = userPreferenceViewModel.usermasters.UserPhone,
        //        UserCellEmail = userPreferenceViewModel.usermasters.UserCellEmail,
        //        UserContactInfo = userPreferenceViewModel.usermasters.UserContactInfo,
        //        UserDefaultTimeClock = userPreferenceViewModel.usermasters.UserDefaultTimeClock,
        //        UserDefaultLabourCost = userPreferenceViewModel.usermasters.UserDefaultLabourCost,
        //        UserIsAlert = userPreferenceViewModel.usermasters.UserIsAlert,
        //        UserAlertSchedule = userPreferenceViewModel.usermasters.UserAlertSchedule,
        //        UserIsAutomaticAccess = userPreferenceViewModel.usermasters.UserIsAutomaticAccess,
        //        UserName = userPreferenceViewModel.usermasters.UserName,
        //        UserPassword = userPreferenceViewModel.usermasters.UserPassword,
        //        UserIsForumHandle = userPreferenceViewModel.usermasters.UserIsForumHandle,
        //        UserForumHandle = userPreferenceViewModel.usermasters.UserForumHandle
        //    };


        //    var obj1 = await _userMasterHelper.GetUserByUserNameInDetails(userMasterViewModel.UserName);
        //    #region user name exists or not
        //    int userid = 0;
        //    if (obj1.Count > 0)
        //    {
        //        ViewBag.result = 2;
        //        return View(userPreferenceViewModel);
        //    }
        //    else
        //    {

        //        var obj = await _userMasterHelper.SaveUserMaster(userMasterViewModel);
        //        userid = Convert.ToInt32(obj.UserID);
        //    }
        //    #endregion

        //    if (userid > 1)
        //    {
        //        DetaildPermissionViewModel detailedPermissionViewModel = new DetaildPermissionViewModel
        //        {

        //            UserID = userid,
        //            IsViewAll = userPreferenceViewModel.permissions.IsViewAll,
        //            IsAddAll = userPreferenceViewModel.permissions.IsAddAll,
        //            IsEditall = userPreferenceViewModel.permissions.IsEditall,
        //            IsDeleteAll = userPreferenceViewModel.permissions.IsDeleteAll,
        //            IsJobInfoView = userPreferenceViewModel.permissions.IsJobInfoView,
        //            IsJobInfoAdd = userPreferenceViewModel.permissions.IsJobInfoAdd,
        //            IsJobInfoEdit = userPreferenceViewModel.permissions.IsJobInfoEdit,
        //            IsJobInfodelete = userPreferenceViewModel.permissions.IsJobInfodelete,
        //            IsViewOwnerSite = userPreferenceViewModel.permissions.IsViewOwnerSite,
        //            IsPriceViewing = userPreferenceViewModel.permissions.IsPriceViewing,
        //            IsOwnerPaymentsView = userPreferenceViewModel.permissions.IsOwnerPaymentsView,
        //            IsOwnerPaymentsAdd = userPreferenceViewModel.permissions.IsOwnerPaymentsAdd,
        //            IsOwnerPaymentsEdit = userPreferenceViewModel.permissions.IsOwnerPaymentsEdit,
        //            IsOwnerPaymentsDelete = userPreferenceViewModel.permissions.IsOwnerPaymentsDelete,
        //            IsLeadsView = userPreferenceViewModel.permissions.IsLeadsView,
        //            IsLeadsAdd = userPreferenceViewModel.permissions.IsLeadsAdd,
        //            IsLeadsEdit = userPreferenceViewModel.permissions.IsLeadsEdit,
        //            IsLeadsDelete = userPreferenceViewModel.permissions.IsLeadsDelete,
        //            IsLeadsAssignSalesperson = userPreferenceViewModel.permissions.IsLeadsAssignSalesperson,
        //            IsLeadsViewOtherSalesperson = userPreferenceViewModel.permissions.IsLeadsViewOtherSalesperson,
        //            IsLeadsConvertToJobsite = userPreferenceViewModel.permissions.IsLeadsConvertToJobsite,
        //            IsLeadsExportToExcel = userPreferenceViewModel.permissions.IsLeadsExportToExcel,
        //            IsCustomerContactsViewReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsViewReadOnly,
        //            IsCustomerContactsView = userPreferenceViewModel.permissions.IsCustomerContactsView,
        //            IsCustomerContactsAddReadOnly = userPreferenceViewModel.permissions.IsCustomerContactsAddReadOnly,
        //            IsCustomerContactsAdd = userPreferenceViewModel.permissions.IsCustomerContactsAdd,
        //            IsCustomerContactsEdit = userPreferenceViewModel.permissions.IsCustomerContactsEdit,
        //            IsCustomerContactsDelete = userPreferenceViewModel.permissions.IsCustomerContactsDelete,

        //            IsViewAllCustomerContactsReadonly = userPreferenceViewModel.permissions.IsViewAllCustomerContactsReadonly,
        //            IsViewAllCustomerContacts = userPreferenceViewModel.permissions.IsViewAllCustomerContacts,
        //            IsCustomerContactsExportToExcel = userPreferenceViewModel.permissions.IsCustomerContactsExportToExcel,

        //            IsToDoView = userPreferenceViewModel.permissions.IsToDoView,
        //            IsToDoAdd = userPreferenceViewModel.permissions.IsToDoView,
        //            IsToDoEdit = userPreferenceViewModel.permissions.IsToDoEdit,
        //            IsToDoDelete = userPreferenceViewModel.permissions.IsToDoDelete,
        //            IsToDoAssignUsers = userPreferenceViewModel.permissions.IsToDoAssignUsers,
        //            IsToDoGlobal = userPreferenceViewModel.permissions.IsToDoGlobal,


        //            IsLogsView = userPreferenceViewModel.permissions.IsLogsView,
        //            IsLogsAdd = userPreferenceViewModel.permissions.IsLogsAdd,
        //            IsLogsEdit = userPreferenceViewModel.permissions.IsLogsEdit,
        //            IsLogsDelete = userPreferenceViewModel.permissions.IsLogsDelete,

        //            IsBidsView = userPreferenceViewModel.permissions.IsBidsView,
        //            IsBidsAdd = userPreferenceViewModel.permissions.IsBidsAdd,
        //            IsBidsEdit = userPreferenceViewModel.permissions.IsBidsEdit,
        //            IsBidsDelete = userPreferenceViewModel.permissions.IsBidsDelete,

        //            IsCalendarView = userPreferenceViewModel.permissions.IsCalendarView,
        //            IsCalendarAdd = userPreferenceViewModel.permissions.IsCalendarAdd,
        //            IsCalendarEdit = userPreferenceViewModel.permissions.IsCalendarEdit,
        //            IsCalendarDelete = userPreferenceViewModel.permissions.IsCalendarDelete,
        //            IsSetBaseline = userPreferenceViewModel.permissions.IsSetBaseline,

        //            IsDocumentsView = userPreferenceViewModel.permissions.IsDocumentsView,
        //            IsDocumentsAdd = userPreferenceViewModel.permissions.IsDocumentsAdd,
        //            IsDocumentsEdit = userPreferenceViewModel.permissions.IsDocumentsEdit,
        //            IsDocumentsDelete = userPreferenceViewModel.permissions.IsDocumentsDelete,

        //            IsDocumentsAccessSubOwner = userPreferenceViewModel.permissions.IsDocumentsAccessSubOwner,
        //            IsDocumentsSignature = userPreferenceViewModel.permissions.IsDocumentsSignature,

        //            IsVideosView = userPreferenceViewModel.permissions.IsVideosView,
        //            IsVideosAdd = userPreferenceViewModel.permissions.IsVideosAdd,
        //            IsVideosEdit = userPreferenceViewModel.permissions.IsVideosEdit,
        //            IsVideosDelete = userPreferenceViewModel.permissions.IsVideosDelete,

        //            IsPhotosView = userPreferenceViewModel.permissions.IsPhotosView,
        //            IsPhotosAdd = userPreferenceViewModel.permissions.IsPhotosAdd,
        //            IsPhotosEdit = userPreferenceViewModel.permissions.IsPhotosEdit,
        //            IsPhotosDelete = userPreferenceViewModel.permissions.IsPhotosDelete,

        //            IsMessagesView = userPreferenceViewModel.permissions.IsMessagesView,
        //            IsMessagesAdd = userPreferenceViewModel.permissions.IsMessagesAdd,
        //            IsMessagesAddReadonly = userPreferenceViewModel.permissions.IsMessagesAddReadonly,
        //            IsMessagesEdit = userPreferenceViewModel.permissions.IsMessagesEdit,
        //            IsMessagesEditReadonly = userPreferenceViewModel.permissions.IsMessagesEditReadonly,
        //            IsMessagesDelete = userPreferenceViewModel.permissions.IsMessagesDelete,
        //            IsMessageGlobal = userPreferenceViewModel.permissions.IsMessageGlobal,

        //            IsRFIView = userPreferenceViewModel.permissions.IsRFIView,
        //            IsRFIAdd = userPreferenceViewModel.permissions.IsRFIAdd,
        //            IsRFIEdit = userPreferenceViewModel.permissions.IsRFIEdit,
        //            IsRFIDelete = userPreferenceViewModel.permissions.IsRFIDelete,

        //            IsChangeOrdersView = userPreferenceViewModel.permissions.IsChangeOrdersView,
        //            IsChangeOrdersAdd = userPreferenceViewModel.permissions.IsChangeOrdersAdd,
        //            IsChangeOrdersEdit = userPreferenceViewModel.permissions.IsChangeOrdersEdit,
        //            IsChangeOrdersDelete = userPreferenceViewModel.permissions.IsChangeOrdersDelete,
        //            IsChangeOrdersCostViewing = userPreferenceViewModel.permissions.IsChangeOrdersCostViewing,

        //            IsSelectionsView = userPreferenceViewModel.permissions.IsSelectionsView,
        //            IsSelectionsAdd = userPreferenceViewModel.permissions.IsSelectionsAdd,
        //            IsSelectionsEdit = userPreferenceViewModel.permissions.IsSelectionsEdit,
        //            IsSelectionsDelete = userPreferenceViewModel.permissions.IsSelectionsDelete,
        //            IsSelectionsCostViewing = userPreferenceViewModel.permissions.IsSelectionsCostViewing,

        //            IsBillView = userPreferenceViewModel.permissions.IsBillView,
        //            IsBillAdd = userPreferenceViewModel.permissions.IsBillAdd,
        //            IsBillEdit = userPreferenceViewModel.permissions.IsBillEdit,
        //            IsBillDelete = userPreferenceViewModel.permissions.IsBillDelete,
        //            IsBillAccounting = userPreferenceViewModel.permissions.IsBillAccounting,
        //            IsBillNoPriceLimit = userPreferenceViewModel.permissions.IsBillNoPriceLimit,
        //            IsBillCostViewing = userPreferenceViewModel.permissions.IsBillCostViewing,

        //            IsWarrantyView = userPreferenceViewModel.permissions.IsWarrantyView,
        //            IsWarrantyAdd = userPreferenceViewModel.permissions.IsWarrantyAdd,
        //            IsWarrantyEdit = userPreferenceViewModel.permissions.IsWarrantyEdit,
        //            IsWarrantyDelete = userPreferenceViewModel.permissions.IsWarrantyDelete,

        //            IsTimeClockView = userPreferenceViewModel.permissions.IsTimeClockView,
        //            IsTimeClockAdd = userPreferenceViewModel.permissions.IsTimeClockAdd,
        //            IsTimeClockEdit = userPreferenceViewModel.permissions.IsTimeClockEdit,
        //            IsTimeClockDelete = userPreferenceViewModel.permissions.IsTimeClockDelete,
        //            IsTimeClockViewOtherUser = userPreferenceViewModel.permissions.IsTimeClockViewOtherUser,
        //            IsTimeClockAdjustOtherUser = userPreferenceViewModel.permissions.IsTimeClockAdjustOtherUser,
        //            IsTimeClockCostViewing = userPreferenceViewModel.permissions.IsTimeClockCostViewing,
        //            IsTimeClockReviewAndApprove = userPreferenceViewModel.permissions.IsTimeClockReviewAndApprove,

        //            IsEstimateGIView = userPreferenceViewModel.permissions.IsEstimateGIView,
        //            IsEstimateGIAdd = userPreferenceViewModel.permissions.IsEstimateGIAdd,
        //            IsEstimateGIEdit = userPreferenceViewModel.permissions.IsEstimateGIEdit,
        //            IsEstimateGIDelete = userPreferenceViewModel.permissions.IsEstimateGIDelete,
        //            IsEstimateGIPriceViewing = userPreferenceViewModel.permissions.IsEstimateGIPriceViewing,

        //            IsSurveyView = userPreferenceViewModel.permissions.IsSurveyView,
        //            IsSurveyAdd = userPreferenceViewModel.permissions.IsSurveyAdd,
        //            IsSurveyEdit = userPreferenceViewModel.permissions.IsSurveyEdit,
        //            IsSurveyDelete = userPreferenceViewModel.permissions.IsSurveyDelete,
        //            IsSurveyAddReviewWebsite = userPreferenceViewModel.permissions.IsSurveyAddReviewWebsite,

        //            IsSubsView = userPreferenceViewModel.permissions.IsSubsView,
        //            IsSubsAdd = userPreferenceViewModel.permissions.IsSubsAdd,
        //            IsSubsEdit = userPreferenceViewModel.permissions.IsSubsEdit,
        //            IsSubsDelete = userPreferenceViewModel.permissions.IsSubsDelete,

        //            IsAdminView = userPreferenceViewModel.permissions.IsAdminView,
        //            IsAdminViewReadonly = userPreferenceViewModel.permissions.IsAdminViewReadonly,
        //            IsAdminAdd = userPreferenceViewModel.permissions.IsAdminAdd,
        //            IsAdminAddReadonly = userPreferenceViewModel.permissions.IsAdminAddReadonly,
        //            IsAdminEdit = userPreferenceViewModel.permissions.IsAdminEdit,
        //            IsAdminEditReadonly = userPreferenceViewModel.permissions.IsAdminEditReadonly,
        //            IsAdminDelete = userPreferenceViewModel.permissions.IsAdminDelete,
        //            IsAdminDeleteReadonly = userPreferenceViewModel.permissions.IsAdminDeleteReadonly,

        //            ImportNotificationId = userPreferenceViewModel.permissions.ImportNotificationId,
        //            IsEmailAll = userPreferenceViewModel.permissions.IsEmailAll,
        //            IsTextAll = userPreferenceViewModel.permissions.IsTextAll,
        //            IsPushOn = userPreferenceViewModel.permissions.IsPushOn,
        //            IsAllUsers = userPreferenceViewModel.permissions.IsAllUsers,

        //            IsOwnerActivatedEmail = userPreferenceViewModel.permissions.IsOwnerActivatedEmail,

        //            IsOwnerPaymentUpdatedEmail = userPreferenceViewModel.permissions.
        //  IsOwnerPaymentUpdatedText = userPreferenceViewModel.permissions.
        //  IsOwnerPaymentUpdatedPush = userPreferenceViewModel.permissions.

        //  IsOwnerPaymentReminderEmail = userPreferenceViewModel.permissions.IsOwnerPaymentReminderEmail,
        //            IsOwnerPaymentReminderText = userPreferenceViewModel.permissions.IsOwnerPaymentReminderText,
        //            IsOwnerPaymentReminderPush = userPreferenceViewModel.permissions.IsOwnerPaymentReminderPush,


        //            IsOwnerPaymentPastDueEmail = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueEmail,
        //            IsOwnerPaymentPastDueText = userPreferenceViewModel.permissions.IsOwnerPaymentPastDueText,
        //            IsOwnerPaymentPastDuePush = userPreferenceViewModel.permissions.IsOwnerPaymentPastDuePush,


        //            IsOwnerPaymentDiscussionEmail = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionEmail,
        //            IsOwnerPaymentDiscussionText = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionText,
        //            IsOwnerPaymentDiscussionPush = userPreferenceViewModel.permissions.IsOwnerPaymentDiscussionPush,

        //            IsOwnerPaymentAddedEmail = userPreferenceViewModel.permissions.IsOwnerPaymentAddedEmail,
        //            IsOwnerPaymentAddedText = userPreferenceViewModel.permissions.IsOwnerPaymentAddedText,
        //            IsOwnerPaymentAddedPush = userPreferenceViewModel.permissions.IsOwnerPaymentAddedPush,

        //            IsOtherEmployeeContactEmail = userPreferenceViewModel.permissions.IsOtherEmployeeContactEmail,
        //            IsOtherEmployeeContactText = userPreferenceViewModel.permissions.IsOtherEmployeeContactText,

        //            IsNewLeadEmail = userPreferenceViewModel.permissions.IsNewLeadEmail,
        //            IsNewLeadText = userPreferenceViewModel.permissions.IsNewLeadText,
        //            IsNewLeadPush = userPreferenceViewModel.permissions.IsNewLeadPush,

        //            IsLeadNotifyEmail = userPreferenceViewModel.permissions.IsLeadNotifyEmail,
        //            IsLeadNotifyText = userPreferenceViewModel.permissions.IsLeadNotifyText,
        //            IsLeadNotifyPush = userPreferenceViewModel.permissions.IsLeadNotifyPush,
        //            IsActivityRemainderEmail = userPreferenceViewModel.permissions.IsActivityRemainderEmail,
        //            IsActivityRemainderText = userPreferenceViewModel.permissions.IsActivityRemainderText,
        //            IsActivityRemainderPush = userPreferenceViewModel.permissions.IsActivityRemainderPush,
        //            IsActivityRemainderAllUsers = userPreferenceViewModel.permissions.IsActivityRemainderAllUsers,

        //            IsEmailQuotesAlertEmail = userPreferenceViewModel.permissions.IsEmailQuotesAlertEmail,
        //            IsEmailQuotesAlertText = userPreferenceViewModel.permissions.IsEmailQuotesAlertText,
        //            IsAssignedToLeadActivityEmail = userPreferenceViewModel.permissions.IsAssignedToLeadActivityEmail,
        //            IsAssignedToLeadActivityText = userPreferenceViewModel.permissions.IsAssignedToLeadActivityText,
        //            IsAssignedToLeadActivityPush = userPreferenceViewModel.permissions.IsAssignedToLeadActivityPush,

        //            IsLeadProposalAcceptedEmail = userPreferenceViewModel.permissions.IsLeadProposalAcceptedEmail,
        //            IsLeadProposalAcceptedText = userPreferenceViewModel.permissions.IsLeadProposalAcceptedText,
        //            IsLeadProposalAcceptedPush = userPreferenceViewModel.permissions.IsLeadProposalAcceptedPush,
        //            IsLeadProposalAcceptedAllUsers = userPreferenceViewModel.permissions.IsLeadProposalAcceptedAllUsers,

        //            IsLeadProposalViewedEmail = userPreferenceViewModel.permissions.IsLeadProposalViewedEmail,
        //            IsLeadProposalViewedText = userPreferenceViewModel.permissions.IsLeadProposalViewedText,
        //            IsLeadProposalViewedPush = userPreferenceViewModel.permissions.IsLeadProposalViewedPush,


        //            IsLinkedClickedByLeadEmail = userPreferenceViewModel.permissions.IsLinkedClickedByLeadEmail,
        //            IsLinkedClickedByLeadText = userPreferenceViewModel.permissions.IsLinkedClickedByLeadText,

        //            IsToDoCompletedEmail = userPreferenceViewModel.permissions.IsToDoCompletedEmail,
        //            IsToDoCompletedText = userPreferenceViewModel.permissions.IsToDoCompletedText,
        //            IsToDoCompletedPush = userPreferenceViewModel.permissions.IsToDoCompletedPush,
        //            IsToDoDiscussionAddedEmail = userPreferenceViewModel.permissions.IsToDoDiscussionAddedEmail,
        //            IsToDoDiscussionAddedText = userPreferenceViewModel.permissions.IsToDoDiscussionAddedText,
        //            IsToDoDiscussionAddedPush = userPreferenceViewModel.permissions.IsToDoDiscussionAddedPush,

        //            IsDailyLogNotificationEmail = userPreferenceViewModel.permissions.IsDailyLogNotificationEmail,
        //            IsDailyLogNotificationText = userPreferenceViewModel.permissions.IsDailyLogNotificationText,
        //            IsDailyLogNotificationPush = userPreferenceViewModel.permissions.IsDailyLogNotificationPush,
        //            IsDailyLogDiscussionAddedEmail = userPreferenceViewModel.permissions.IsDailyLogDiscussionAddedEmail,
        //            IsDailyLogNotificationAddedText = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedText,
        //            IsDailyLogNotificationAddedPush = userPreferenceViewModel.permissions.IsDailyLogNotificationAddedPush,

        //            IsBidSubmittedEmail = userPreferenceViewModel.permissions.IsBidSubmittedEmail,
        //            IsBidSubmittedText = userPreferenceViewModel.permissions.IsBidSubmittedText,
        //            IsBidSubmittedPush = userPreferenceViewModel.permissions.IsBidSubmittedPush,
        //            IsSubConfirmationEmail = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
        //            IsSubConfirmationText = userPreferenceViewModel.permissions.IsSubConfirmationEmail,
        //            IsSubConfirmationPush = userPreferenceViewModel.permissions.IsSubConfirmationPush,
        //            IsBidResubmittedEmail = userPreferenceViewModel.permissions.IsBidResubmittedEmail,
        //            IsBidResubmittedText = userPreferenceViewModel.permissions.IsBidResubmittedText,
        //            IsBidResubmittedPush = userPreferenceViewModel.permissions.IsBidResubmittedPush,
        //            IsBidDiscussionAddedEmail = userPreferenceViewModel.permissions.IsBidDiscussionAddedEmail,
        //            IsBidDiscussionAddedText = userPreferenceViewModel.permissions.IsBidDiscussionAddedText,
        //            IsBidDiscussionAddedPush = userPreferenceViewModel.permissions.IsBidDiscussionAddedPush,
        //            IsBidAcceptedBuilderEmail = userPreferenceViewModel.permissions.IsBidAcceptedBuilderEmail,
        //            IsBidAcceptedBuilderText = userPreferenceViewModel.permissions.IsBidAcceptedBuilderText,
        //            IsBidAcceptedBuilderPush = userPreferenceViewModel.permissions.IsBidAcceptedBuilderPush,


        //            IsUserNeedToConfirmChangeEmail = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeEmail,
        //            IsUserNeedToConfirmChangeText = userPreferenceViewModel.permissions.IsUserNeedToConfirmChangeText,
        //            IsUserNeedToConfirmChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangeEmail,
        //            IsUserConfirmedChangeEmail = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
        //            IsUserConfirmedChangeText = userPreferenceViewModel.permissions.IsUserConfirmedChangeText,
        //            IsUserConfirmedChangePush = userPreferenceViewModel.permissions.IsUserConfirmedChangePush,
        //            IsUserDeclinedChangeEmail = userPreferenceViewModel.permissions.IsUserDeclinedChangeEmail,
        //            IsUserDeclinedChangeText = userPreferenceViewModel.permissions.IsUserDeclinedChangeText,
        //            IsUserDeclinedChangePush = userPreferenceViewModel.permissions.IsUserDeclinedChangePush,
        //            IsScheduleItemDiscussionEmail = userPreferenceViewModel.permissions.IsScheduleItemDiscussionEmail,
        //            IsScheduleItemDiscussionText = userPreferenceViewModel.permissions.IsScheduleItemDiscussionText,
        //            IsScheduleItemDiscussionPush = userPreferenceViewModel.permissions.IsScheduleItemDiscussionPush,
        //            IsScheduleItemDiscussionAllUsers = userPreferenceViewModel.permissions.IsScheduleItemDiscussionAllUsers,

        //            IsDocumentCommentaddedEmail = userPreferenceViewModel.permissions.IsDocumentCommentaddedEmail,
        //            IsDocumentCommentaddedText = userPreferenceViewModel.permissions.IsDocumentCommentaddedText,
        //            IsDocumentCommentaddedPush = userPreferenceViewModel.permissions.IsDocumentCommentaddedPush,
        //            IsSubAndOwnerUploadedEmail = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedEmail,
        //            IsSubAndOwnerUploadedText = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedText,
        //            IsSubAndOwnerUploadedPush = userPreferenceViewModel.permissions.IsSubAndOwnerUploadedPush,
        //            IsSignatureRequestSignedEmail = userPreferenceViewModel.permissions.IsSignatureRequestSignedEmail,
        //            IsSignatureRequestSignedPush = userPreferenceViewModel.permissions.IsSignatureRequestSignedPush,
        //            IsSignatureRequestPastDueEmail = userPreferenceViewModel.permissions.IsSignatureRequestPastDueEmail,
        //            IsSignatureRequestPastDuePush = userPreferenceViewModel.permissions.IsSignatureRequestPastDuePush,

        //            IsVideoCommentAddedEmail = userPreferenceViewModel.permissions.IsVideoCommentAddedEmail,
        //            IsVideoCommentAddedText = userPreferenceViewModel.permissions.IsVideoCommentAddedText,
        //            IsVideoCommentAddedPush = userPreferenceViewModel.permissions.IsVideoCommentAddedPush,
        //            IsPhotoCommentAddedEmail = userPreferenceViewModel.permissions.IsPhotoCommentAddedEmail,
        //            IsPhotoCommentAddedText = userPreferenceViewModel.permissions.IsPhotoCommentAddedText,
        //            IsPhotoCommentAddedPush = userPreferenceViewModel.permissions.IsPhotoCommentAddedPush,

        //            IsNewMessageEmail = userPreferenceViewModel.permissions.IsNewMessageEmail,
        //            IsNewMessageText = userPreferenceViewModel.permissions.IsNewMessageText,
        //            IsNewMessagePush = userPreferenceViewModel.permissions.IsNewMessagePush,
        //            IsNewMessageAllUsers = userPreferenceViewModel.permissions.IsNewMessageAllUsers,

        //            IsRFIAddedByBuilderEmail = userPreferenceViewModel.permissions.IsRFIAddedByBuilderEmail,
        //            IsRFIAddedByBuilderText = userPreferenceViewModel.permissions.IsRFIAddedByBuilderText,
        //            IsRFIAddedByBuilderPush = userPreferenceViewModel.permissions.IsRFIAddedByBuilderPush,
        //            IsRFIResponseAddedEmail = userPreferenceViewModel.permissions.IsRFIResponseAddedEmail,
        //            IsRFIResponseAddedText = userPreferenceViewModel.permissions.IsRFIResponseAddedText,
        //            IsRFIResponseAddedPush = userPreferenceViewModel.permissions.IsRFIResponseAddedPush,
        //            IsRFIAddedEmail = userPreferenceViewModel.permissions.IsRFIAddedEmail,
        //            IsRFIAddedText = userPreferenceViewModel.permissions.IsRFIAddedText,
        //            IsRFIAddedPush = userPreferenceViewModel.permissions.IsRFIAddedPush,
        //            IsRFICompletedEmail = userPreferenceViewModel.permissions.IsRFICompletedEmail,
        //            IsRFICompletedText = userPreferenceViewModel.permissions.IsRFICompletedText,
        //            IsRFICompletedPush = userPreferenceViewModel.permissions.IsRFICompletedPush,
        //            IsRFIPastDueEmail = userPreferenceViewModel.permissions.IsRFIPastDueEmail,
        //            IsRFIPastDueText = userPreferenceViewModel.permissions.IsRFIPastDueText,


        //            IsChangeOrderapprovedEmail = userPreferenceViewModel.permissions.IsChangeOrderapprovedEmail,
        //            IsChangeOrderapprovedText = userPreferenceViewModel.permissions.IsChangeOrderapprovedText,
        //            IsChangeOrderapprovedPush = userPreferenceViewModel.permissions.IsChangeOrderapprovedPush,
        //            IsChangeOrderaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderaddedEmail,
        //            IsChangeOrderaddedText = userPreferenceViewModel.permissions.IsChangeOrderaddedText,
        //            IsChangeOrderaddedPush = userPreferenceViewModel.permissions.IsChangeOrderaddedPush,
        //            IsChangeOrderfilesaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedEmail,
        //            IsChangeOrderfilesaddedText = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedText,
        //            IsChangeOrderfilesaddedPush = userPreferenceViewModel.permissions.IsChangeOrderfilesaddedPush,
        //            IsChangeOrderDiscussionaddedEmail = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedEmail,
        //            IsChangeOrderDiscussionaddedText = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedText,
        //            IsChangeOrderDiscussionaddedPush = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedPush,
        //            IsChangeOrderDiscussionaddedAllUsers = userPreferenceViewModel.permissions.IsChangeOrderDiscussionaddedAllUsers,
        //            IsChangeOrderApprovedInternallyEmail = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyEmail,
        //            IsChangeOrderApprovedInternallyText = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyText,
        //            IsChangeOrderApprovedInternallyPush = userPreferenceViewModel.permissions.IsChangeOrderApprovedInternallyPush,
        //            IsOwnerRequestedChangeOrderEmail = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderEmail,
        //            IsOwnerRequestedChangeOrderText = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderText,
        //            IsOwnerRequestedChangeOrderPush = userPreferenceViewModel.permissions.IsOwnerRequestedChangeOrderPush,
        //            IsChangeOrderPastDueEmail = userPreferenceViewModel.permissions.IsChangeOrderPastDueEmail,
        //            IsChangeOrderPastDueText = userPreferenceViewModel.permissions.IsChangeOrderPastDueText,

        //            IsSelectionApprovedEmail = userPreferenceViewModel.permissions.IsSelectionApprovedEmail,
        //            IsSelectionApprovedText = userPreferenceViewModel.permissions.IsSelectionApprovedText,
        //            IsSelectionApprovedPush = userPreferenceViewModel.permissions.IsSelectionApprovedPush,
        //            IsSelectionDeadlineReminderEmail = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderEmail,
        //            IsSelectionDeadlineReminderPush = userPreferenceViewModel.permissions.IsSelectionDeadlineReminderPush,
        //            IsSelectionDiscussionAddedEmail = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedEmail,
        //            IsSelectionDiscussionAddedText = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedText,
        //            IsSelectionDiscussionAddedPush = userPreferenceViewModel.permissions.IsSelectionDiscussionAddedPush,
        //            IsSelectionChoiceAddedEmail = userPreferenceViewModel.permissions.IsSelectionChoiceAddedEmail,
        //            IsSelectionChoiceAddedText = userPreferenceViewModel.permissions.IsSelectionChoiceAddedText,
        //            IsSelectionChoiceAddedPush = userPreferenceViewModel.permissions.IsSelectionChoiceAddedPush,
        //            IsSelectionOwnerPriceEmail = userPreferenceViewModel.permissions.IsSelectionOwnerPriceEmail,
        //            IsSelectionOwnerPriceText = userPreferenceViewModel.permissions.IsSelectionOwnerPriceText,
        //            IsSelectionOwnerPricePush = userPreferenceViewModel.permissions.IsSelectionOwnerPricePush,
        //            IsSelectionApprovedInternallyEmail = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyText,
        //            IsSelectionApprovedInternallyText = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
        //            IsSelectionApprovedInternallyPush = userPreferenceViewModel.permissions.IsSelectionApprovedInternallyPush,
        //            IsSelectionSubPriceEmail = userPreferenceViewModel.permissions.IsSelectionSubPriceEmail,
        //            IsSelectionSubPriceText = userPreferenceViewModel.permissions.IsSelectionSubPriceText,
        //            IsSelectionSubPricePush = userPreferenceViewModel.permissions.IsSelectionSubPricePush,

        //            IsPOApprovedEmail = userPreferenceViewModel.permissions.IsPOApprovedEmail,
        //            IsPOApprovedText = userPreferenceViewModel.permissions.IsPOApprovedText,
        //            IsPOApprovedPush = userPreferenceViewModel.permissions.IsPOApprovedPush,
        //            IsPOPaymentMarkedEmail = userPreferenceViewModel.permissions.IsPOPaymentMarkedEmail,
        //            IsLienWaiverAcceptedEmail = userPreferenceViewModel.permissions.IsLienWaiverAcceptedEmail,
        //            IsLienWaiverAcceptedText = userPreferenceViewModel.permissions.IsLienWaiverAcceptedText,
        //            IsLienWaiverDeclinedEmail = userPreferenceViewModel.permissions.IsLienWaiverDeclinedEmail,
        //            IsLienWaiverDeclinedText = userPreferenceViewModel.permissions.IsLienWaiverDeclinedText,
        //            IsPOApprovedInternallyEmail = userPreferenceViewModel.permissions.IsPOApprovedInternallyEmail,
        //            IsPOApprovedInternallyText = userPreferenceViewModel.permissions.IsPOApprovedInternallyText,
        //            IsPOApprovedInternallyPush = userPreferenceViewModel.permissions.IsPOApprovedInternallyPush,
        //            IsPODeclinedEmail = userPreferenceViewModel.permissions.IsPODeclinedEmail,
        //            IsPODeclinedText = userPreferenceViewModel.permissions.IsPODeclinedText,
        //            IsPODeclinedPush = userPreferenceViewModel.permissions.IsPODeclinedPush,
        //            IsPOAssignedInternallyEmail = userPreferenceViewModel.permissions.IsPOAssignedInternallyEmail,
        //            IsPOAssignedInternallyText = userPreferenceViewModel.permissions.IsPOAssignedInternallyText,
        //            IsPOInspectionEmail = userPreferenceViewModel.permissions.IsPOInspectionEmail,
        //            IsPOInspectionPush = userPreferenceViewModel.permissions.IsPOInspectionPush,
        //            IsPOWorkcompletedEmail = userPreferenceViewModel.permissions.IsPOWorkcompletedEmail,
        //            IsPOPaymentMadeEmail = userPreferenceViewModel.permissions.IsPOPaymentMadeEmail,
        //            IsPODiscussionAddedEmail = userPreferenceViewModel.permissions.IsPODiscussionAddedEmail,
        //            IsPODiscussionAddedText = userPreferenceViewModel.permissions.IsPODiscussionAddedText,
        //            IsPODiscussionAddedPush = userPreferenceViewModel.permissions.IsPODiscussionAddedPush,
        //            IsPOFileAddedEmail = userPreferenceViewModel.permissions.IsPOFileAddedEmail,
        //            IsPOInspectionReminderEmail = userPreferenceViewModel.permissions.IsPOInspectionReminderEmail,
        //            IsPOInspectionReminderText = userPreferenceViewModel.permissions.IsPOInspectionReminderText,
        //            IsPOInspectionReminderPush = userPreferenceViewModel.permissions.IsPOInspectionReminderPush,
        //            IsPOWorkCompleteEmail = userPreferenceViewModel.permissions.IsPOWorkCompleteEmail,
        //            IsPOWorkCompleteText = userPreferenceViewModel.permissions.IsPOWorkCompleteText,
        //            IsPOWorkCompletePush = userPreferenceViewModel.permissions.IsPOWorkCompletePush,
        //            IsBillPaymentReminderEmail = userPreferenceViewModel.permissions.IsBillPaymentReminderEmail,

        //            IsWarrantyAddedEmail = userPreferenceViewModel.permissions.IsWarrantyAddedEmail,
        //            IsWarrantyAddedText = userPreferenceViewModel.permissions.IsWarrantyAddedText,
        //            IsWarrantyAddedPush = userPreferenceViewModel.permissions.IsWarrantyAddedPush,
        //            IsWarrantyFollowUpEmail = userPreferenceViewModel.permissions.IsWarrantyFollowUpEmail,
        //            IsWarrantyFollowUpText = userPreferenceViewModel.permissions.IsWarrantyFollowUpText,
        //            IsWarrantyFollowUpAllUsers = userPreferenceViewModel.permissions.IsWarrantyFollowUpAllUsers,
        //            IsWarrantyUpdatedEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedEmail,
        //            IsWarrantyUpdatedText = userPreferenceViewModel.permissions.IsWarrantyUpdatedText,
        //            IsWarrantyHasFeedbackEmail = userPreferenceViewModel.permissions.IsWarrantyHasFeedbackEmail,
        //            IsWarrantyUpdatedApptEmail = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptEmail,
        //            IsWarrantyUpdatedApptText = userPreferenceViewModel.permissions.IsWarrantyUpdatedApptText,
        //            IsWarrantyScheduleChangedEmail = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedEmail,
        //            IsWarrantyScheduleChangedText = userPreferenceViewModel.permissions.IsWarrantyScheduleChangedText,
        //            IsWarrantyAddedInternallyEmail = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyEmail,
        //            IsWarrantyAddedInternallyText = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyText,
        //            IsWarrantyAddedInternallyPush = userPreferenceViewModel.permissions.IsWarrantyAddedInternallyPush,
        //            IsWarrantyDiscussionAddedEmail = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedEmail,
        //            IsWarrantyDiscussionAddedText = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedText,
        //            IsWarrantyDiscussionAddedPush = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedPush,
        //            IsWarrantyDiscussionAddedAllUsers = userPreferenceViewModel.permissions.IsWarrantyDiscussionAddedAllUsers,
        //            IsWarrantyServiceInternallyAssignedEmail = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedEmail,
        //            IsWarrantyServiceInternallyAssignedText = userPreferenceViewModel.permissions.IsWarrantyServiceInternallyAssignedText,



        //            IsTimeSheetAdjustmentEmail = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentEmail,
        //            IsTimeSheetAdjustmentText = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentText,
        //            IsTimeSheetAdjustmentPush = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentPush,
        //            IsTimeSheetAdjustmentAllUsers = userPreferenceViewModel.permissions.IsTimeSheetAdjustmentAllUsers,
        //            IsOverTimeReachedEmail = userPreferenceViewModel.permissions.IsOverTimeReachedEmail,
        //            IsOverTimeReachedText = userPreferenceViewModel.permissions.IsOverTimeReachedText,
        //            IsOverTimeReachedPush = userPreferenceViewModel.permissions.IsOverTimeReachedPush,
        //            IsOverTimeReachedAllUsers = userPreferenceViewModel.permissions.IsOverTimeReachedAllUsers,


        //            IsEstimateAcceptedEmail = userPreferenceViewModel.permissions.IsEstimateAcceptedEmail,
        //            IsEstimateAcceptedText = userPreferenceViewModel.permissions.IsEstimateAcceptedText,
        //            IsEstimateViewedEmail = userPreferenceViewModel.permissions.IsEstimateViewedEmail,
        //            IsEstimateViewedText = userPreferenceViewModel.permissions.IsEstimateViewedText,


        //            IsOwnerSumittedSurveyEmail = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyEmail,
        //            IsOwnerSumittedSurveyText = userPreferenceViewModel.permissions.IsOwnerSumittedSurveyText,

        //            IsSubInsuranceRemiderEmail = userPreferenceViewModel.permissions.IsSubInsuranceRemiderEmail,
        //            IsSubActivatedEmail = userPreferenceViewModel.permissions.IsSubActivatedEmail,
        //            IsTradeAgreementActionTakenEmail = userPreferenceViewModel.permissions.IsTradeAgreementActionTakenEmail

        //        };
        //        #region DetailedPermissions
        //        if (userid > 0)
        //        {
        //            var obj2 = await _detaildPermissionHelper.SaveUserDetailsAsync(detailedPermissionViewModel);
        //        }
        //    }
        //    #endregion
        //    //  var result = userMAsterViewModel;
        //    //ViewBag.result = 1;
        //    return View(userPreferenceViewModel);
        //}
    }



}
