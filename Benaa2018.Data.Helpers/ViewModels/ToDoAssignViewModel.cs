using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoAssignViewModel : CommonViewModel
    {
        public int ToDoAssignID { get; set; }
        public int UserID { get; set; }
        public int TodoDetailsID { get; set; }
        public int ToDoUserAssignTypeId { get; set; }
    }
}
