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
    public class ToDoScheduleItemHelper : IToDoScheduleItemHelper
    {
        private readonly IToDoScheduleItemRepository _toDoScheduleItemHelper;

        public ToDoScheduleItemHelper(IToDoScheduleItemRepository toDoScheduleItemRepository)
        {
            _toDoScheduleItemHelper = toDoScheduleItemRepository;
        }
        public async Task<ToDoScheduleItemViewModel> SaveToDoScheduleItemDetails(ToDoScheduleItemViewModel toDoScheduleItemViewModel)
        {
            ToDoScheduleItem todoSchedule = new ToDoScheduleItem
            {
                ToDoScheduleItemId=toDoScheduleItemViewModel.ToDoScheduleItemId,
                TodoDetailsID=toDoScheduleItemViewModel.TodoDetailsID,
                ToDoScheduleTitle= toDoScheduleItemViewModel.ToDoScheduleTitle,
                ToDoScheduleStartDate= toDoScheduleItemViewModel.ToDoScheduleStartDate,
                ToDoScheduleEndDate= toDoScheduleItemViewModel.ToDoScheduleEndDate,
                ToDoScheduleDuration= toDoScheduleItemViewModel.ToDoScheduleDuration,
                ToDoScheduleIsHourly= toDoScheduleItemViewModel.ToDoScheduleIsHourly,
                ToDoScheduleDisplayColor= toDoScheduleItemViewModel.ToDoScheduleDisplayColor,
                ToDoScheduleReminder= toDoScheduleItemViewModel.ToDoScheduleReminder

            };

            var ScheduleObj = await _toDoScheduleItemHelper.CreateAsync(todoSchedule);
            ToDoScheduleItemViewModel toDoScheduleViewModel = new ToDoScheduleItemViewModel
            {
                ToDoScheduleItemId = Convert.ToInt32(ScheduleObj.ToDoScheduleItemId)
            };

            return toDoScheduleViewModel;
        }
    }
}
