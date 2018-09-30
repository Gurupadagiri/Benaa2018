using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class UserOwnerDifferentTypeViewModel
    {
        public int UserOwnerDifferentTypeId { get; set; }
        public int UserOriginalId { get; set; }
        public int UserOriginaTypeId { get; set; }
        public string UserOriginaTypeText { get; set; }
        public string UserOwnerDifferentTypeValue { get; set; }

    }

    public enum AssignedUserType
    {
        Owner,
        SubContractor,
        InternalUser
    }
}
