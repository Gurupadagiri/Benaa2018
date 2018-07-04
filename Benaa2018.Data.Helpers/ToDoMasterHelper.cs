using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ToDoMasterHelper : IToDoMasterHelper
    {
        private readonly IToDoMasterRepoisitory _toDoMasterRepoisitory;
        private readonly IProjectMasterHelper _projectMasterHelper;
        public ToDoMasterHelper(IToDoMasterRepoisitory toDoMasterRepoisitory,
            IProjectMasterHelper projectMasterHelper)
        {
            _toDoMasterRepoisitory = toDoMasterRepoisitory;
            _projectMasterHelper = projectMasterHelper;
        }

        public async Task<List<ToDoMasterViewModel>> GetToDoListByProjectID(int projectID)
        {
            List<ToDoMasterViewModel> lstToDoMaster = new List<ToDoMasterViewModel>();            
            var toDoMasters = await _toDoMasterRepoisitory.GetAllAsync();
            if (projectID != 0)
            {
                toDoMasters = toDoMasters.Where(a => a.Project_ID <= projectID).ToList();
            }
            toDoMasters.ToList().ForEach(async item =>
            {
                lstToDoMaster.Add(new ToDoMasterViewModel
                {
                    DueDate = item.Due_Date_Selection.ToString(),
                    ProjectId = projectID,
                    ProjectName = await _projectMasterHelper.GetNameByProjectId(projectID),
                    Title = item.Title,
                    TodoID = item.Todo_ID,
                    Priority = item.Priority,
                    ProjectSite = item.Project_Site
                });
            });
            return lstToDoMaster;
        }
        public async Task<List<ToDoMasterViewModel>> GetFilteredToDoList(int days)
        {
            List<ToDoMasterViewModel> lstToDoMaster = new List<ToDoMasterViewModel>();
            var toDoMasters = await _toDoMasterRepoisitory.GetAllAsync();            
            if (days != 0)
            {
                toDoMasters = toDoMasters.Where(a => a.Days <= days).ToList();
            }
            toDoMasters.ToList().ForEach(item =>
            {
                lstToDoMaster.Add(new ToDoMasterViewModel
                {
                    DueDate = item.Due_Date_Selection.ToString(),
                    Title = item.Title,
                    TodoID = item.Todo_ID,
                    Priority = item.Priority,
                    ProjectSite = item.Project_Site
                });
            });
            return lstToDoMaster;
        }

        public async Task<List<ToDoMasterViewModel>> GetAllToDoList()
        {
            List<ToDoMasterViewModel> lstToDoMaster = new List<ToDoMasterViewModel>();
            var toDoMasters = await _toDoMasterRepoisitory.GetAllAsync();
            toDoMasters.ToList().ForEach(item =>
            {
                lstToDoMaster.Add(new ToDoMasterViewModel
                {
                    DueDate = item.Due_Date_Selection.ToString(),
                    Title = item.Title,
                    TodoID = item.Todo_ID,
                    Priority = item.Priority,
                    ProjectSite = item.Project_Site
                });
            });
            return lstToDoMaster;
        }
    }
}


