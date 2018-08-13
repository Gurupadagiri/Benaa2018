using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class PredecessorInformationRepository : Repository<PredecessorInformation>, IPredecessorInformationRepository
    {
        public PredecessorInformationRepository(SBSDbContext context) : base(context) { }

        public async Task<List<PredecessorInformation>> GetPredecessorByProjectId(int projectId)
        {
            return _context.PredecessorInformations.Where(a => a.ProjectId == projectId).ToList();
        }

        public async Task<List<PredecessorInformation>> GetPredecessorByScheduledId(int scheduledId)
        {
            return _context.PredecessorInformations.Where(a => a.SourceScheuledId == scheduledId).ToList();
        }
    }
}
