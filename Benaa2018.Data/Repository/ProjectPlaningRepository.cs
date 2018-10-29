using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class ProjectPlaningRepository : Repository<ProjectPlaning>, IProjectPlaningRepository
    {
        public ProjectPlaningRepository(SBSDbContext context) : base(context) { }

        public async Task<List<ProjectPlaning>> GetMainActivityByProjectID(int projectID)
        {
            return await Task.Factory.StartNew(() => _context.ProjectPlanings.Where(a => a.Project_ID == projectID).ToList());
        }
    }
}
