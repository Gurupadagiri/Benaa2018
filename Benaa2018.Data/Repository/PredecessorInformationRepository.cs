using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Benaa2018.Data.Repository
{
    public class PredecessorInformationRepository : Repository<PredecessorInformation>, IPredecessorInformationRepository
    {
        public PredecessorInformationRepository(SBSDbContext context) : base(context) { }

        public List<PredecessorInformation> GetPredecessorByProjectId(int projectId)
        {
            return _context.PredecessorInformations
                .Where(a => a.ProjectId == projectId).ToList();
        }
    }
}
