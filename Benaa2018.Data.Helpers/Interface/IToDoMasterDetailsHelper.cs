using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoMasterDetailsHelper
    {
        Task<ToDoMasterDetailsViewModel> SaveToDoMasterDetails(ToDoMasterDetailsViewModel toDoMasterDetailsViewModel);

        Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetails(int projectId = 0);

        Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsByTitle(int projectId = 0,string title = "", int status=0, string priority = "");

        Task<ToDoMasterDetailsViewModel> UpdateToDoMasterDetails(ToDoMasterDetailsViewModel toDoMasterDetails);

        Task<ToDoMasterDetailsViewModel> DeleteToDoMasterDetails(string ids);

        Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsById(int todoDetailsId);

    }
}
