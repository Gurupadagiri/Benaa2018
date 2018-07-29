using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Data.Interfaces
{
    public interface ICalendarScheduledItemRepoisitory : IRepository<CalendarScheduledItem>
    {
        List<CalendarScheduledItem> GetScheduledItemByProjectId(int companyId, int projectId);
    }
}
