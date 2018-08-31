using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoAssignHelper
    {
        Task<ToDoAssignViewModel> SaveToDoAssignDetails(ToDoAssignViewModel toDoAssignViewModel);

        Task<ToDoAssignViewModel> SaveToDoAssignDetails1(int userId, int toDoDetailsId, int userTypeId = 0);
        Task<List<ToDoAssignViewModel>> GetToDoAssignByToDoDetailsId(int todoDetailsId);
        Task<ToDoAssignViewModel> DeleteToDoAssignDetails(ToDoAssignViewModel toDoAssignViewModel);
    }
}
