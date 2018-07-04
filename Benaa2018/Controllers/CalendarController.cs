using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Benaa2018.Helper;

namespace Benaa2018.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IMenuMasterHelper _menuMasterHelper;
        private readonly IProjectMasterHelper _projectMasterHelper;
        public CalendarController(IMenuMasterHelper menuMasterHelper, IProjectMasterHelper projectMasterHelper)
        {
            _menuMasterHelper = menuMasterHelper;
            _projectMasterHelper = projectMasterHelper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.MenuDetails = await _menuMasterHelper.GetMenuItems();
            ViewBag.ProjectMasterModels = await _projectMasterHelper.GetAllProjectByUserId(1);
            ViewBag.ProjectManagerMasterModels = await _projectMasterHelper.GetAllManagers();
            return View();
        }
    }
}