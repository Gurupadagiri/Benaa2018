using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface ISubContractorHelper
    {
        Task<List<ProjectSubcontractorConfigViewModel>> GetAllSubContractorByOrg(int OrgId=0);

        Task<List<ProjectSubcontractorMasterViewModel>> GetAllSubContractorsByCompanyId(int OrgId);

        Task<ProjectSubcontractorMasterViewModel> GetSubContractorBySubcontractId(int ownerId);
    }
}