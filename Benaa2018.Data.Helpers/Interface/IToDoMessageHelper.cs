using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoMessageHelper
    {
        Task<ToDoMessageViewModel> SaveToDoMessage(ToDoMessageViewModel toDoMessageViewModel);

        Task<List<ToDoMessageViewModel>> GetAllToDoMessage();

        Task<List<ToDoMessageViewModel>> GetAllToDoMessageDetailsByTitle(string title = "", int status = 0, string priority = "");

        Task<ToDoMessageViewModel> UpdateToDoMessageDetails(ToDoMessageViewModel toDoMasterDetails);

        Task<ToDoMessageViewModel> DeleteToDoMessageDetails(string ids);

        Task<List<ToDoMessageViewModel>> GetAllToDoMessageDetailsById(int todoDetailsId);
    }
}
