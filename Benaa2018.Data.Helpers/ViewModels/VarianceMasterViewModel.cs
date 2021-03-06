﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class VarianceMasterViewModel : CommonViewModel
    {
        public int VarianceId { get; set; }
        public int MainActivityId { get; set; }
        public string VarianceName { get; set; }
        public string VarianceCode { get; set; }
        public int ParentId { get; set; }
        public int OrgId { get; set; }
        public bool Status { get; set; }
        public string Sequence { get; set; }
        public bool IsDeleted { get; set; }
        public string VarianceDescription { get; set; }
        public List<MainActivityMasterViewModel> lstMainActivityMaster { get; set; }
    }
}
