using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Data.Repository
{
    public class ProjectUserIntConfigMasterRepository : Repository<ProjectUserIntConfigMaster>, IProjectUserIntConfigMasterRepository
    {
        public ProjectUserIntConfigMasterRepository(SBSDbContext context) : base(context) { }
    }
}
