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
    public class MainActivityMasterHelper : IMainActivityMasterHelper
    {
        private readonly IMainActivityMasterRepository _mainActivityMasterDetailsHelper;

        public MainActivityMasterHelper(IMainActivityMasterRepository mainActivityMasterDetailsHelper)
        {
            _mainActivityMasterDetailsHelper = mainActivityMasterDetailsHelper;
        }

        public Task<MainActivityMasterViewModel> DeleteMainActivityMasterDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterById(int mainActivityMasterDetailsId)
        {
            List<MainActivityMasterViewModel> lstmainActivityMasterModel = new List<MainActivityMasterViewModel>();
            var mainActivityMasterInfo = await _mainActivityMasterDetailsHelper.GetAllAsync();
            mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (mainActivityMasterDetailsId > 1)
            {
                mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Main_Activity_Id == mainActivityMasterDetailsId).ToList();
            }
            mainActivityMasterInfo.ToList().ForEach(item =>
            {
                lstmainActivityMasterModel.Add(new MainActivityMasterViewModel
                {
                    MainActivityId = item.Main_Activity_Id,
                    GroupId = item.Group_Id,
                    MainActivityName = item.Main_Activity_Name,
                    Sequence = item.Sequence,
                    OrgId = item.Org_Id,
                    Status = item.Status,
                    IsDeleted = item.Is_Deleted
                });
            });
            return lstmainActivityMasterModel;
        }

        public Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterByParam(string title = "", int status = 0, string priority = "")
        {
            throw new NotImplementedException();
        }

        public async Task<List<MainActivityMasterViewModel>> GetAllMainActivityMasterDetails(string mainActivityCode = "", int mainActivityId = 0, int caseType = 0)
        {
            List<MainActivityMasterViewModel> lstmainActivityMasterModel = new List<MainActivityMasterViewModel>();
            var mainActivityMasterInfo = await _mainActivityMasterDetailsHelper.GetAllAsync();
            mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (caseType == 0)
            {
                if (!string.IsNullOrEmpty(mainActivityCode))
                {
                    mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Main_Activity_Code == mainActivityCode).ToList();
                }
            }
            else if(caseType == 10)
            {
                mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Status == true).ToList();
            }
            else
            {

                if (mainActivityId > 0)
                {
                    mainActivityMasterInfo = mainActivityMasterInfo.Where(a => a.Main_Activity_Id == mainActivityId).ToList();
                }
            }
            if (mainActivityMasterInfo?.Count() > 0)
            {
                mainActivityMasterInfo.ToList().ForEach(item =>
                {
                    lstmainActivityMasterModel.Add(new MainActivityMasterViewModel
                    {
                        MainActivityId = item.Main_Activity_Id,
                        GroupId = item.Group_Id,
                        MainActivityName = item.Main_Activity_Name,
                        MainActivityCode = item.Main_Activity_Code,
                        MainActivityDescription = item.MainActivityDescription,
                        Sequence = item.Sequence,
                        OrgId = item.Org_Id,
                        Status = item.Status,
                        IsDeleted = item.Is_Deleted
                    });
                });
            }
            return lstmainActivityMasterModel;
        }

        public async Task<MainActivityMasterViewModel> SaveMainActivityMasterDetails(MainActivityMasterViewModel mainActivityMasterViewModel)
        {
            MainActivityMaster mainActivity = new MainActivityMaster()
            {
                Group_Id = mainActivityMasterViewModel.GroupId,
                Main_Activity_Name = mainActivityMasterViewModel.MainActivityName,
                Org_Id = mainActivityMasterViewModel.OrgId,
                Sequence = mainActivityMasterViewModel.Sequence,
                Status = mainActivityMasterViewModel.Status,
                Is_Deleted = mainActivityMasterViewModel.IsDeleted,
                MainActivityDescription = mainActivityMasterViewModel.MainActivityDescription,
                Main_Activity_Code = mainActivityMasterViewModel.MainActivityCode,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var mainActivityMaster = await _mainActivityMasterDetailsHelper.CreateAsync(mainActivity);
            MainActivityMasterViewModel mainActivityMastersViewModel = new MainActivityMasterViewModel()
            {
                MainActivityId = mainActivityMaster.Main_Activity_Id
            };

            return mainActivityMastersViewModel;
        }

        public async Task<MainActivityMasterViewModel> UpdateMainActivityMasterDetails(MainActivityMasterViewModel mainActivityMasterViewModel)
        {
            MainActivityMaster mainActivity = new MainActivityMaster()
            {
                Main_Activity_Id = mainActivityMasterViewModel.MainActivityId,
                Main_Activity_Code= mainActivityMasterViewModel.MainActivityCode,
                Group_Id = mainActivityMasterViewModel.GroupId,
                Main_Activity_Name = mainActivityMasterViewModel.MainActivityName,
                Org_Id = mainActivityMasterViewModel.OrgId,
                Sequence = mainActivityMasterViewModel.Sequence,
                Status = mainActivityMasterViewModel.Status,
                Is_Deleted = mainActivityMasterViewModel.IsDeleted,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var mainActivityMaster = await _mainActivityMasterDetailsHelper.UpdateAsync(mainActivity);
            MainActivityMasterViewModel mainActivityMastersViewModel = new MainActivityMasterViewModel()
            {
                MainActivityId = mainActivityMaster.Main_Activity_Id
            };
            return mainActivityMastersViewModel;
        }
    }
}
