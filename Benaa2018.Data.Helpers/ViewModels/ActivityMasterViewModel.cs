using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
  public  class ActivityMasterViewModel : CommonViewModel
    {
        public int ActivityId { get; set; }
        public int MainActivityId { get; set; }
        public string MainActivityName { get; set; }
        public string ActivityName { get; set; }
        public int ParentId { get; set; }
        public int OrgId { get; set; }
        public bool Status { get; set; }
        public string Sequence { get; set; }
        public bool IsDeleted { get; set; }
        public string ActivityDescription { get; set; }
        public List<MainActivityMasterViewModel> lstMainActivityMaster { get; set; }
    }
}
