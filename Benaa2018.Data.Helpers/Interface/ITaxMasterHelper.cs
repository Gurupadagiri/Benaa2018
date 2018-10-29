using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface ITaxMasterHelper
    {
        Task<List<TaxMasterViewModel>> GetAllRecords(int projectId = 0);
        //Task<UserMasterViewModel> GetUserByUserId(int userId);
        //Task<List<UserMasterViewModel>> GetUserByUserName(string userName);
        //Task SaveUserMaterConfig(int orgId, int projectID, List<UserMasterViewModel> lstUserMasterModel);
        //Task UpdateUserMaterConfig(int projectID, List<UserMasterViewModel> lstUserMasterModel);
        //Task<ProjectBoqBudgetMasterViewModel> SavePorjectBOQMaster(ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel);
        //Task<List<UserMasterViewModel>> GetInternalUserByName(int companyId, string name, string status);
        //Task<List<UserMasterViewModel>> GetFullUserName();
    }
}
