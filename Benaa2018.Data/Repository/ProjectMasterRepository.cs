using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class ProjectMasterRepository : Repository<ProjectMaster>, IProjectMasterRepository
    {
        public ProjectMasterRepository(SBSDbContext context) : base(context) { }

        public async Task<List<ProjectMaster>> GetProjectByUserID(int userID)
        {
            return await Task.Factory.StartNew(() => _context.ProjectMasters.Where(a => a.User_ID == userID).ToList());
        }
    }
}
