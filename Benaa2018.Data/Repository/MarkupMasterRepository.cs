using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Benaa2018.Data.Repository
{
   public class MarkupMasterRepository : Repository<MarkupMaster>, IMarkupMasterRepository
    {
        public MarkupMasterRepository(SBSDbContext context) : base(context) { }

       public async Task<List<MarkupMaster>> GetListByMarkupId(int orgID)
        {
            return await Task.Factory.StartNew(() => _context.MarkupMasters.Where(a => a.Orgid == orgID).ToList());
        }
    }
}
