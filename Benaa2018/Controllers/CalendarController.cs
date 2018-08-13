using Benaa2018.Helper;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                CalendarScheduledItemModels = await _calendarScheduleHelper.GetAllScheduledItems(1, 1),
                PredecessorInformationModels = await _calendarScheduleHelper.GetAllPredecessorInformationsAsync(1)
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

        public async Task<string> GetScheduledItemsByProjectId(int projectId)
        {
            List<CalendarScheduledItemViewModel> lstCalendarItem = new List<CalendarScheduledItemViewModel>();
            try
            {
                var scheduledItem = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId);
                return ScheduledEvents(scheduledItem);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public async Task<List<CalendarScheduledItemViewModel>> GetScheduledItems(int projectId)
        {
            List<CalendarScheduledItemViewModel> lstCalendarItem = new List<CalendarScheduledItemViewModel>();
            try
            {
                return await _calendarScheduleHelper.GetAllScheduledItems(1, projectId);
            }
            catch (Exception ex)
            {
                return lstCalendarItem;
            }
        }

        public async Task<string> GetGnattItems(int projectId)
        {
            List<GanttChartModel> lstGnattModel = new List<GanttChartModel>();
            var scheduledItem = await _calendarScheduleHelper.GetAllScheduledItems(1, projectId);
            scheduledItem.ForEach(a =>
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
                    users = new List<string> { _userMasterHelper.GetUserByUserId(Convert.ToInt32(a.AssignedTo)).Result.FullName },
                });
            });

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

        public async Task<bool> SubmitPhaseAsync(int projectId, string phaseName,int displayOrder,string phasecolor)
        {
            try
            {
                CalendarPhaseViewModel calendar = new CalendarPhaseViewModel
                {
                    CompanyId = 1,
                    ProjectId = projectId,
                    PhaseName = phaseName,
                    DisplayOrder= displayOrder,
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
    }
}