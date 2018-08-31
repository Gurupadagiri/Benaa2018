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
    public class ToDoCheckListDetailsHelper : IToDoCheckListDetailsHelper
    {
        private readonly IToDochecklistDetailsRepository _toDchecklistDetailsHelper;

        public ToDoCheckListDetailsHelper(IToDochecklistDetailsRepository toDochecklistDetailsRepository)
        {
            _toDchecklistDetailsHelper = toDochecklistDetailsRepository;
        }

        public async Task<List<ToDochecklistDetailsViewModel>> GetAllCheclistDetailsDescription(int todoCheckListID = 0)
        {
            List<ToDochecklistDetailsViewModel> lstTagDetailsModel = new List<ToDochecklistDetailsViewModel>();
            var checkListDetailsInfo = await _toDchecklistDetailsHelper.GetAllAsync();

            if (todoCheckListID > 0)
            {

                checkListDetailsInfo = checkListDetailsInfo.Where(a => a.ToDoCheckListId == todoCheckListID).ToList();
            }
            checkListDetailsInfo.ToList().ForEach(item =>
            {
                lstTagDetailsModel.Add(new ToDochecklistDetailsViewModel
                {
                    ToDochecklistDetailsViewModelId = item.ToDochecklistDetailsId,
                    ToDoCheckListId = item.ToDoCheckListId,
                    ToDoIsCheckList = item.ToDoIsCheckList,
                    ToDoCheckListTitle = item.ToDoCheckListTitle,
                    ToDoCheckListUserType = item.ToDoCheckListUserTypeId,
                    ToDoCheckListUserId = item.ToDoCheckListUserId
                });
            });
            return lstTagDetailsModel;
        }

        public async Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            ToDochecklistDetails todoCheckDetl = new ToDochecklistDetails()
            {

                ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoCheckListUserTypeId = toDochecklistViewModel.ToDoCheckListUserType,
                ToDoCheckListUserId = toDochecklistViewModel.ToDoCheckListUserId,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today

            };
            var userObj = await _toDchecklistDetailsHelper.CreateAsync(todoCheckDetl);
            //await Task.Delay(1000);
            ToDochecklistDetailsViewModel toDoMasterDetailsViewModel = new ToDochecklistDetailsViewModel
            {
                ToDochecklistDetailsViewModelId = Convert.ToInt32(userObj.ToDochecklistDetailsId)
            };
            return toDoMasterDetailsViewModel;
        }


        public async Task<ToDochecklistDetailsViewModel> DeleteToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            ToDochecklistDetails todoCheckDetl = new ToDochecklistDetails()
            {

                ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoCheckListUserTypeId = toDochecklistViewModel.ToDoCheckListUserType,
                ToDoCheckListUserId = toDochecklistViewModel.ToDoCheckListUserId,
                DeletionStatus=true,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today

            };
            var userObj = await _toDchecklistDetailsHelper.UpdateAsync(todoCheckDetl);
            //await Task.Delay(1000);
            ToDochecklistDetailsViewModel toDoMasterDetailsViewModel = new ToDochecklistDetailsViewModel
            {
                ToDochecklistDetailsViewModelId = Convert.ToInt32(userObj.ToDochecklistDetailsId)
            };
            return toDoMasterDetailsViewModel;
        }
    }
}
