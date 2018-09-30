using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface ICostCodeHelper
    {
        Task<int> SaveCostCodeDetails(CostCodeViewModel costCodeViewModel);

        Task<List<CostCodeViewModel>> GetCostCodeDetails();


        Task<CostCodeViewModel> UpdateCostCodeDetails(CostCodeViewModel costCodeViewModel);

        Task<CostCodeViewModel> DeleteCostCodeDetails(string ids);
    }
}
