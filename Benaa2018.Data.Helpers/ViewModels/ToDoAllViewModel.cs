using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class ToDoAllViewModel : CommonViewModel
    {
        public ToDoAllViewModel()
        {
            ToDoAllModels = new List<ToDoAllViewModel>();
            lstTags = new List<TagMasterViewModel>();
            lstAssigns = new List<ToDoAssignViewModel>();
            lstCheckLists = new List<ToDochecklistViewModel>();
            lstToDoDetails = new List<ToDoTagViewModel>();
            lstCheckListDetail = new List<ToDochecklistDetailsViewModel>();
        }
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

        public int ToDoCheckListItemIndex { get; set; }

        public List<ToDochecklistDetailsViewModel> lstCheckListDetail { get; set; }
        public List<ToDoAllViewModel> ToDoAllModels { get; set; }
        public string ToDoListContent { get; set; }

        public string Operation { get; set; }
    }

    public class ToDoAllViewModelDetails
    {
        public List<ToDoAllViewModel> lstToDoAllViewModel { get; set; }
    }



}
