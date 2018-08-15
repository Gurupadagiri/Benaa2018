using Benaa2018.Helper;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1, 1, DateTime.MinValue),
                //PredecessorInformationModels = await _calendarScheduleHelper.GetAllPredecessorInformationsAsync(1),
                CalendarPhaseModels = await _calendarScheduleHelper.GetAllPhaseAsync(1, 1),
                CalendarTagModels = await _calendarScheduleHelper.GetAllTagAsync(1, 1)
            };
            if (calendar.PredecessorInformationModels.Count == 0)
            {
                calendar.PredecessorInformationModels.Add(new PredecessorInformationViewModel
                {
                    ScheduledItemId = 0,
                    Lag = 0,
                    TimeFrame = "1"
                });
            }
            return View(calendar);
        }

        public async Task<bool> SubmitPredecessorInfoAsync(CalendarScheduledItemViewModel calendarModel)
        {
            try
            {
                if (calendarModel.ScheduledItemId == 0)
                {
                    int scheduleId = await _calendarScheduleHelper.SaveCalendarScheduleItemAsync(1, calendarModel);
                    foreach (var item in calendarModel.PredecessorInformationModels)
                    {
                        await _calendarScheduleHelper.SavePredecessorInformationAsync(scheduleId, calendarModel.ProjectId, calendarModel.CompanyId, item);
                    }
                }
                else
                {
                    int scheduleId = await _calendarScheduleHelper.UpdateCalendarScheduleItemAsync(1, calendarModel);
                    foreach (var item in calendarModel.PredecessorInformationModels)
                    {
                        await _calendarScheduleHelper.UpdatePredecessorInformationAsync(item);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string ScheduledEvents(List<CalendarScheduledItemViewModel> calendarItem)
        {
            List<CalendarEvent> lstEvenets = new List<CalendarEvent>();
            calendarItem.ForEach(a =>
            {
                lstEvenets.Add(new CalendarEvent
                {
                    id = a.ScheduledItemId,
                    start = Convert.ToDateTime(a.StartDate).ToString("yyyy-MM-dd"),
                    end = Convert.ToDateTime(a.EndDate).ToString("yyyy-MM-dd"),
                    color = a.ColorCode,
                    title = a.Title
                });
            });
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstEvenets);
        }

        public async Task<string> GetScheduledItemsByProjectId(int projectId, string selectedDate = "")
        {
            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            var scheduledItem = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);
            return ScheduledEvents(scheduledItem);
        }

        public async Task<List<CalendarScheduledItemViewModel>> GetScheduledItems(int projectId, string selectedDate = "")
        {
            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            return await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);
        }

        public async Task<string> GetGnattItems(int projectId, string selectedDate = "")
        {
            List<GanttChartModel> lstGnattModel = new List<GanttChartModel>();
            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            var scheduledItem = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);
            if (scheduledItem.Count != 0)
            {
                foreach (var a in scheduledItem)
                {
                    lstGnattModel.Add(new GanttChartModel
                    {
                        id = a.ScheduledItemId,
                        text = a.Title,
                        start_date = Convert.ToDateTime(a.StartDate).ToString("dd-MM-yyyy"),
                        end_date = Convert.ToDateTime(a.EndDate).ToString("dd-MM-yyyy"),
                        duration = a.Duration.ToString(),
                        color = a.ColorCode,
                        status = true,
                        pred = "",
                        users = new List<string> { a.AssignedTo },
                    });
                }
            }
            List<CalendarLink> lstCalendarLink = new List<CalendarLink>();
            var count = 0;
            scheduledItem.ForEach(async a =>
            {
                count++;
                var predessorInfo = await _calendarScheduleHelper.GetPredecessorByScheduleIdAsyn(a.ScheduledItemId);
                predessorInfo.ForEach(b =>
                {
                    lstCalendarLink.Add(new CalendarLink
                    {
                        id = count,
                        source = b.SourceScheuledId,
                        target = b.ScheduledItemId,
                        type = 0
                    });
                });
            });
            var projectInfo = new Tuple<List<GanttChartModel>, List<CalendarLink>>(
                lstGnattModel, lstCalendarLink);
            return JsonConvert.SerializeObject(projectInfo);
        }

        public async Task<IActionResult> GetScheduledDetailsByIdAsync(int scheduledId)
        {
            var calendarInfo = await _calendarScheduleHelper.GetAllScheduledItem(scheduledId);
            calendarInfo.CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1, calendarInfo.ProjectId, DateTime.MinValue);
            calendarInfo.PredecessorInformationModels = await _calendarScheduleHelper.GetPredecessorInfoByScheduleIdAsync(scheduledId);
            if (calendarInfo.PredecessorInformationModels.Count == 0)
            {
                calendarInfo.PredecessorInformationModels.Add(new PredecessorInformationViewModel
                {
                    ScheduledItemId = 0,
                    Lag = 0,
                    TimeFrame = "1"
                });
            }
            return PartialView("_addCalendar", calendarInfo);
        }

        public async Task<bool> SubmitQuickSchedulerInfoAsync(CalendarScheduledItemViewModel calendarModel)
        {
            try
            {
                int scheduleId = await _calendarScheduleHelper.SaveCalendarScheduleItemAsync(1, calendarModel);
                foreach (var item in calendarModel.PredecessorInformationModels)
                {
                    await _calendarScheduleHelper.SavePredecessorInformationAsync(scheduleId, calendarModel.ProjectId, calendarModel.CompanyId, item);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SubmitPhaseAsync(int projectId, string phaseName, int displayOrder, string phasecolor)
        {
            try
            {
                CalendarPhaseViewModel calendar = new CalendarPhaseViewModel
                {
                    CompanyId = 1,
                    ProjectId = projectId,
                    PhaseName = phaseName,
                    DisplayOrder = displayOrder,
                    PhaseColor = phasecolor
                };
                int scheduleId = await _calendarScheduleHelper.SaveCalendarPhaseAsync(calendar);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SubmitTagAsync(int projectId, string tagName)
        {
            try
            {
                CalendarTagViewModel calendar = new CalendarTagViewModel
                {
                    CompanyId = 1,
                    ProjectId = projectId,
                    TagName = tagName,
                };
                int scheduleId = await _calendarScheduleHelper.SaveCalendarTagAsync(calendar);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<JsonResult> GetBaselineView(int projectId, string selectedDate = "")
        {
            List<CalendarScheduledItemViewModel> lstCalendarItem = new List<CalendarScheduledItemViewModel>();

            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            var scheduledItems = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);

            DateTime MinStartDate = scheduledItems.Min(a => Convert.ToDateTime(a.StartDate));
            DateTime MaxStartDate = scheduledItems.Max(a => Convert.ToDateTime(a.EndDate));
            int totaldate = 0;
            foreach (var item in scheduledItems)
            {
                DateDifference(Convert.ToDateTime(item.StartDate), Convert.ToDateTime(item.EndDate), ref totaldate);
            }
            var totalDuration = scheduledItems.Sum(a => a.Duration);

            var projectInfo = new Tuple<List<CalendarScheduledItemViewModel>, DateTime, DateTime, int, int>(
            scheduledItems, MinStartDate, MaxStartDate, totaldate, totalDuration);
            return Json(projectInfo);
        }

        public void DateDifference(DateTime startDate, DateTime endDate, ref int totaldate)
        {
            totaldate = endDate.Subtract(startDate).Days;
        }

        public async Task<JsonResult> GetPhasesListAsync(int projectId, string selectedDate = "")
        {
            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            var scheduledList = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);
            return Json(scheduledList.OrderBy(a => a.TagId));
        }

        public async Task<string> GetFilteredScheduleAsync(int projectId, 
            string searchText,string performedBy,string status,string tags,
            string projectPhases,string otherItems, string selectedDate= "")
        {
            DateTime currentDate = DateTime.MinValue;
            if (selectedDate != string.Empty) currentDate = Convert.ToDateTime(selectedDate);
            var scheduledList = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId, currentDate);
            if (!string.IsNullOrEmpty(searchText))
            {
                scheduledList = scheduledList.Where(a => a.Title.ToLower().StartsWith(searchText.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(performedBy))
            {
                scheduledList = scheduledList.Where(a => a.AssignedTo.Contains(performedBy)).ToList();
            }
            return ScheduledEvents(scheduledList);
        }
    }
}