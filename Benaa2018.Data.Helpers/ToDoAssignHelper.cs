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
               // ToDoAssignID = toDoAssignViewModel.ToDoAssignID,
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


        public async Task<ToDoAssignViewModel> SaveToDoAssignDetails1(int userId,int toDoDetailsId, int userTypeId=0)
        {
            ToDoAssign toDoAssign = new ToDoAssign
            {
                // ToDoAssignID = toDoAssignViewModel.ToDoAssignID,
                UserID = userId,
                TodoDetailsID = toDoDetailsId,
                ToDoUserAssignTypeId = userTypeId
            };
            var toAssignObj = await _toDoAssignHelper.CreateAsync(toDoAssign);
            ToDoAssignViewModel toDoAssignDetl = new ToDoAssignViewModel
            {
                ToDoAssignID = Convert.ToInt32(toAssignObj.ToDoAssignID)
            };

            return toDoAssignDetl;
        }
        public async Task<List<ToDoAssignViewModel>> GetToDoAssignByToDoDetailsId(int todoDetailsId)
        {

            List<ToDoAssignViewModel> lstToDoAssignViewModel = new List<ToDoAssignViewModel>();
            var toDoAssignByDetailsId= await _toDoAssignHelper.GetAllAsync();
            toDoAssignByDetailsId = toDoAssignByDetailsId.Where(a => a.TodoDetailsID == todoDetailsId).ToList();
            if (toDoAssignByDetailsId.Count() > 0)
            {
                toDoAssignByDetailsId.ToList().ForEach(item =>
                {
                    lstToDoAssignViewModel.Add(new ToDoAssignViewModel
                    {
                        UserID=item.UserID,
                        ToDoUserAssignTypeId=item.ToDoUserAssignTypeId,
                        TodoDetailsID=item.TodoDetailsID
                    });
                });
            }
            return lstToDoAssignViewModel;

        }

        public async Task<ToDoAssignViewModel> DeleteToDoAssignDetails(ToDoAssignViewModel toDoAssignViewModel)
        {
            ToDoAssign toDoAssign = new ToDoAssign
            {
                ToDoAssignID = toDoAssignViewModel.ToDoAssignID,
                UserID = toDoAssignViewModel.UserID,
                TodoDetailsID = toDoAssignViewModel.TodoDetailsID,
                ToDoUserAssignTypeId = toDoAssignViewModel.ToDoUserAssignTypeId,
                DeletionStatus=true,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var toAssignObj = await _toDoAssignHelper.UpdateAsync(toDoAssign);
            ToDoAssignViewModel toDoAssignDetl = new ToDoAssignViewModel
            {
                ToDoAssignID = Convert.ToInt32(toAssignObj.ToDoAssignID)
            };

            return toDoAssignDetl;
        }
    }
}
