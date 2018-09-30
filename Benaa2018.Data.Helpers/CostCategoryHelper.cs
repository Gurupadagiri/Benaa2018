using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class CostCategoryHelper : ICostCategoryHelper
    {
        private readonly ICostCategoryRepository _costCategoryRespository;
        public CostCategoryHelper(ICostCategoryRepository costCategoryRespository)
        {
            _costCategoryRespository = costCategoryRespository;
        }

        public Task<CostCategoryViewModel> DeleteCostCategoryDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CostCategoryViewModel>> GetCostCategoryDetails()
        {
            List<CostCategoryViewModel> lstCostCategoryModel = new List<CostCategoryViewModel>();
            var costCategory = await _costCategoryRespository.GetAllAsync();
           
            if (costCategory.Count() > 0)
            {
                costCategory.ToList().ForEach(item =>
                {
                    lstCostCategoryModel.Add(new CostCategoryViewModel
                    {
                        CostCategoryId = item.CostCategoryId,
                        CostCategoryTitle = item.CostCategoryTitle?? string.Empty,
                        CostCategoryParentId = item.CostCategoryParentId,
                        CostCategoryDetails = item.CostCategoryDetails?? string.Empty,
                        isDeleted = item.isDeleted

                    });
                });
            }
            return lstCostCategoryModel;
        }

        public async Task<int> SaveCostCategoryDetails(CostCategoryViewModel costCodeViewModel)
        {
            CostCategory costCategoryItem = new CostCategory
            {
                CostCategoryId = costCodeViewModel.CostCategoryId,
                CostCategoryTitle = costCodeViewModel.CostCategoryTitle,
                CostCategoryParentId = costCodeViewModel.CostCategoryParentId,
                CostCategoryDetails = costCodeViewModel.CostCategoryDetails,
                isDeleted = costCodeViewModel.isDeleted
               

            };
            var costCategoryObj = await _costCategoryRespository.CreateAsync(costCategoryItem);
            return costCategoryObj.CostCategoryId;
        }

        public Task<CostCategoryViewModel> UpdateCostCategoryDetails(CostCategoryViewModel costCodeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
