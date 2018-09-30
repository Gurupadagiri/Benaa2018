using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IVarianceMasterHelper
    {
        Task<VarianceMasterViewModel> SaveVarianceMasterDetails(VarianceMasterViewModel activityMasterViewModel);

        Task<List<VarianceMasterViewModel>> GetAllVarianceMasterDetails(string varianceCode = "", int varianceId = 0, int caseUpdate = 0);

        Task<VarianceMasterViewModel> UpdateActivityMasterDetails(VarianceMasterViewModel activityMasterDetails);

        Task<VarianceMasterViewModel> DeleteActivityMasterDetails(VarianceMasterViewModel varianceMasterViewModel);

    }
}
