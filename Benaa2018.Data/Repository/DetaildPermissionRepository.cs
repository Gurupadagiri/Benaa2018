using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class DetaildPermissionRepository : Repository<DetaildPermission>, IDetaildPermissionRepository
    
    {
        public DetaildPermissionRepository(SBSDbContext context) : base(context) { }
    }
}
