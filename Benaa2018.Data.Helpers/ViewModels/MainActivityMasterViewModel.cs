using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
  public  class MainActivityMasterViewModel : CommonViewModel
    {
        public int MainActivityId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public string MainActivityName { get; set; }
        public string MainActivityCode { get; set; }
        public int OrgId { get; set; }
        public string Sequence { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string MainActivityDescription { get; set; }
        public List<GroupMasterViewModel> lstGroupMaster { get; set; }
    }
}
