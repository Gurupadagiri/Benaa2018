using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
   public class UnitMasterRepository : Repository<UnitMaster>, IUnitMasterRepository
    {
        public UnitMasterRepository(SBSDbContext context) : base(context) { }



        public async Task<List<UnitMaster>> GetListByUnitID(int OrganizationID)
        {
            return await Task.Factory.StartNew(() => _context.UnitMasters.Where(a => a.Orgid == OrganizationID).ToList());
        }
    }
}
