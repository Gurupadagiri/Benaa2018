using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public interface ICompanyMasterHelper
    {
        Task<CompanyMasterViewModel> GetCompanyByID(int CompanyId);
    }
}
