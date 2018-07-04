using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectSubcontractorConfigViewModel
    {
        public int SubContractorID { get; set; }
        public int OrgID { get; set; }
        public decimal ProjectID { get; set; }
        public string SubcontractorName { get; set; }
        public bool ViewAccess { get; set; }
    }
}
