using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class GroupMasterViewModel : CommonViewModel
    {
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Sequence { get; set; }
        public int OrgId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string GroupDescription { get; set; }
    }
}
