using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper.Interface
{
    public interface ICostCategoryHelper
    {
        Task<int> SaveCostCategoryDetails(CostCategoryViewModel costCodeViewModel);

        Task<List<CostCategoryViewModel>> GetCostCategoryDetails();


        Task<CostCategoryViewModel> UpdateCostCategoryDetails(CostCategoryViewModel costCodeViewModel);

        Task<CostCategoryViewModel> DeleteCostCategoryDetails(string ids);
    }
}
