using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;

namespace Benaa2018.Data.Repository
{
    public class ProjectStatusMasterRepository : Repository<ProjectStatusMaster>, IProjectStatusMasterRepository
    {
        public ProjectStatusMasterRepository(SBSDbContext context) : base(context) { }
    }
}
