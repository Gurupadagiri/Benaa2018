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
        public CalendarScheduleHelper(ICalendarScheduledItemRepoisitory calendarScheduledItemRepoisitory,
            IPredecessorInformationRepository predecessorInformationRepository)
        {
            _calendarScheduledItemRepoisitory = calendarScheduledItemRepoisitory;
            _predecessorInformationRepository = predecessorInformationRepository;
        }
        public async Task<int> SaveCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem)
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
                StartTime = calendarScheuledItem.StartTime
            };
            var companyObj = await _calendarScheduledItemRepoisitory.CreateAsync(calendarItem);
            return companyObj.ScheduledItemId;
        }

        public async Task<int> UpdateCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem)
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
                StartTime = calendarScheuledItem.StartTime
            };
            var companyObj = await _calendarScheduledItemRepoisitory.UpdateAsync(calendarItem);
            return companyObj.ScheduledItemId;
        }

        public List<CalendarScheduledItemViewModel> GetAllScheduledItems(int companyId, int projetId)
        {
            List<CalendarScheduledItemViewModel> lstCalendarItems = new List<CalendarScheduledItemViewModel>();
            var scheduledItems = _calendarScheduledItemRepoisitory.GetScheduledItemByProjectId(companyId, projetId);
            scheduledItems.ToList().ForEach(a =>
            {
                lstCalendarItems.Add(new CalendarScheduledItemViewModel
                {
                    ScheduledItemId = a.ScheduledItemId,
                    Title = a.Title,
                    AssignedTo = a.AssignedTo,
                    ColorCode = a.ColorCode,
                    CreatdDate = a.Created_Date,
                    Duration = a.Duration,
                    EndDate = a.EndDate.ToString(),
                    EndTime = a.EndTime,
                    Hourly = a.Hourly,
                    Reminder = a.Reminder,                    
                    StartDate = a.StartDate.ToString(),
                    StartTime = a.StartTime,
                    CompanyId= a.CompanyId,
                    ProjectId = a.ProjectId
                });
            });
            return lstCalendarItems;
        }

        public async Task<List<CalendarScheduledItemViewModel>> GetAllScheduledItems(int companyId)
        {
            List<CalendarScheduledItemViewModel> lstCalendarItems = new List<CalendarScheduledItemViewModel>();
            var scheduledItems = await _calendarScheduledItemRepoisitory.GetAllAsync();
            scheduledItems.Where(a=>a.CompanyId == companyId).ToList().ForEach(a =>
            {
                lstCalendarItems.Add(new CalendarScheduledItemViewModel
                {
                    ScheduledItemId = a.ScheduledItemId,
                    Title = a.Title,
                    AssignedTo = a.AssignedTo,
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
                    ProjectId = a.ProjectId
                });
            });
            return lstCalendarItems;
        }

        public async Task<int> SavePredecessorInformationAsync(PredecessorInformationViewModel predecessorInformation)
        {
            PredecessorInformation predecessor = new PredecessorInformation
            {
                ScheduledItemId = predecessorInformation.ScheduledItemId,
                PredecessorId = predecessorInformation.PredecessorId,
                Lag = predecessorInformation.Lag,
                TimeFrame = predecessorInformation.TimeFrame,
                //Created_By = predecessorInformation.,
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

        public List<PredecessorInformationViewModel> GetAllPredecessorInformations(int projetId)
        {
            List<PredecessorInformationViewModel> lstPredecessor = new List<PredecessorInformationViewModel>();
            var predecessorItems = _predecessorInformationRepository.GetPredecessorByProjectId(projetId);
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
    }
}
