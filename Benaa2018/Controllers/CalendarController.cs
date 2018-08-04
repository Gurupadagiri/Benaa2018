using Benaa2018.Helper;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Benaa2018.Controllers
{
    public class CalendarController : BaseController
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
        private readonly ICalendarScheduleHelper _calendarScheduleHelper;
        public CalendarController(IMenuMasterHelper menuMasterHelper,
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
            ICompanyMasterHelper companyMasterHelper,
            ICalendarScheduleHelper calendarScheduleHelper) 
            : base(menuMasterHelper,
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
            _companyMasterHelper = companyMasterHelper;
            _calendarScheduleHelper = calendarScheduleHelper;
        }
        public async Task<IActionResult> Index()
        {
            CalendarScheduledItemViewModel calendar = new CalendarScheduledItemViewModel
            {
                CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1)
            };
            return View(calendar);
        }

        public async Task<bool> SubmitPredecessorInfoAsync(CalendarScheduledItemViewModel calendarModel)
        {
            try
            {
                var calendar = await _calendarScheduleHelper.SaveCalendarScheduleItemAsync(calendarModel);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}