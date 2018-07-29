using Benaa2018.Helper;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            // User Grid
            List<InternalUserGridModel> userGrid = new List<InternalUserGridModel>();
            var objInterUser = await _userMasterHelper.GetAllInternalUsers();
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
            InternalUserViewModel objInternalUser = new InternalUserViewModel
            {
                InternalUserGrid = userGrid
            };
            ViewBag.IsleftMenuVisible = false;
            return View();
        }
    }
}