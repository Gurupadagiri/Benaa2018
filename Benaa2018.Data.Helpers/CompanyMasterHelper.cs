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
            return new CompanyMasterViewModel
            {
                CompanyName = companyObj.Company_Name,
                Org_ID = companyObj.Org_ID,
                IsActive = companyObj.IsActive,
                Latitude = companyObj.Latitude,
                Longitude = companyObj.Longitude
            };
        }

        //public CompanyMasterViewModel GetCompanyByID(int CompanyId)
        //{
        //    var companyObj = _companyMasterRespository.GetByIdAsync(CompanyId);
        //    return new CompanyMasterViewModel
        //    {
        //        CompanyName = companyObj.Result.Company_Name,
        //        Org_ID = companyObj.Result.Org_ID,
        //        IsActive = companyObj.Result.IsActive,
        //        Latitude = companyObj.Result.Latitude,
        //        Longitude = companyObj.Result.Longitude
        //    };
        //}
    }
}
