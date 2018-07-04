using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface IOwnerMasterHelper
    {
        Task<OwnerMasterViewModel> GetOwnerInfoByInfo(int projectID);
        Task<int> SaveOwnerMasterAsync(int projectID, OwnerMasterViewModel OwnerMasterModel);
        Task<int> UpdateOwnerMaster(int projectID, OwnerMasterViewModel OwnerMasterModel);
    }
}