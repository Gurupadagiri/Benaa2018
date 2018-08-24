using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benaa2018.Helper.Interface
{
    public interface ICalendarScheduleHelper
    {
        Task<int> SaveCalendarScheduleItemAsync(int companyId, CalendarScheduledItemViewModel calendarScheuledItem);
        Task<int> UpdateCalendarScheduleItemAsync(int companyId, CalendarScheduledItemViewModel calendarScheuledItem);
        Task<int> SavePredecessorInformationAsync(int sourceScheduleId, int projectId, int companyId, PredecessorInformationViewModel predecessorInformation);
        Task<int> UpdatePredecessorInformationAsync(PredecessorInformationViewModel predecessorInformation);
        Task<CalendarScheduledItemViewModel> GetAllScheduledItem(int scheduledId);
        Task<List<CalendarScheduledItemViewModel>> GetAllScheduledItems(int companyId, int projectId, DateTime startDate);
        Task<int> SaveCalendarPhaseAsync(CalendarPhaseViewModel calendarPhaseModel);
        Task<List<CalendarPhaseViewModel>> GetAllPhaseAsync(int compantId, int projectId);
        Task<int> SaveCalendarTagAsync(CalendarTagViewModel calendarTageModel);
        Task<List<CalendarTagViewModel>> GetAllTagAsync(int compantId, int projectId);
        Task<List<PredecessorInformationViewModel>> GetAllPredecessorInformationsAsync(int projetId);
        Task<List<PredecessorInformationViewModel>> GetPredecessorByScheduleIdAsyn(int scheduleId);
        Task<List<PredecessorInformationViewModel>> GetPredecessorInfoByScheduleIdAsync(int scheduleId);
    }
}
