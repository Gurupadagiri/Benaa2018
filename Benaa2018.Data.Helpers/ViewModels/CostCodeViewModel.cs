using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class CostCodeViewModel : CommonViewModel
    {
        public int CostCodeId { get; set; }
        public string CostCodeTitle { get; set; }
        public int CostCategoryId { get; set; }
        public int CodeSubCodeId { get; set; }
        public bool IsCostCodeActive { get; set; }
        public bool IsTimeClockLabourCode { get; set; }
        public string CostCodeDetails { get; set; }
        public string DefaultLabourCode { get; set; }
    }
}
