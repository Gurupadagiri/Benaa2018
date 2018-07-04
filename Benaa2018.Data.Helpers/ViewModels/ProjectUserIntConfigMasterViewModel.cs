using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectUserIntConfigMasterViewModel
    {
        public int InternalUserConId { get; set; }
        public int OrgID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public string UserName { get; set; }
        public bool ViewAccess { get; set; }
        public bool ReciveNotification { get; set; }
    }
}
