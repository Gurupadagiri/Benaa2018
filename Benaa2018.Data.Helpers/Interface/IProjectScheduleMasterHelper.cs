using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface IProjectScheduleMasterHelper
    {
        Task<List<ProjectScheduleMasterViewModel>> GetAllSchedules();
        Task<ProjectScheduleMasterViewModel> GetProjectScheduleByProjectID(int projectId);
        Task SaveProjectSchedules(int userId, int projectMasterId, ProjectScheduleMasterViewModel projectScheduleMasterModel);
        Task UpdateProjectSchedules(int userId, int projectMasterId, ProjectScheduleMasterViewModel projectScheduleMasterModel);
    }
}