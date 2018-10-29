using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benaa2018.Helper.Interface;
namespace Benaa2018.Helper
{
    public class TaxMasterHelper :ITaxMasterHelper
    {
        /// <summary>
        ///  Get All Internal Users and Projects By ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<TaxMasterViewModel>> GetAllRecords(int projectId = 0)
        {
            List<TaxMasterViewModel> lstTaxMasterViewModel = new List<TaxMasterViewModel>();

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

            return lstTaxMasterViewModel;
        }

    }
}
