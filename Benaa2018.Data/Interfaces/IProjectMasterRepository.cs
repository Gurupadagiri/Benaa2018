using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Interfaces
{
    public interface IProjectMasterRepository : IRepository<ProjectMaster>
    {
        Task<List<ProjectMaster>> GetProjectByUserID(int userID);
    }
}
