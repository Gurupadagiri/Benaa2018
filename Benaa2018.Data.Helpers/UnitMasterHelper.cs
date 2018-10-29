using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
   public class UnitMasterHelper : IUnitMasterHelper
    {

        private readonly IUnitMasterRepository _unitMasterRepository;
        public UnitMasterHelper(IUnitMasterRepository unitMasterRepository)
       {
            _unitMasterRepository = unitMasterRepository;
        }

        /// <summary>
        ///  Get All Unit based on 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<UnitMasterViewModel>> GetAllRecords(int projectId = 0)
        {
            // List<UnitMasterViewModel> lstUnitMasterViewModel = new List<UnitMasterViewModel>();
            //var unitMaster = await _unitMasterRepository.GetAllAsync();
            // //unitMaster = unitMaster.Where(a => a.Status == true).ToList();
            // unitMaster.ToList().ForEach(item =>
            // {

            //     lstUnitMasterViewModel.Add(new UnitMasterViewModel
            //     {

            //         Unit_id = item.Unit_id,
            //         Unit_Name = item.Unit_Name,
            //         Description = item.Description,
            //         Orgid = item.Orgid,
            //         Status = item.Status,
            //    });
            // });
            // return lstUnitMasterViewModel;


            List<UnitMasterViewModel> lstUnitMasterViewModel = new List<UnitMasterViewModel>();
            IEnumerable<UnitMaster> lstunitMaster = null;
            lstunitMaster = await _unitMasterRepository.GetAllAsync();

            if (lstunitMaster != null)
            {
                foreach (var item in lstunitMaster.Where(a => !string.IsNullOrEmpty(a.Unit_Name)))
                {
                    lstUnitMasterViewModel.Add(new UnitMasterViewModel
                    {
                        Unit_id = item.Unit_id,
                        Unit_Name = item.Unit_Name
                    });
                }
            }
            return lstUnitMasterViewModel;


            //var projectBoqBudgetInfo = await _projectBoqBugetMasterRepository.GetAllAsync();
            //var projectPlaningInfo = await _projectPlaningMasterRepository.GetAllAsync();

            //IEnumerable<MainActivityMaster> lstMainActivity = null;
            //if (projectId != 0)
            //{
            //    lstMainActivity = await _mainActivityMasterRepository.GetAllAsync();
            //    lstMainActivity = lstMainActivity.Where(a => a.Main_Activity_Id == 1).ToList();
            //}

            //if (projectBoqBudgetInfo == null)
            //{

            //    projectPlaningInfo.ToList().ForEach(item =>
            //    {
            //        lstProjectBoqBudgetMasterModel.Add(new ProjectBoqBudgetMasterViewModel
            //        {
            //            Project_Boq_ID = 1,
            //            MainActivity_ID = item.MainActivity_ID,
            //            Org_ID = item.Org_ID,
            //            Project_ID = item.Project_ID,
            //            Activity_ID = item.Activity_ID

            //            //FullName = item.FullName,
            //            //UserID = item.UserID,
            //            //UserName = item.UserName,
            //            //JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
            //            //ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
            //            //ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
            //            //OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
            //        });
            //    });
            //}
            //else
            //{
            //    var activityMasterModels = await _activityMasterHelper.GetAllActivityMasterDetails();

            //    projectBoqBudgetInfo.ToList().ForEach(item =>
            //    {
            //        lstProjectBoqBudgetMasterModel.Add(new ProjectBoqBudgetMasterViewModel
            //        {
            //            Project_Boq_ID = item.Project_Boq_ID,
            //            MainActivity_ID = item.MainActivity_ID,
            //            Org_ID = item.Org_ID,
            //            Project_ID = item.Project_ID,
            //            Activity_ID = item.Activity_ID,
            //            Unit_ID = item.Unit_ID,
            //            Title = item.Title,
            //            Description = item.Description,
            //            Quantity = item.Quantity,
            //            ActivityMasterModels = activityMasterModels.Where(x => x.MainActivityId == item.MainActivity_ID).ToList(),
            //            //  ActivityMasterModels= activityMasterModels
            //            //FullName = item.FullName,
            //            //UserID = item.UserID,
            //            //UserName = item.UserName,
            //            //JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
            //            //ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
            //            //ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
            //            //OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
            //        });
            //    });
            //}

            return lstUnitMasterViewModel;
        }
    }
}
