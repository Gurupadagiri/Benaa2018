using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
   public class CostListsModel
    {
        public List<GroupMasterViewModel> lstGroupMaster { get; set; }

        public List<MainActivityMasterViewModel> lstMainActivityMaster { get; set; }

        public List<ActivityMasterViewModel> lstActivityMaster { get; set; }

        public List<VarianceMasterViewModel> lstVarianceMaster { get; set; }

        public bool chkStatus { get; set; }
    }
}
