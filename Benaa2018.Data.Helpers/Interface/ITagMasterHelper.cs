using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface ITagMasterHelper
    {
        Task<TagMasterViewModel> SaveTagMasterDetails(TagMasterViewModel toDoMasterDetailsViewModel);

        Task<List<TagMasterViewModel>> GetAllTagMasterDetails();
    }
}
