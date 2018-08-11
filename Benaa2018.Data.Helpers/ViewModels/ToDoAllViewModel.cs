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

        public string UserNames { get; set; }

        public int TotalUserNameCount { get; set; }

        public int[] TagIds { get; set; }

        public int TotalTagCount { get; set; }
        public List<TagMasterViewModel> lstTags { get; set; }

        public List<ToDoAssignViewModel> lstAssigns { get; set; }

        public List<ToDochecklistViewModel> lstCheckLists { get; set; }
        public List<ToDochecklistDetailsViewModel> lstCheckListDetails { get; set; }

        public List<ToDoTagViewModel> lstToDoDetails { get; set; }

        public string TagNames { get; set; }

        public int TotalNumberOfMessages { get; set; }

        public ToDochecklistViewModel ToDoCheckList { get; set; }

        public List<ToDochecklistDetailsViewModel> lstCheckListDetail { get; set; }

    }

    public class ToDoAllViewModelDetails
    {
        public List<ToDoAllViewModel> lstToDoAllViewModel { get; set; }
    }



}
