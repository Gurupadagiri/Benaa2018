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

        public Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
