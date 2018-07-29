using Benaa2018.Helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class InternalUserViewModel
    {
        public InternalUserViewModel()
        {
            InternalUserGrid = new List<InternalUserGridModel>();
            SubContractorGrid = new List<SubContractorGridModel>();
            CustomerContactGrid = new List<CustomerContactGridModel>();
        }
        public List<InternalUserGridModel> InternalUserGrid { get; set; }
        public List<SubContractorGridModel> SubContractorGrid { get; set; }
        public List<CustomerContactGridModel> CustomerContactGrid { get; set; }
    }
}
