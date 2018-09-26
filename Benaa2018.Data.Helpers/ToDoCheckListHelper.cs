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
    public class ToDoCheckListHelper : IToDoCheckListHelper
    {
        private readonly IToDochecklistRepository _toDchecklistHelper;

        public ToDoCheckListHelper(IToDochecklistRepository toDochecklistRepository)
        {
            _toDchecklistHelper = toDochecklistRepository;
        }

        public async Task<ToDochecklistViewModel> SaveToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel)
        {
            ToDochecklist todoCheckList = new ToDochecklist
            {
                //ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                TodoDetailsID = toDochecklistViewModel.TodoDetailsID,
                //ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                //ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoAssignIsCheckListItem = toDochecklistViewModel.ToDoAssignIsCheckListItem,
                ToDoAssignIFilesCheckListItem = toDochecklistViewModel.ToDoAssignIFilesCheckListItem,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };

            var CheckLsitObj = await _toDchecklistHelper.CreateAsync(todoCheckList);
            ToDochecklistViewModel toDoCheckLst = new ToDochecklistViewModel
            {
                ToDoCheckListId = Convert.ToInt32(CheckLsitObj.ToDoCheckListId)
            };

            return toDoCheckLst;
        }

        public async Task<List<ToDochecklistViewModel>> GetAllCheclistDetails(int todoDetailsID = 0)
        {
            List<ToDochecklistViewModel> lstTagCheckListModel = new List<ToDochecklistViewModel>();
            var checkListInfo = await _toDchecklistHelper.GetAllAsync();
            if (todoDetailsID != 0)
            {

                checkListInfo = checkListInfo.Where(a => a.TodoDetailsID == todoDetailsID).ToList();
            }
            checkListInfo.ToList().ForEach(item =>
            {
                lstTagCheckListModel.Add(new ToDochecklistViewModel
                {
                    ToDoCheckListId = item.ToDoCheckListId,
                    TodoDetailsID = item.TodoDetailsID,
                    //ToDoIsCheckList = item.ToDoIsCheckList,
                    //ToDoCheckListTitle = item.ToDoCheckListTitle,
                    ToDoAssignIsCheckListItem = item.ToDoAssignIsCheckListItem,
                    ToDoAssignIFilesCheckListItem = item.ToDoAssignIFilesCheckListItem
                });
            });
            return lstTagCheckListModel;
        }


        public async Task<ToDochecklistViewModel> DeleteToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel)
        {
            ToDochecklist todoCheckList = new ToDochecklist
            {
                ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                TodoDetailsID = toDochecklistViewModel.TodoDetailsID,
                ToDoAssignIsCheckListItem = toDochecklistViewModel.ToDoAssignIsCheckListItem,
                ToDoAssignIFilesCheckListItem = toDochecklistViewModel.ToDoAssignIFilesCheckListItem,
                DeletionStatus=true,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };

            var CheckLsitObj = await _toDchecklistHelper.UpdateAsync(todoCheckList);
            ToDochecklistViewModel toDoCheckLst = new ToDochecklistViewModel
            {
                ToDoCheckListId = Convert.ToInt32(CheckLsitObj.ToDoCheckListId)
            };

            return toDoCheckLst;
        }
    }
}
