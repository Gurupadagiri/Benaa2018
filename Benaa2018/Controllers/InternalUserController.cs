using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benaa2018.Controllers
{
    public class InternalUserController : BaseController
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
        public InternalUserController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper, IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper, IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper, IToDoMasterHelper toDoMasterHelper,
            IUserMasterHelper userMasterHelper, IWarrentyAlertHelper warrentyAlertHelper,
            ICompanyMasterHelper companyMasterHelper, IDetaildPermissionHelper detaildPermissionHelper) : base(menuMasterHelper,
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
        }
        public async Task<IActionResult> Index()
        {
            BaseViewModel baseModel = ViewBag.Basemodel;
            // User Grid
            List<InternalUserGridModel> userGrid = new List<InternalUserGridModel>();            
            baseModel.UserMasterViewModels.ForEach(a =>
            {
                userGrid.Add(new InternalUserGridModel
                {
                    AdminAccess = a.UserEnabled,
                    AutoAccess = a.UserIsAutomaticAccess,
                    Email = a.UserEmail,
                    LoginEnabled = a.UserEnabled,
                    Name = a.FullName,
                    Phone = a.UserPhone,
                    UserId = a.UserID
                });
            });
            List<SubContractorGridModel> subContactorGrid = new List<SubContractorGridModel>();
            var lstSubContractor = await _subContractorHelper.GetAllSubContractorsByCompanyId(1);
            lstSubContractor.ForEach(a =>
            {
                subContactorGrid.Add(new SubContractorGridModel
                {
                    Activation = "",
                    Cell = a.Mobile,
                    Email = a.Email,
                    Company = "",
                    Division = "",
                    Phone = a.Tel,
                    LiabilityExp = "",
                    PrimaryContact = "",
                    SubContractorId = a.SubContractorID,
                    TradeAgreement = "",
                    WorkCompExp = ""
                });
            });
            InternalUserViewModel internalUser = new InternalUserViewModel
            {
                InternalUserJsonGrid = JsonConvert.SerializeObject(userGrid),
                SubContractorJsonGrid = JsonConvert.SerializeObject(subContactorGrid),
            };
            ViewBag.IsleftMenuVisible = false;
            return View(internalUser);
        }

        public async Task<string> FilterInternalUserAsync(int companyId, string name, string status)
        {
            List<InternalUserGridModel> userGrid = new List<InternalUserGridModel>();
            var objInterUser = await _userMasterHelper.GetInternalUserByName(companyId, name, status);
            objInterUser.ForEach(a =>
            {
                userGrid.Add(new InternalUserGridModel
                {
                    AdminAccess = a.UserEnabled,
                    AutoAccess = a.UserIsAutomaticAccess,
                    Email = a.UserEmail,
                    LoginEnabled = a.UserEnabled,
                    Name = a.FullName,
                    Phone = a.UserPhone,
                    UserId = a.UserID
                });
            });
            return JsonConvert.SerializeObject(userGrid);
        }
    }
}