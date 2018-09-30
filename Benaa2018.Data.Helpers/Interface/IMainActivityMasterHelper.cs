using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IMainActivityMasterHelper
    {
        Task<MainActivityMasterViewModel> SaveMainActivityMasterDetails(MainActivityMasterViewModel mainActivityMasterViewModel);

        Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterDetails(string mainActivityCode = "", int mainActivityId = 0, int caseType = 0);

        Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterByParam(string title = "", int status = 0, string priority = "");

        Task<MainActivityMasterViewModel> UpdateMainActivityMasterDetails(MainActivityMasterViewModel mainActivityMasterDetails);

        Task<MainActivityMasterViewModel> DeleteMainActivityMasterDetails(string ids);

        Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterById(int mainActivityMasterDetailsId);
    }
}
