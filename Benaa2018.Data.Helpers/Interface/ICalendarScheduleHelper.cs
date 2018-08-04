using Benaa2018.Helper.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benaa2018.Helper.Interface
{
    public interface ICalendarScheduleHelper
    {
        Task<int> SaveCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem);
        Task<int> UpdateCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem);
        Task<int> SavePredecessorInformationAsync(PredecessorInformationViewModel predecessorInformation);
        Task<int> UpdatePredecessorInformationAsync(PredecessorInformationViewModel predecessorInformation);
        Task<List<CalendarScheduledItemViewModel>> GetAllScheduledItems(int companyId);
    }
}
