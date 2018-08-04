using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
   public  class ToDochecklistDetailsViewModel : CommonViewModel
    {
        public int ToDochecklistDetailsViewModelId { get; set; }
        public int ToDoCheckListId { get; set; }
        public bool ToDoIsCheckList { get; set; }

        public string ToDoCheckListTitle { get; set; }
        public int ToDoCheckListUserType { get; set; }
        public int ToDoCheckListUserId { get; set; }
    }
}
