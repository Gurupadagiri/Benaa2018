using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjctStatusMasterViewModel
    {
        public int StatusID { get; set; }
        public int OrgID { get; set; }
        public string StatusName { get; set; }
        public bool Active { get; set; }
    }
}
