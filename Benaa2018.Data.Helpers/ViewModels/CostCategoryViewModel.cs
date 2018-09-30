using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class CostCategoryViewModel : CommonViewModel
    {
        public int CostCategoryId { get; set; }
        public string CostCategoryTitle { get; set; }
        public int CostCategoryParentId { get; set; }
        public string CostCategoryDetails { get; set; }
        public bool isDeleted { get; set; }

        public List<CostCategoryViewModel> lstCostCategories { get; set; }
    }
}
