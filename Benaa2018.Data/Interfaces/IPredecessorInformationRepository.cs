using Benaa2018.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benaa2018.Data.Interfaces
{
    public interface IPredecessorInformationRepository : IRepository<PredecessorInformation>
    {
        Task<List<PredecessorInformation>> GetPredecessorByProjectId(int projectId);
        Task<List<PredecessorInformation>> GetPredecessorByScheduledId(int scheduledId);
    }
}
