using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Benaa2018.Helper.ViewModels
{
    public class  UserPreferenceViewModel 
    {
        public DetaildPermissionViewModel permissions { get; set; }
        public UserMasterViewModel usermasters { get; set; }
    }
}
