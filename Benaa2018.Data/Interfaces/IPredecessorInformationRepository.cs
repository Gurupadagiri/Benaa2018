using Benaa2018.Data.Model;
using System.Collections.Generic;

namespace Benaa2018.Data.Interfaces
{
    public interface IPredecessorInformationRepository : IRepository<PredecessorInformation>
    {
        List<PredecessorInformation> GetPredecessorByProjectId(int projectId);
    }
}
