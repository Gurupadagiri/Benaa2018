using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoMasterDetailsHelper
    {
        Task<ToDoMasterDetailsViewModel> SaveToDoMasterDetails(ToDoMasterDetailsViewModel toDoMasterDetailsViewModel);

        Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetails();

        Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsByTitle(string title = "", int status=0, string priority = "");

        Task<ToDoMasterDetailsViewModel> UpdateToDoMasterDetails(string ids);

        Task<ToDoMasterDetailsViewModel> DeleteToDoMasterDetails(string ids);

    }
}
