using System;

namespace Benaa2018.Helper.ViewModels
{
    public class UserMasterViewModel: CommonViewModel
    {
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public Int32 OrgID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool ViewAccess { get; set; }
        public bool JobNotification { get; set; }
    }
}
