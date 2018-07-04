using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;

namespace Benaa2018.Data.Repository
{
    public class ProjectScheduleMasterRepository : 
        Repository<ProjectScheduleMaster>, IProjectScheduleMasterRepository
    {
        public ProjectScheduleMasterRepository(SBSDbContext context) : base(context) { }

        public async Task<ProjectScheduleMaster> GetProjectSheduleByProjectIdAsync(int projectID)
        {
            return await Task.Factory.StartNew(() => _context.ProjectScheduleMasters.Where(a => a.Project_ID == projectID).FirstOrDefault());
        }
    }
}
