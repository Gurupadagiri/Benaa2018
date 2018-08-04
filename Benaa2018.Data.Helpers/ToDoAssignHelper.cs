using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ToDoAssignHelper : IToDoAssignHelper
    {
        private readonly IToDoAssignRepository _toDoAssignHelper;

        public ToDoAssignHelper(IToDoAssignRepository toDoAssignRepository)
        {
            _toDoAssignHelper = toDoAssignRepository;
        }
        public async Task<ToDoAssignViewModel> SaveToDoAssignDetails(ToDoAssignViewModel toDoAssignViewModel)
        {
            ToDoAssign toDoAssign = new ToDoAssign
            {
                ToDoAssignID = toDoAssignViewModel.ToDoAssignID,
                UserID = toDoAssignViewModel.UserID,
                TodoDetailsID = toDoAssignViewModel.TodoDetailsID,
                ToDoUserAssignTypeId = toDoAssignViewModel.ToDoUserAssignTypeId
            };
            var toAssignObj = await _toDoAssignHelper.CreateAsync(toDoAssign);
            ToDoAssignViewModel toDoAssignDetl = new ToDoAssignViewModel
            {
                ToDoAssignID = Convert.ToInt32(toAssignObj.ToDoAssignID)
            };

            return toDoAssignDetl;
        }
    }
}
