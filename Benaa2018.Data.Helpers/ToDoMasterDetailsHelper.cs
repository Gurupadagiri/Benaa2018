using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            DateTime dt2 = DateTime.Now;
            if (!string.IsNullOrEmpty(masterDetailsViewModel.DueDateFormat))
            {
                string dt1 = masterDetailsViewModel.DueDateFormat.ToString();
                var datetoEnter = DateTime.ParseExact(dt1, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                dt2 = datetoEnter;
            }
            ToDoMasterDetails toDoMasterDetails = new ToDoMasterDetails()
            {
                Project_ID = masterDetailsViewModel.Project_ID,
                Project_Site = masterDetailsViewModel.Title ?? string.Empty,
                Title = masterDetailsViewModel.Title ?? string.Empty,
                Org_ID = masterDetailsViewModel.Org_ID,
                TypeNote = masterDetailsViewModel.TypeNote ?? string.Empty,
                IsMarkedComplete = masterDetailsViewModel.IsMarkedComplete,
                Priority = masterDetailsViewModel.Priority ?? string.Empty,
                Duedate = dt2,
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

        public async Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetails(int projectId = 0)
        {
            List<ToDoMasterDetailsViewModel> lstToDoMasterModel = new List<ToDoMasterDetailsViewModel>();
            var toDoInfo = await _toDoMasterDetailsHelper.GetAllAsync();
            toDoInfo = toDoInfo.Where(a => a.DeletionStatus == false && !a.IsMarkedComplete).ToList();
            if (toDoInfo != null && projectId > 0)
            {
                toDoInfo = toDoInfo.Where(a => a.Project_ID == projectId).ToList();
            }

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

        public async Task<List<ToDoMasterDetailsViewModel>> GetAllToDoMasterDetailsByTitle(int projectId = 0, string title = "", int status = 0, string priority = "")
        {
            List<ToDoMasterDetailsViewModel> lstToDoMasterModel = new List<ToDoMasterDetailsViewModel>();
            try
            {
                var toDoInfo = await _toDoMasterDetailsHelper.GetAllAsync();
                toDoInfo = toDoInfo.Where(a => a.DeletionStatus == false).ToList();
                if (toDoInfo.Count() > 0)
                {
                    toDoInfo = toDoInfo.Where(a => a.Project_ID == projectId).ToList();
                }
                if (toDoInfo.Count() > 0)
                {
                    if (!string.IsNullOrEmpty(title))
                    {
                        toDoInfo = toDoInfo.Where(a => a.Title != null && a.Title.Contains(title)).ToList();
                    }
                }

                if (toDoInfo.Count() > 0)
                {
                    bool statusToDo = false;
                    if (status == 1)
                    {
                        statusToDo = true;
                        toDoInfo = toDoInfo.Where(a => a.IsMarkedComplete == statusToDo).ToList();
                    }
                    else if (status == 0)
                    {
                        toDoInfo = toDoInfo.Where(a => a.IsMarkedComplete == statusToDo).ToList();
                    }
                    if (!string.IsNullOrEmpty(priority))
                    {
                        if (priority != "Select options" && priority != "4 selected")
                        {
                            List<string> lstPriorities = new List<string>();
                            string[] prioritySplit = priority.Split(',');
                            if (prioritySplit.Length > 0)
                            {
                                foreach (string item in prioritySplit)
                                {
                                    if (!string.IsNullOrEmpty(item))
                                    {
                                        lstPriorities.Add(item);
                                    }
                                }
                            }
                            if (lstPriorities.Count == 1)
                            {
                                toDoInfo = toDoInfo.Where(a => a.Priority == lstPriorities[0]).ToList();
                            }
                            else if (lstPriorities.Count == 2)
                            {
                                toDoInfo = toDoInfo.Where(a => a.Priority == lstPriorities[0] || a.Priority == lstPriorities[1]).ToList();
                            }
                            else if (lstPriorities.Count == 3)
                            {
                                toDoInfo = toDoInfo.Where(a => a.Priority == lstPriorities[0] || a.Priority == lstPriorities[1] || a.Priority == lstPriorities[2]).ToList();
                            }
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
            }
            catch (Exception ex)
            {

            }
            return lstToDoMasterModel;
        }

        public async Task<ToDoMasterDetailsViewModel> UpdateToDoMasterDetails(ToDoMasterDetailsViewModel masterDetailsViewModel)
        {
            ToDoMasterDetails toDoMasterDetails1 = new ToDoMasterDetails()
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
            var userObj = await _toDoMasterDetailsHelper.UpdateAsync(toDoMasterDetails1);
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
                DeletionStatus = true,
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

        public async Task<ToDoMasterDetailsViewModel> GetAllToDoMasterDetailsById(int todoDetailsId)
        {
            ToDoMasterDetailsViewModel toDoMasterModel = null;
            var toDoInfo = await _toDoMasterDetailsHelper.GetByIdAsync(todoDetailsId);
            if (toDoInfo == null) return toDoMasterModel;
            toDoMasterModel = new ToDoMasterDetailsViewModel
            {
                TodoDetailsID = toDoInfo.TodoDetailsID,
                Project_ID = toDoInfo.Project_ID,
                Project_Site = toDoInfo.Project_Site,
                Title = toDoInfo.Title,
                Org_ID = toDoInfo.Org_ID,
                TypeNote = toDoInfo.TypeNote,
                IsMarkedComplete = toDoInfo.IsMarkedComplete,
                Priority = toDoInfo.Priority,
                Duedate = toDoInfo.Duedate,
                DueDatetime = toDoInfo.DueDatetime,
                LinkToUnit = toDoInfo.LinkToUnit,
                LinkToDaysStatus = toDoInfo.LinkToDaysStatus,
                TillingWorkId = toDoInfo.LinkToWorkId,
                TillingDate = toDoInfo.LinkToDate,
                TillingTime = toDoInfo.LinkToTime,
                ReminderId = toDoInfo.ReminderId
            };
            return toDoMasterModel;
        }
    }
}
