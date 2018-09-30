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
    public class ActivityMasterHelper : IActivityMasterHelper
    {

        private readonly IActivityMasterRepository _activityMasterDetailsHelper;

        public ActivityMasterHelper(IActivityMasterRepository activityMasterDetailsHelper)
        {
            _activityMasterDetailsHelper = activityMasterDetailsHelper;
        }

        public Task<ActivityMasterViewModel> DeleteActivityMasterDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActivityMasterViewModel>> GetAllActivityMasterById(int activityMasterDetailsId)
        {
            List<ActivityMasterViewModel> lstactivityMasterModel = new List<ActivityMasterViewModel>();
            var activityMasterInfo = await _activityMasterDetailsHelper.GetAllAsync();
            activityMasterInfo = activityMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (activityMasterDetailsId > 0)
            {
                activityMasterInfo = activityMasterInfo.Where(a => a.Activity_Id == activityMasterDetailsId).ToList();
            }
            if (activityMasterInfo.Count() > 0)
            {


                activityMasterInfo.ToList().ForEach(item =>
                {

                    lstactivityMasterModel.Add(new ActivityMasterViewModel
                    {
                        ActivityId = item.Activity_Id,
                        MainActivityId = item.Main_Activity_Id,
                        ActivityName = item.Activity_Name,
                        ParentId = item.Parent_Id,
                        OrgId = item.Org_Id,
                        Status = item.Status,
                        IsDeleted = item.Is_Deleted
                    });
                });
            }
            return lstactivityMasterModel;
        }

        public Task<List<ActivityMasterViewModel>> GetAllActivityMasterByParam(string title = "", int status = 0, string priority = "")
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActivityMasterViewModel>> GetAllActivityMasterDetails(string activityCode = "", int activityId = 0, int caseUpdate = 0)
        {
            List<ActivityMasterViewModel> lstactivityMasterModel = new List<ActivityMasterViewModel>();
            var activityMasterInfo = await _activityMasterDetailsHelper.GetAllAsync();
            activityMasterInfo = activityMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (caseUpdate == 0)
            {
                if (!string.IsNullOrEmpty(activityCode))
                {
                    activityMasterInfo = activityMasterInfo.Where(a => a.Activity_Code == activityCode).ToList();
                }
            }
            else if(caseUpdate==10)
            {
                activityMasterInfo = activityMasterInfo.Where(a => a.Status == true).ToList();
            }
            else
            {
                activityMasterInfo = activityMasterInfo.Where(a => a.Activity_Id == activityId).ToList();
            }
            if (activityMasterInfo?.Count() > 0)
            {
                activityMasterInfo.ToList().ForEach(item =>
                {

                    lstactivityMasterModel.Add(new ActivityMasterViewModel
                    {
                        ActivityId = item.Activity_Id,
                        MainActivityId = item.Main_Activity_Id,
                        ActivityName = item.Activity_Name,
                        ActivityCode = item.Activity_Code,
                        ParentId = item.Parent_Id,
                        OrgId = item.Org_Id,
                        Status = item.Status,
                        IsDeleted = item.Is_Deleted,
                        Sequence=item.Sequence,
                        ActivityDescription=item.ActivityDescription
                    });
                });
            }

            return lstactivityMasterModel;
        }

        public async Task<ActivityMasterViewModel> SaveActivityMasterDetails(ActivityMasterViewModel activityMasterViewModel)
        {
            ActivityMaster acttivity = new ActivityMaster()
            {
                // Activity_Id = activityMasterViewModel.ActivityId,
                Main_Activity_Id = activityMasterViewModel.MainActivityId,
                Activity_Name = activityMasterViewModel.ActivityName,
                Activity_Code = activityMasterViewModel.ActivityCode,
                Parent_Id = activityMasterViewModel.ParentId,
                Org_Id = activityMasterViewModel.OrgId,
                Status = activityMasterViewModel.Status,
                Sequence = activityMasterViewModel.Sequence,
                Is_Deleted = activityMasterViewModel.IsDeleted,
                ActivityDescription = activityMasterViewModel.ActivityDescription,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };

            var activityMaster = await _activityMasterDetailsHelper.CreateAsync(acttivity);
            ActivityMasterViewModel activityMastersViewModel = new ActivityMasterViewModel()
            {
                ActivityId = activityMaster.Activity_Id
            };

            return activityMastersViewModel;
        }

        public async Task<ActivityMasterViewModel> UpdateActivityMasterDetails(ActivityMasterViewModel activityMasterViewModel)
        {
            ActivityMaster acttivity = new ActivityMaster()
            {
                Activity_Id = activityMasterViewModel.ActivityId,
                Main_Activity_Id = activityMasterViewModel.MainActivityId,
                Activity_Name = activityMasterViewModel.ActivityName,
                Parent_Id = activityMasterViewModel.ParentId,
                Org_Id = activityMasterViewModel.OrgId,
                Status = activityMasterViewModel.Status,
                Sequence = activityMasterViewModel.Sequence,
                Is_Deleted = activityMasterViewModel.IsDeleted,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };

            var activityMaster = await _activityMasterDetailsHelper.UpdateAsync(acttivity);
            ActivityMasterViewModel activityMastersViewModel = new ActivityMasterViewModel()
            {
                ActivityId = activityMaster.Activity_Id
            };
            return activityMastersViewModel;
        }
    }
}
