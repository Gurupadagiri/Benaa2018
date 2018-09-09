using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Helper.Model;

namespace Benaa2018.Helper
{
    public interface IProjectMasterHelper
    {
        Task<List<ProjectMasterViewModel>> FilterProjectInfo(string[] projectGroupIds, string[] managersIds);
        Task<List<ProjectMasterViewModel>> FilterProjectResults(int compantId,string[] projectGroups, string[] projectManagers, string[] status, string[] projectTypes, string searchKeyWord, string startDate, string endDate);
        Task<List<ProjectMasterViewModel>> GetAllProjectByUserId(int userId);
        Task<string> GetNameByProjectId(int projectId);
        Task<ProjectMasterViewModel> GetProjectDetailsProjectId(int projectId);
        Task<int> SaveProjectMaster(int userId, int companyid, ProjectMasterViewModel projectMasterModel);
        Task<int> UpdateProjectMaster(int userID, int companyid, ProjectMasterViewModel projectMasterModel);
        Task<List<ProjectManagerMasterViewModel>> GetAllManagers();
        Task<List<ProjectTypeMasterViewModel>> GetAllProjectType();
        List<ProjectGridModel> BindProjectGrid(List<ProjectMasterViewModel> ProjectMasterModels, List<ProjectManagerMasterViewModel> ProjectManagerMasterModels);
    }
}