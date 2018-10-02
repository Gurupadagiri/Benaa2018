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
   public  class MainActivityMasterRepository : Repository<MainActivityMaster>, IMainActivityMasterRepository
    {
        public MainActivityMasterRepository(SBSDbContext context) : base(context) { }

        public override async Task<IEnumerable<MainActivityMaster>> GetAllAsync()
        {
            var mainActivityMasters = _context.MainActivityMasters.AsNoTracking().ToList();
            return mainActivityMasters;
        }
    }
}
