using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface IProjectBoqBudgetMasterHelper
    {
        Task<List<ProjectBoqBudgetMasterViewModel>> GetAllRecords();
        Task<ProjectBoqBudgetMasterViewModel> GetBoqListByActivityId(int activityId);
        //Task<List<UserMasterViewModel>> GetUserByUserName(string userName);
        //Task SaveUserMaterConfig(int orgId, int projectID, List<UserMasterViewModel> lstUserMasterModel);
        Task<bool> UpdateProjectBoqBudgetConfig(ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel);
        Task<bool> DeleteProjectBoqBudgetByProjectBoqId(int projectBoqId);
        Task<ProjectBoqBudgetMasterViewModel> SavePorjectBOQMaster(ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel);
        //Task<List<UserMasterViewModel>> GetInternalUserByName(int companyId, string name, string status);
        //Task<List<UserMasterViewModel>> GetFullUserName();
    }
}
