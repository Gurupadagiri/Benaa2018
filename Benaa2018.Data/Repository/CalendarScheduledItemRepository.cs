using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class CalendarScheduledItemRepository : Repository<CalendarScheduledItem>, ICalendarScheduledItemRepoisitory
    {
        public CalendarScheduledItemRepository(SBSDbContext context) : base(context) { }

        public async Task<List<CalendarScheduledItem>> GetScheduledItemByProjectId(int companyId, int projectId)
        {
            return _context.CalendarScheduledItems
                .Where(a => a.CompanyId == companyId && a.ProjectId == projectId).ToList();
        }

        public async Task<CalendarScheduledItem> GetScheduledItemByScheduleIdAsync(int scheduleId)
        {
            return _context.CalendarScheduledItems
                .Where(a => a.ScheduledItemId == scheduleId).FirstOrDefault();
        }
    }
}
