using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoMessageViewModel : CommonViewModel
    {
        public int ToDoMessageId { get; set; }
        public int ToDoDetailsId { get; set; }
        public string ToDoMessageTitle { get; set; }
        public bool IsOwner { get; set; }
        public bool IsSub { get; set; }
        public string CreatedBy { get; set; }
    }
}
