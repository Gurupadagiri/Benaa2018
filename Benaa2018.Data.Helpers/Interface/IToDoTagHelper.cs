using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoTagHelper
    {
        Task<ToDoTagViewModel> SaveToDoTagDetails(ToDoTagViewModel toDoTagViewModel);

        Task<List<ToDoTagViewModel>> GetAllTags(int TodoDetailID = 0);

        Task<ToDoTagViewModel> DeleteToDoTagDetails(ToDoTagViewModel toDoTagViewModel);
    }
}
