using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Benaa2018.Data.Interfaces
{
   public interface IUnitMasterRepository : IRepository<UnitMaster>
    {
        Task<List<UnitMaster>> GetListByUnitID(int projectID);

    }
}
