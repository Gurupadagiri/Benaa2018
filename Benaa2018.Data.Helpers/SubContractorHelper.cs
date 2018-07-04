using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class SubContractorHelper : ISubContractorHelper
    {
        private readonly ISubContractorMasterRepository _subContractorMasterRepository;
        public SubContractorHelper(ISubContractorMasterRepository subContractorMasterRepository)
        {
            _subContractorMasterRepository = subContractorMasterRepository;
        }

        public async Task<List<ProjectSubcontractorConfigViewModel>> GetAllSubContractorByOrg(int OrgId)
        {
            List<ProjectSubcontractorConfigViewModel> lstSubContractor = new List<ProjectSubcontractorConfigViewModel>();
            var subContractors = await _subContractorMasterRepository.GetAllAsync();
            subContractors.Where(a => a.Org_ID == OrgId).ToList().ForEach(item => {
                lstSubContractor.Add(new ProjectSubcontractorConfigViewModel
                {
                    SubContractorID = item.SubContractor_ID,
                    SubcontractorName = item.Name
                });
            });
            return lstSubContractor;
        }
    }
}
