using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Data.Interfaces
{
    public interface ICalendarScheduledItemRepoisitory : IRepository<CalendarScheduledItem>
    {
        Task<List<CalendarScheduledItem>> GetScheduledItemByProjectId(int companyId, int projectId);
        Task<CalendarScheduledItem> GetScheduledItemByScheduleIdAsync(int scheduleId);
    }
}
