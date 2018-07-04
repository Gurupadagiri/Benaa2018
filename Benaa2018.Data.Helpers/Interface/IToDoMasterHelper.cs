using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper
{
    public interface IToDoMasterHelper
    {
        Task<List<ToDoMasterViewModel>> GetAllToDoList();
        Task<List<ToDoMasterViewModel>> GetFilteredToDoList(int days);
        Task<List<ToDoMasterViewModel>> GetToDoListByProjectID(int projectID);
    }
}