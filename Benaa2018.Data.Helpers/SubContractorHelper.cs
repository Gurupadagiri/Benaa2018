using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
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
            subContractors.Where(a => a.Org_ID == OrgId).ToList().ForEach(item =>
            {
                lstSubContractor.Add(new ProjectSubcontractorConfigViewModel
                {
                    SubContractorID = item.SubContractor_ID,
                    SubcontractorName = item.Name
                });
            });
            return lstSubContractor;
        }

        public async Task<List<ProjectSubcontractorMasterViewModel>> GetAllSubContractorsByCompanyId(int OrgId)
        {
            List<ProjectSubcontractorMasterViewModel> lstSubContractor = new List<ProjectSubcontractorMasterViewModel>();
            var subContractors = await _subContractorMasterRepository.GetAllAsync();
            subContractors.Where(a => a.Org_ID == OrgId).ToList().ForEach(item =>
            {
                lstSubContractor.Add(new ProjectSubcontractorMasterViewModel
                {
                    SubContractorID = item.SubContractor_ID,
                    Address = item.Address,
                    Beneficiary = item.Beneficiary,
                    CatogeryID = item.Catogery_ID,
                    ContactPersion = item.Contact_Persion,
                    CountryID = item.Country_ID,
                    CRNO = item.CR_NO,
                    Email = item.Email,
                    Fax = item.Fax,
                    Mobile = item.Mobile,
                    Name = item.Name,
                    OrgID = item.Org_ID,
                    Tel = item.Tel
                });
            });
            return lstSubContractor;
        }
    }
}
