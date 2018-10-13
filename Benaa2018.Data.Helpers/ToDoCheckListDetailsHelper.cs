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
                    ToDoCheckListUserId = item.ToDoCheckListUserId.Split(",")
                });
            });
            return lstTagDetailsModel;
        }

        public async Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel,int todoCheckListID=0)
        {
            ToDochecklistDetails todoCheckDetl = new ToDochecklistDetails()
            {

                ToDoCheckListId = todoCheckListID,
                ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoCheckListUserTypeId = toDochecklistViewModel.ToDoCheckListUserType,
                ToDoCheckListUserId = toDochecklistViewModel.ToDoCheckListUserId == null ? string.Empty : string.Join(",", toDochecklistViewModel.ToDoCheckListUserId)
            };
            var userObj = await _toDchecklistDetailsHelper.CreateAsync(todoCheckDetl);
            ToDochecklistDetailsViewModel toDoMasterDetailsViewModel = new ToDochecklistDetailsViewModel
            {
                ToDochecklistDetailsViewModelId = Convert.ToInt32(userObj.ToDochecklistDetailsId)
            };
            return toDoMasterDetailsViewModel;
        }


        public async Task DeleteToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            ToDochecklistDetails todoCheckDetl = new ToDochecklistDetails()
            {

                ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoCheckListUserTypeId = toDochecklistViewModel.ToDoCheckListUserType,
                DeletionStatus = true,
                ToDoCheckListUserId = string.Join(",", toDochecklistViewModel.ToDoCheckListUserId)
            };
            await _toDchecklistDetailsHelper.DeleteAsync(todoCheckDetl);
        }

        public async Task<ToDochecklistDetailsViewModel> UpdateToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            ToDochecklistDetails todoCheckDetl = new ToDochecklistDetails()
            {

                ToDoCheckListId = toDochecklistViewModel.ToDoCheckListId,
                ToDoIsCheckList = toDochecklistViewModel.ToDoIsCheckList,
                ToDoCheckListTitle = toDochecklistViewModel.ToDoCheckListTitle,
                ToDoCheckListUserTypeId = toDochecklistViewModel.ToDoCheckListUserType,
                ToDoCheckListUserId = toDochecklistViewModel.ToDoCheckListUserId == null ? string.Empty : string.Join(",", toDochecklistViewModel.ToDoCheckListUserId)
            };
            var userObj = await _toDchecklistDetailsHelper.UpdateAsync(todoCheckDetl);
            ToDochecklistDetailsViewModel toDoMasterDetailsViewModel = new ToDochecklistDetailsViewModel
            {
                ToDochecklistDetailsViewModelId = Convert.ToInt32(userObj.ToDochecklistDetailsId)
            };
            return toDoMasterDetailsViewModel;
        }
    }
}
