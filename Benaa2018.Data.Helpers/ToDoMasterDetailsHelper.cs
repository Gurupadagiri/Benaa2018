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
    public class ToDoMasterDetailsHelper : IToDoMasterDetailsHelper
    {
        private readonly IToDoMasterDetailsRepository _toDoMasterDetailsHelper;

        public ToDoMasterDetailsHelper(IToDoMasterDetailsRepository toDoMasterDetailsRepository)
        {
            _toDoMasterDetailsHelper = toDoMasterDetailsRepository;
        }

        public async Task<ToDoMasterDetailsViewModel> SaveToDoMasterDetails(ToDoMasterDetailsViewModel masterDetailsViewModel)
        {
            ToDoMasterDetails toDoMasterDetails = new ToDoMasterDetails()
            {
                TodoDetailsID = masterDetailsViewModel.TodoDetailsID,
                Project_ID = masterDetailsViewModel.Project_ID,
                Project_Site = masterDetailsViewModel.Title ?? string.Empty,
                Title = masterDetailsViewModel.Title ?? string.Empty,
                Org_ID = masterDetailsViewModel.Org_ID,
                TypeNote = masterDetailsViewModel.TypeNote ?? string.Empty,
                IsMarkedComplete = masterDetailsViewModel.IsMarkedComplete,
                Priority = masterDetailsViewModel.Priority ?? string.Empty,
                Duedate = masterDetailsViewModel.Duedate,
                DueDatetime = masterDetailsViewModel.DueDatetime?? string.Empty,
                LinkToUnit = masterDetailsViewModel.LinkToUnit,
                LinkToDaysStatus = masterDetailsViewModel.LinkToDaysStatus,
                LinkToWorkId = masterDetailsViewModel.TillingWorkId,
                LinkToDate = masterDetailsViewModel.TillingDate,
                LinkToTime = masterDetailsViewModel.TillingTime ?? string.Empty,
                ReminderId = masterDetailsViewModel.ReminderId,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var userObj = await _toDoMasterDetailsHelper.CreateAsync(toDoMasterDetails);
            ToDoMasterDetailsViewModel toDoMasterDetailsViewModel = new ToDoMasterDetailsViewModel
            {
                TodoDetailsID = Convert.ToInt32(userObj.TodoDetailsID)
            };

            return toDoMasterDetailsViewModel;
        }





        public async Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetails()
        {
            List<ToDoMasterDetailsViewModel> lstToDoMasterModel = new List<ToDoMasterDetailsViewModel>();
            var toDoInfo = await _toDoMasterDetailsHelper.GetAllAsync();

            toDoInfo.ToList().ForEach(item =>
            {
                lstToDoMasterModel.Add(new ToDoMasterDetailsViewModel
                {
                    TodoDetailsID = item.TodoDetailsID,
                    Project_ID = item.Project_ID,
                    Project_Site = item.Project_Site,
                    Title = item.Title,
                    Org_ID = item.Org_ID,
                    TypeNote = item.TypeNote,
                    IsMarkedComplete = item.IsMarkedComplete,
                    Priority = item.Priority,
                    Duedate = item.Duedate,
                    DueDatetime = item.DueDatetime,
                    LinkToUnit = item.LinkToUnit,
                    LinkToDaysStatus = item.LinkToDaysStatus,
                    TillingWorkId = item.LinkToWorkId,
                    TillingDate = item.LinkToDate,
                    TillingTime = item.LinkToTime,
                    ReminderId = item.ReminderId
                });
            });
            return lstToDoMasterModel;
        }


    }
}
