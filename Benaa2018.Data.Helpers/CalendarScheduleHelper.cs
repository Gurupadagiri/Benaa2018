using Benaa2018.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Benaa2018.Helper.ViewModels;
using System.Threading.Tasks;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;

namespace Benaa2018.Helper
{
    public class CalendarScheduleHelper : ICalendarScheduleHelper
    {
        private readonly ICalendarScheduledItemRepoisitory _calendarScheduledItemRepoisitory;
        public CalendarScheduleHelper(ICalendarScheduledItemRepoisitory calendarScheduledItemRepoisitory)
        {
            _calendarScheduledItemRepoisitory = calendarScheduledItemRepoisitory;
        }
        public async Task<int> SaveCalendarScheduleItemAsync(CalendarScheduledItemViewModel calendarScheuledItem)
        {
            CalendarScheduledItem calendarItem = new CalendarScheduledItem
            {
                ScheduledItemId = calendarScheuledItem.ScheduledItemId,
                Title= calendarScheuledItem.Title,
                AssignedTo= calendarScheuledItem.AssignedTo,
                ColorCode= calendarScheuledItem.ColorCode,
                Duration= calendarScheuledItem.Duration,
                EndDate= calendarScheuledItem.EndDate,
                EndTime= calendarScheuledItem.EndTime,
                Hourly= calendarScheuledItem.Hourly,
                Reminder= calendarScheuledItem.Reminder,
                StartDate= calendarScheuledItem.StartDate,
                StartTime= calendarScheuledItem.StartTime
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
                EndDate = calendarScheuledItem.EndDate,
                EndTime = calendarScheuledItem.EndTime,
                Hourly = calendarScheuledItem.Hourly,
                Reminder = calendarScheuledItem.Reminder,
                StartDate = calendarScheuledItem.StartDate,
                StartTime = calendarScheuledItem.StartTime
            };
            var companyObj = await _calendarScheduledItemRepoisitory.UpdateAsync(calendarItem);
            return companyObj.ScheduledItemId;
        }
    }
}
