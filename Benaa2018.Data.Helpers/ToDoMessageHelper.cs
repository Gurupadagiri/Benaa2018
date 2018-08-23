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
    public class ToDoMessageHelper : IToDoMessageHelper
    {
        private readonly IToDoMessageRepository _toDoMessageHelper;

        public ToDoMessageHelper(IToDoMessageRepository toDoMessageRepository)
        {
            _toDoMessageHelper = toDoMessageRepository;
        }

        public Task<ToDoMessageViewModel> DeleteToDoMessageDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoMessageViewModel>> GetAllToDoMessage()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDoMessageViewModel>> GetAllToDoMessageDetailsById(int todoDetailsId)
        {
            List<ToDoMessageViewModel> lstToDoMessageModel = new List<ToDoMessageViewModel>();
            var toDoMessage = await _toDoMessageHelper.GetAllAsync();
            toDoMessage = toDoMessage.Where(a => a.ToDo_Details_Id == todoDetailsId).ToList();
            toDoMessage.ToList().ForEach(item =>
            {
                lstToDoMessageModel.Add(new ToDoMessageViewModel
                {
                    ToDoDetailsId=item.ToDo_Details_Id,
                    ToDoMessageId=item.ToDo_Message_Id,
                    ToDoMessageTitle=item.ToDo_Message_Title??string.Empty,
                    IsOwner=item.Is_Owner,
                    IsSub=item.Is_Sub,
                   CreatdDate=DateTime.Today,
                   CreatedBy="aaa"

                });
            });
            return lstToDoMessageModel;
        }

        public Task<List<ToDoMessageViewModel>> GetAllToDoMessageDetailsByTitle(string title = "", int status = 0, string priority = "")
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoMessageViewModel> SaveToDoMessage(ToDoMessageViewModel toDoMessageViewModel)
        {
            ToDoMessage toDoMessages = new ToDoMessage()
            {
                ToDo_Details_Id=toDoMessageViewModel.ToDoDetailsId,
                ToDo_Message_Title=toDoMessageViewModel.ToDoMessageTitle??string.Empty,
                Is_Owner=toDoMessageViewModel.IsOwner,
                Is_Sub=toDoMessageViewModel.IsSub,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var todoMessageObj = await _toDoMessageHelper.CreateAsync(toDoMessages);
            ToDoMessageViewModel toDoMessageViewModels = new ToDoMessageViewModel
            {
                ToDoMessageId = Convert.ToInt32(todoMessageObj.ToDo_Message_Id)
            };

            return toDoMessageViewModels;
        }

        public Task<ToDoMessageViewModel> UpdateToDoMessageDetails(ToDoMessageViewModel toDoMasterDetails)
        {
            throw new NotImplementedException();
        }
    }
}
