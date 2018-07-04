using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface IProjectStatusMasterHelper
    {
        Task<List<ProjctStatusMasterViewModel>> GetAllProjectStatus();
    }
}