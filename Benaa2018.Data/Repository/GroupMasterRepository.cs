using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class GroupMasterRepository : Repository<GroupMaster>, IGroupMasterRepository
    {
        public GroupMasterRepository(SBSDbContext context) : base(context) { }

        public override async Task<IEnumerable<GroupMaster>> GetAllAsync()
        {
            var groupMasters = _context.GroupMasters.AsNoTracking().ToList();
            //_context.Entry(new List<GroupMaster>()).State = EntityState.Detached;

            return groupMasters;
        }
    }
}
