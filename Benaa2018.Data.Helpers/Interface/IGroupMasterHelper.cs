using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IGroupMasterHelper
    {
        Task<GroupMasterViewModel> SaveGroupMasterViewModelDetails(GroupMasterViewModel mainActivityMasterViewModel);

        Task<List<GroupMasterViewModel>> GetGroupMasterViewModelDetails(string groupCode = "", int caseStat = 0);

        Task<List<GroupMasterViewModel>> GetGroupMasterViewModelByParam(string title = "", int status = 0, string priority = "");

        Task<GroupMasterViewModel> UpdateGroupMasterViewModelDetails(GroupMasterViewModel grpMasterViewModel);

        Task<GroupMasterViewModel> DeleteGroupMasterViewModelDetails(string ids);

        Task<List<GroupMasterViewModel>> GetGroupMasterViewModelById(int groupMasterDetailsId);
    }
}
