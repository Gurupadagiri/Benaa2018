using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper.Interface
{
    public interface ICalendarScheduleHelper
    {
        Task<int> SaveCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem);
        Task<int> UpdateCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem);
    }
}
