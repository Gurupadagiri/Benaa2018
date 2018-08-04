using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoAllViewModel
    {
        public ToDoMasterDetailsViewModel ToDoDetails { get; set; }

        public ToDoAssignViewModel ToDoAssign { get; set; }

        public int[] UserMasters { get; set; }

        public int[] OwnerMasters { get; set; }

        public int[] SubContractorMasters { get; set; }

        public TagMasterViewModel  TagMaster { get; set; }


        public int[] TagIds { get; set; }


        public ToDochecklistViewModel ToDoCheckList { get; set; }

        public List<ToDochecklistDetailsViewModel> lstCheckListDetail { get; set; }

    }
}
