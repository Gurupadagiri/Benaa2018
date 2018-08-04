using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDochecklistViewModel : CommonViewModel
    {
        public int ToDoCheckListId { get; set; }
        public int TodoDetailsID { get; set; }
       
  
        public bool ToDoAssignIsCheckListItem { get; set; }
        public bool ToDoAssignIFilesCheckListItem { get; set; }

        public int ToDoCheckListUserType { get; set; }
        public int ToDoCheckListUserId { get; set; }
    }
}
