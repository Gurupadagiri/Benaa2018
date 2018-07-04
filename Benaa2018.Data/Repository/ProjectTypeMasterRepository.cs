using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;

namespace Benaa2018.Data.Repository
{
    public class ProjectTypeMasterRepository : Repository<ProjectTypeMaster>, IProjectTypeMasterRepository
    {
        public ProjectTypeMasterRepository(SBSDbContext context) : base(context) { }
    }
}
