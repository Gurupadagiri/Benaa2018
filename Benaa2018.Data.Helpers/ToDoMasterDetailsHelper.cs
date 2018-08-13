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
                DueDatetime = masterDetailsViewModel.DueDatetime ?? string.Empty,
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
            toDoInfo = toDoInfo.Where(a => a.DeletionStatus == false).ToList();
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



        public async Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsByTitle(string title="", int status = 0, string priority="")
        {
            List<ToDoMasterDetailsViewModel> lstToDoMasterModel = new List<ToDoMasterDetailsViewModel>();
            var toDoInfo = await _toDoMasterDetailsHelper.GetAllAsync();
            //if (!string.IsNullOrEmpty(title))
            //{
            //    toDoInfo = toDoInfo.Where(a => a.Title.Contains(title)).ToList();
            //}

            if(toDoInfo.Count() > 0)
            {

            
             if(status>0)
            {
                bool statusToDo = false;
                if(status==1)
                {
                    statusToDo = true;
                    toDoInfo = toDoInfo.Where(a => a.IsMarkedComplete == statusToDo).ToList();
                }
                else if(status==0)
                {
                    toDoInfo = toDoInfo.Where(a => a.IsMarkedComplete == statusToDo).ToList();
                }
               
            }
            if (!string.IsNullOrEmpty(priority))
            {
                if(priority== "Low" || priority == "High" || priority == "Highest" || priority == "None")
                {

                toDoInfo = toDoInfo.Where(a => a.Priority == priority).ToList();
                }
            }


                if (toDoInfo.Count() > 0)
            {
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
            }
            }
            return lstToDoMasterModel;
        }



        public async Task<ToDoMasterDetailsViewModel> UpdateToDoMasterDetails(ToDoMasterDetailsViewModel masterDetailsViewModel)
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
                DueDatetime = masterDetailsViewModel.DueDatetime ?? string.Empty,
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
           // storeContext.Entry(item).State = EntityState.Detached
            var userObj = await _toDoMasterDetailsHelper.UpdateAsync(toDoMasterDetails);
            ToDoMasterDetailsViewModel toDoMasterDetailsViewModel = new ToDoMasterDetailsViewModel
            {
                TodoDetailsID = Convert.ToInt32(userObj.TodoDetailsID)
            };

            return toDoMasterDetailsViewModel;
        }

        public async Task<ToDoMasterDetailsViewModel> DeleteToDoMasterDetails(string ids)
        {
            ToDoMasterDetails toDoMasterDetails = new ToDoMasterDetails()
            {
                TodoDetailsID = Convert.ToInt32(ids),
                DeletionStatus=true,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var userObj = await _toDoMasterDetailsHelper.UpdateAsync(toDoMasterDetails);
            ToDoMasterDetailsViewModel toDoMasterDetailsViewModel = new ToDoMasterDetailsViewModel
            {
                TodoDetailsID = Convert.ToInt32(userObj.TodoDetailsID)
            };

            return toDoMasterDetailsViewModel;
        }


        public async Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsById(int todoDetailsId)
        {
            List<ToDoMasterDetailsViewModel> lstToDoMasterModel = new List<ToDoMasterDetailsViewModel>();
            var toDoInfo = await _toDoMasterDetailsHelper.GetAllAsync();
            toDoInfo = toDoInfo.Where(a => a.TodoDetailsID==todoDetailsId).ToList();
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
