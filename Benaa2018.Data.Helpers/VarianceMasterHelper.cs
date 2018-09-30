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
    public class VarianceMasterHelper : IVarianceMasterHelper
    {

        private readonly IVarianceMasterRepository _varianceMasterDetailsHelper;

        public VarianceMasterHelper(IVarianceMasterRepository varianceMasterDetailsHelper)
        {
            _varianceMasterDetailsHelper = varianceMasterDetailsHelper;
        }

        public async Task<VarianceMasterViewModel> DeleteActivityMasterDetails(VarianceMasterViewModel varianceMasterViewModel)
        {
            VarianceMaster variance = new VarianceMaster()
            {

                Variance_Id = varianceMasterViewModel.MainActivityId,
                Variance_Name = varianceMasterViewModel.VarianceName,
                Variance_Code = varianceMasterViewModel.VarianceCode,
                Parent_Id = varianceMasterViewModel.ParentId,
                Org_Id = varianceMasterViewModel.OrgId,
                Status = varianceMasterViewModel.Status,
                Sequence = varianceMasterViewModel.Sequence,
                Is_Deleted = true,
                VarianceDescription = varianceMasterViewModel.VarianceDescription,
                Main_Activity_Id = varianceMasterViewModel.MainActivityId,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today

            };

            var varianceMaster = await _varianceMasterDetailsHelper.UpdateAsync(variance);
            VarianceMasterViewModel varianceMastersViewModel = new VarianceMasterViewModel()
            {
                VarianceId = varianceMaster.Variance_Id
            };
            return varianceMastersViewModel;
        }

        public async Task<List<VarianceMasterViewModel>> GetAllVarianceMasterDetails(string varianceCode = "", int varianceId = 0, int caseUpdate = 0)
        {
            List<VarianceMasterViewModel> lstvarianceMasterModel = new List<VarianceMasterViewModel>();
            var varianceMasterInfo = await _varianceMasterDetailsHelper.GetAllAsync();
            varianceMasterInfo = varianceMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (caseUpdate == 0)
            {
                if (!string.IsNullOrEmpty(varianceCode))
                {
                    varianceMasterInfo = varianceMasterInfo.Where(a => a.Variance_Code == varianceCode).ToList();
                }
            }
            else if(caseUpdate==10)
            {
                varianceMasterInfo = varianceMasterInfo.Where(a => a.Status == true).ToList();
            }
            else
            {
                varianceMasterInfo = varianceMasterInfo.Where(a => a.Variance_Id == varianceId).ToList();
            }
            if (varianceMasterInfo?.Count() > 0)
            {
                varianceMasterInfo.ToList().ForEach(item =>
                {

                    lstvarianceMasterModel.Add(new VarianceMasterViewModel
                    {
                        VarianceId=item.Variance_Id,
                        MainActivityId=item.Main_Activity_Id,
                        VarianceName=item.Variance_Name,
                        VarianceCode=item.Variance_Code,
                        ParentId=item.Parent_Id,
                        OrgId=item.Org_Id,
                        Status=item.Status,
                        Sequence=item.Sequence,
                        IsDeleted=item.Is_Deleted,
                        VarianceDescription=item.VarianceDescription
                    });
                });
            }

            return lstvarianceMasterModel;
        }

        public async Task<VarianceMasterViewModel> SaveVarianceMasterDetails(VarianceMasterViewModel varianceMasterViewModel)
        {
            VarianceMaster variance = new VarianceMaster()
            {

                Variance_Id = varianceMasterViewModel.VarianceId,
                Variance_Name = varianceMasterViewModel.VarianceName,
                Variance_Code = varianceMasterViewModel.VarianceCode,
                Parent_Id = varianceMasterViewModel.ParentId,
                Org_Id = varianceMasterViewModel.OrgId,
                Status = varianceMasterViewModel.Status,
                Sequence = varianceMasterViewModel.Sequence,
                Is_Deleted = varianceMasterViewModel.IsDeleted,
                VarianceDescription = varianceMasterViewModel.VarianceDescription,
                Main_Activity_Id= varianceMasterViewModel.MainActivityId,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today

            };

            var varianceMaster = await _varianceMasterDetailsHelper.CreateAsync(variance);
            VarianceMasterViewModel varianceMastersViewModel = new VarianceMasterViewModel()
            {
                VarianceId = varianceMaster.Variance_Id
            };

            return varianceMastersViewModel;
        }

        public async Task<VarianceMasterViewModel> UpdateActivityMasterDetails(VarianceMasterViewModel varianceMasterViewModel)
        {
            VarianceMaster variance = new VarianceMaster()
            {

                Variance_Id = varianceMasterViewModel.MainActivityId,
                Variance_Name = varianceMasterViewModel.VarianceName,
                Variance_Code = varianceMasterViewModel.VarianceCode,
                Parent_Id = varianceMasterViewModel.ParentId,
                Org_Id = varianceMasterViewModel.OrgId,
                Status = varianceMasterViewModel.Status,
                Sequence = varianceMasterViewModel.Sequence,
                Is_Deleted = varianceMasterViewModel.IsDeleted,
                VarianceDescription = varianceMasterViewModel.VarianceDescription,
                Main_Activity_Id = varianceMasterViewModel.MainActivityId,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today

            };

            var varianceMaster = await _varianceMasterDetailsHelper.UpdateAsync(variance);
            VarianceMasterViewModel varianceMastersViewModel = new VarianceMasterViewModel()
            {
                VarianceId = varianceMaster.Variance_Id
            };
            return varianceMastersViewModel;
        }
    }
}
