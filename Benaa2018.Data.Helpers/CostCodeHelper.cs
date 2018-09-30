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
    public class CostCodeHelper : ICostCodeHelper
    {
        private readonly ICostCodeRepository _costCodeCategoryRespository;

        public CostCodeHelper(ICostCodeRepository costCodeCategoryRespository)
        {
            _costCodeCategoryRespository = costCodeCategoryRespository;
        }

        public Task<CostCodeViewModel> DeleteCostCodeDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CostCodeViewModel>> GetCostCodeDetails()
        {
            List<CostCodeViewModel> lstCostCodeModel = new List<CostCodeViewModel>();
            var costCategory = await _costCodeCategoryRespository.GetAllAsync();

            if (costCategory.Count() > 0)
            {
                costCategory.ToList().ForEach(item =>
                {
                    lstCostCodeModel.Add(new CostCodeViewModel
                    {
                        CostCodeId = item.CostCodeId,
                        CostCodeTitle = item.CostCodeTitle ?? string.Empty,
                        CostCategoryId = item.CostCategoryId,
                        CodeSubCodeId = item.CodeSubCodeId,
                        IsCostCodeActive = item.IsCostCodeActive,
                        IsTimeClockLabourCode=item.IsTimeClockLabourCode,
                        CostCodeDetails=item.CostCodeDetails,
                        DefaultLabourCode=item.DefaultLabourCode

                    });
                });
            }
            return lstCostCodeModel;
        }

        public async Task<int> SaveCostCodeDetails(CostCodeViewModel costCodeViewModel)
        {
            CostCode costCodeItem = new CostCode
            {
                CostCodeId = costCodeViewModel.CostCodeId,
                CostCodeTitle = costCodeViewModel.CostCodeTitle ?? string.Empty,
                CostCategoryId = costCodeViewModel.CostCategoryId,
                CodeSubCodeId = costCodeViewModel.CodeSubCodeId,
                IsCostCodeActive = costCodeViewModel.IsCostCodeActive,
                IsTimeClockLabourCode = costCodeViewModel.IsTimeClockLabourCode,
                CostCodeDetails = costCodeViewModel.CostCodeDetails?? string.Empty,
                DefaultLabourCode = costCodeViewModel.DefaultLabourCode


            };
            var costCategoryObj = await _costCodeCategoryRespository.CreateAsync(costCodeItem);
            return costCategoryObj.CostCategoryId;
        }

        public Task<CostCodeViewModel> UpdateCostCodeDetails(CostCodeViewModel costCodeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
