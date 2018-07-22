using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Helper.Model;

namespace Benaa2018.Helper
{
    public interface IProjectMasterHelper
    {
        Task<List<ProjectMasterViewModel>> FilterProjectInfo(string[] projectGroupIds, string[] managersIds);
        Task<List<ProjectMasterViewModel>> FilterProjectResults(string[] projectGroups, string[] projectManagers, string[] status, string[] projectTypes, string searchKeyWord, string[] mappedStatus, string searchText);
        Task<List<ProjectMasterViewModel>> GetAllProjectByUserId(int userId);
        Task<string> GetNameByProjectId(int projectId);
        Task<ProjectMasterViewModel> GetProjectDetailsProjectId(int projectId);
        Task<int> SaveProjectMaster(int userId, ProjectMasterViewModel projectMasterModel);
        Task<int> UpdateProjectMaster(int userID, ProjectMasterViewModel projectMasterModel);
        Task<List<ProjectManagerMasterViewModel>> GetAllManagers();
        Task<List<ProjectTypeMasterViewModel>> GetAllProjectType();
        List<ProjectGridModel> BindProjectGrid(List<ProjectMasterViewModel> ProjectMasterModels, List<ProjectManagerMasterViewModel> ProjectManagerMasterModels);
    }
}