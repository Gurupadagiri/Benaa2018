using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IActivityMasterHelper
    {
        Task<ActivityMasterViewModel> SaveActivityMasterDetails(ActivityMasterViewModel activityMasterViewModel);

        Task<List<ActivityMasterViewModel>> GetAllActivityMasterDetails(string activityCode = "", int activityId = 0, int caseUpdate = 0);

        Task<List<ActivityMasterViewModel>> GetAllActivityMasterByParam(string title = "", int status = 0, string priority = "");

        Task<ActivityMasterViewModel> UpdateActivityMasterDetails(ActivityMasterViewModel activityMasterDetails);

        Task<ActivityMasterViewModel> DeleteActivityMasterDetails(string ids);

        Task<List<ActivityMasterViewModel>> GetAllActivityMasterById(int activityMasterDetailsId);
    }
}
