using Benaa2018.Helper.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public interface IProjectGroupHelper
    {
        Task<int> SaveProjectGroup(int userId, string projectGroupName);
        Task<List<ProjectGroupViewModel>> GetProjectGroupByUserID(int userID);
    }
}