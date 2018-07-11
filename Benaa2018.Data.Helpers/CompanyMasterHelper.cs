using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class CompanyMasterHelper : ICompanyMasterHelper
    {
        private readonly ICompanyMasterRespository _companyMasterRespository;
        public CompanyMasterHelper(ICompanyMasterRespository companyMasterRespository)
        {
            _companyMasterRespository = companyMasterRespository;
        }

        public async Task<CompanyMasterViewModel> GetCompanyByID(int CompanyId)
        {
            var companyObj = await _companyMasterRespository.GetByIdAsync(CompanyId);
            if (companyObj == null) return new CompanyMasterViewModel();
            return new CompanyMasterViewModel
            {
                CompanyName = companyObj?.Company_Name,
                Org_ID = companyObj.Org_ID,
                IsActive = companyObj.IsActive,
                Latitude = companyObj?.Latitude,
                Longitude = companyObj?.Longitude
            };
        }
    }
}
