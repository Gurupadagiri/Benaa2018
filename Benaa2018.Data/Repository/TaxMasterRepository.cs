using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class TaxMasterRepository : Repository<TaxMaster>,ITaxMasterRepository
    {
        public TaxMasterRepository(SBSDbContext context) : base(context) { }


        public async Task<List<TaxMaster>> GetListByTaxMasterId(int projectID)
        {
            return await Task.Factory.StartNew(() => _context.TaxMasters.Where(a => a.Tax_ID== projectID).ToList());
        }

    }
}
