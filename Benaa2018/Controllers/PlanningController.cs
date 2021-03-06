﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Benaa2018.Helper;

namespace Benaa2018.Controllers
{
    public class PlanningController : BaseController
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
        public PlanningController(IMenuMasterHelper menuMasterHelper,
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DependencyStore()
        {

            return Json(string.Empty);
        }

        public IActionResult TaskStore()
        {

            return Json(string.Empty);
        }
    }
}