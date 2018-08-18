using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class CalendarScheduleHelper : ICalendarScheduleHelper
    {
        private readonly ICalendarScheduledItemRepoisitory _calendarScheduledItemRepoisitory;
        private readonly IPredecessorInformationRepository _predecessorInformationRepository;
        private readonly ICalendarPhaseRepository _calendarPhaseRepository;
        private readonly ICalendarTagRepository _calendarTagRepository;
        private readonly IUserMasterRepository _userMasterRepository;
        public CalendarScheduleHelper(ICalendarScheduledItemRepoisitory calendarScheduledItemRepoisitory,
            IPredecessorInformationRepository predecessorInformationRepository,
            ICalendarPhaseRepository calendarPhaseRepository,
            ICalendarTagRepository calendarTagRepository,
            IUserMasterRepository userMasterRepository)
        {
            _calendarScheduledItemRepoisitory = calendarScheduledItemRepoisitory;
            _predecessorInformationRepository = predecessorInformationRepository;
            _calendarPhaseRepository = calendarPhaseRepository;
            _calendarTagRepository = calendarTagRepository;
            _userMasterRepository = userMasterRepository;
        }
        public async Task<int> SaveCalendarScheduleItemAsync(int companyId, CalendarScheduledItemViewModel calendarScheuledItem)
        {
            CalendarScheduledItem calendarItem = new CalendarScheduledItem
            {
                ScheduledItemId = calendarScheuledItem.ScheduledItemId,
                Title = calendarScheuledItem.Title,
                AssignedTo = calendarScheuledItem.AssignedTo,
                ColorCode = calendarScheuledItem.ColorCode,
                Duration = calendarScheuledItem.Duration,
                EndDate = Convert.ToDateTime(calendarScheuledItem.EndDate),
                EndTime = calendarScheuledItem.EndTime,
                Hourly = calendarScheuledItem.Hourly,
                Reminder = calendarScheuledItem.Reminder,
                StartDate = Convert.ToDateTime(calendarScheuledItem.StartDate),
                StartTime = calendarScheuledItem.StartTime,
                CompanyId = companyId,
                ProjectId = calendarScheuledItem.ProjectId
            };
            var companyObj = await _calendarScheduledItemRepoisitory.CreateAsync(calendarItem);
            return companyObj.ScheduledItemId;
        }

        public async Task<int> UpdateCalendarScheduleItemAsync(int companyId, CalendarScheduledItemViewModel calendarScheuledItem)
        {
            CalendarScheduledItem calendarItem = new CalendarScheduledItem
            {
                ScheduledItemId = calendarScheuledItem.ScheduledItemId,
                Title = calendarScheuledItem.Title,
                AssignedTo = calendarScheuledItem.AssignedTo,
                ColorCode = calendarScheuledItem.ColorCode,
                Duration = calendarScheuledItem.Duration,
                EndDate = Convert.ToDateTime(calendarScheuledItem.EndDate),
                EndTime = calendarScheuledItem.EndTime,
                Hourly = calendarScheuledItem.Hourly,
                Reminder = calendarScheuledItem.Reminder,
                StartDate = Convert.ToDateTime(calendarScheuledItem.StartDate),
                StartTime = calendarScheuledItem.StartTime,
                CompanyId = companyId,
                ProjectId = calendarScheuledItem.ProjectId
            };
            var companyObj = await _calendarScheduledItemRepoisitory.UpdateAsync(calendarItem);
            return companyObj.ScheduledItemId;
        }

        public async Task<List<CalendarScheduledItemViewModel>> GetAllScheduledItems(int companyId, int projectId, DateTime startDate)
        {
            List<CalendarScheduledItemViewModel> lstCalendarItems = new List<CalendarScheduledItemViewModel>();
            var scheduledItems = await _calendarScheduledItemRepoisitory.GetScheduledItemByProjectId(companyId, projectId, startDate);
            foreach (var a in scheduledItems)
            {
                var assignedUser = await _userMasterRepository.GetByIdAsync(a.AssignedTo == null ? 0 : Convert.ToInt32(a.AssignedTo));
                var phaseObj = a.PhaseId != null ? await _calendarPhaseRepository.GetByIdAsync(a.PhaseId) : null;
                var tagObj = a.TagId != null ? await _calendarTagRepository.GetByIdAsync(a.TagId) : null;
                lstCalendarItems.Add(new CalendarScheduledItemViewModel
                {
                    ScheduledItemId = a.ScheduledItemId,
                    Title = a.Title,
                    AssignedTo = assignedUser == null ? string.Empty : assignedUser.FullName,
                    ColorCode = a.ColorCode,
                    CreatdDate = a.Created_Date,
                    Duration = a.Duration,
                    EndDate = a.EndDate.ToString(),
                    EndTime = a.EndTime,
                    Hourly = a.Hourly,
                    Reminder = a.Reminder,
                    StartDate = a.StartDate.ToString(),
                    StartTime = a.StartTime,
                    CompanyId = a.CompanyId,
                    ProjectId = a.ProjectId,
                    PhaseId = a.PhaseId,
                    TagId = a.TagId,
                    PhaseName = phaseObj != null ? phaseObj.PhaseName : string.Empty,
                    TagName = tagObj != null ? tagObj.TagName : string.Empty,
                    TotalScheuleDay= a.EndDate.Subtract(a.StartDate).Days,
                    ScheuleDay = a.EndDate.Subtract(DateTime.Now).Days,
                });
            }            
            return lstCalendarItems;
        }

        public async Task<CalendarScheduledItemViewModel> GetAllScheduledItem(int scheduledId)
        {
            var scheduledItems = await _calendarScheduledItemRepoisitory.GetScheduledItemByScheduleIdAsync(scheduledId);
            return (new CalendarScheduledItemViewModel
            {
                ScheduledItemId = scheduledItems.ScheduledItemId,
                Title = scheduledItems.Title,
                AssignedTo = scheduledItems.AssignedTo,
                ColorCode = scheduledItems.ColorCode,
                CreatdDate = scheduledItems.Created_Date,
                Duration = scheduledItems.Duration,
                EndDate = scheduledItems.EndDate.ToString(),
                EndTime = scheduledItems.EndTime,
                Hourly = scheduledItems.Hourly,
                Reminder = scheduledItems.Reminder,
                StartDate = scheduledItems.StartDate.ToString(),
                StartTime = scheduledItems.StartTime,
                CompanyId = scheduledItems.CompanyId,
                ProjectId = scheduledItems.ProjectId,
                PredecessorInformationModels = await GetPredecessorByScheduleIdAsyn(scheduledId)
            });
        }

        public async Task<int> SavePredecessorInformationAsync(int sourceScheduleId, int projectId, int companyId, PredecessorInformationViewModel predecessorInformation)
        {
            PredecessorInformation predecessor = new PredecessorInformation
            {
                ScheduledItemId = predecessorInformation.ScheduledItemId,
                PredecessorId = predecessorInformation.PredecessorId,
                SourceScheuledId = sourceScheduleId,
                Lag = predecessorInformation.Lag,
                TimeFrame = predecessorInformation.TimeFrame,
                ProjectId = projectId,
                CompanyId = companyId
            };
            var predecessorObj = await _predecessorInformationRepository.CreateAsync(predecessor);
            return predecessorObj.PredecessorId;
        }

        public async Task<int> UpdatePredecessorInformationAsync(PredecessorInformationViewModel predecessorInformation)
        {
            PredecessorInformation predecessor = new PredecessorInformation
            {
                ScheduledItemId = predecessorInformation.ScheduledItemId,
                PredecessorId = predecessorInformation.PredecessorId,
                Lag = predecessorInformation.Lag,
                TimeFrame = predecessorInformation.TimeFrame,
            };
            var predecessorObj = await _predecessorInformationRepository.UpdateAsync(predecessor);
            return predecessorObj.PredecessorId;
        }

        public async Task<List<PredecessorInformationViewModel>> GetAllPredecessorInformationsAsync(int projetId)
        {
            List<PredecessorInformationViewModel> lstPredecessor = new List<PredecessorInformationViewModel>();
            var predecessorItems = await _predecessorInformationRepository.GetPredecessorByProjectId(projetId);
            predecessorItems.ToList().ForEach(a =>
            {
                lstPredecessor.Add(new PredecessorInformationViewModel
                {
                    PredecessorId = a.PredecessorId,
                    ScheduledItemId = a.ScheduledItemId,
                    Lag = a.Lag,
                    CreatdDate = a.Created_Date,
                    TimeFrame = a.TimeFrame
                });
            });
            return lstPredecessor;
        }
        public async Task<List<PredecessorInformationViewModel>> GetPredecessorInfoByScheduleIdAsync(int scheduleId)
        {
            List<PredecessorInformationViewModel> lstPredecessor = new List<PredecessorInformationViewModel>();
            var predecessorItems = await _predecessorInformationRepository.GetPredecessorByScheduledId(scheduleId);
            predecessorItems.ToList().ForEach(a =>
            {
                lstPredecessor.Add(new PredecessorInformationViewModel
                {
                    PredecessorId = a.PredecessorId,
                    ScheduledItemId = a.ScheduledItemId,
                    Lag = a.Lag,
                    CreatdDate = a.Created_Date,
                    TimeFrame = a.TimeFrame
                });
            });
            return lstPredecessor;
        }

        public async Task<int> SaveCalendarPhaseAsync(CalendarPhaseViewModel calendarPhaseModel)
        {
            CalendarPhase calendarItem = new CalendarPhase
            {
                CompanyId = calendarPhaseModel.CompanyId,
                PhaseName = calendarPhaseModel.PhaseName,
                DisplayOrder = calendarPhaseModel.DisplayOrder
            };
            var companyObj = await _calendarPhaseRepository.CreateAsync(calendarItem);
            return companyObj.PhaseId;
        }

        public async Task<List<CalendarPhaseViewModel>> GetAllPhaseAsync(int compantId, int projectId)
        {
            List<CalendarPhaseViewModel> lstCalendarModel = new List<CalendarPhaseViewModel>();
            var companyObj = await _calendarPhaseRepository.GetAllAsync();
            foreach (var item in companyObj.Where(a => a.CompanyId == compantId && a.ProjectId == projectId))
            {
                lstCalendarModel.Add(new CalendarPhaseViewModel
                {
                    PhaseId = item.PhaseId,
                    CompanyId = item.CompanyId,
                    ProjectId = item.ProjectId,
                    PhaseName = item.PhaseName
                });
            }
            return lstCalendarModel;
        }

        public async Task<int> SaveCalendarTagAsync(CalendarTagViewModel calendarTageModel)
        {
            CalendarTag calendarItem = new CalendarTag
            {
                CompanyId = calendarTageModel.CompanyId,
                ProjectId = calendarTageModel.ProjectId,
                TagName = calendarTageModel.TagName
            };
            var companyObj = await _calendarTagRepository.CreateAsync(calendarItem);
            return companyObj.TagId;
        }

        public async Task<List<CalendarTagViewModel>> GetAllTagAsync(int compantId, int projectId)
        {
            List<CalendarTagViewModel> lstCalendarModel = new List<CalendarTagViewModel>();
            var companyObj = await _calendarTagRepository.GetAllAsync();
            foreach (var item in companyObj.Where(a => a.CompanyId == compantId && a.ProjectId == projectId))
            {
                lstCalendarModel.Add(new CalendarTagViewModel
                {
                    TagId = item.TagId,
                    CompanyId = item.CompanyId,
                    ProjectId = item.ProjectId,
                    TagName = item.TagName
                });
            }
            return lstCalendarModel;
        }

        public async Task<List<PredecessorInformationViewModel>> GetPredecessorByScheduleIdAsyn(int scheduleId)
        {
            List<PredecessorInformationViewModel> lstPredessor = new List<PredecessorInformationViewModel>();
            var predessor = await _predecessorInformationRepository.GetPredecessorByScheduledId(scheduleId);
            if (predessor.Count == 0) return lstPredessor;
            predessor.ForEach(a =>
            {
                lstPredessor.Add(new PredecessorInformationViewModel
                {
                    ScheduledItemId = a.ScheduledItemId,
                    PredecessorId = a.PredecessorId,
                    TimeFrame = a.TimeFrame,
                    SourceScheuledId = a.SourceScheuledId,
                    Lag = a.Lag
                });
            });
            return lstPredessor;
        }
    }
}
