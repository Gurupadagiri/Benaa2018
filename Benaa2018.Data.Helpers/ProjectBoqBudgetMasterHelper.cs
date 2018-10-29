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
    public class ProjectBoqBudgetMasterHelper : IProjectBoqBudgetMasterHelper
    {
            private readonly IProjectPlaningRepository _projectPlaningMasterRepository;
            private readonly IProjectBoqBudgetMasterRepository _projectBoqBugetMasterRepository;
        private readonly IMainActivityMasterRepository _mainActivityMasterRepository;
        private readonly IActivityMasterHelper _activityMasterHelper;
        public ProjectBoqBudgetMasterHelper(IProjectPlaningRepository projectPlaningMasterRepository,
            IProjectBoqBudgetMasterRepository projectBoqBugetMasterRepository,IMainActivityMasterRepository mainActivityMasterRepository, IActivityMasterHelper activityMasterHelper)
        {
            _projectPlaningMasterRepository = projectPlaningMasterRepository;
            _projectBoqBugetMasterRepository = projectBoqBugetMasterRepository;
            _mainActivityMasterRepository = mainActivityMasterRepository;
            _activityMasterHelper = activityMasterHelper;
        }

        /// <summary>
        ///  Get All Internal Users and Projects By ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<ProjectBoqBudgetMasterViewModel>> GetAllRecords()
        {
            List<ProjectBoqBudgetMasterViewModel> lstProjectBoqBudgetMasterModel = new List<ProjectBoqBudgetMasterViewModel>();
            var projectBoqBudgetInfo = await _projectBoqBugetMasterRepository.GetAllAsync();
            var projectPlaningInfo = await _projectPlaningMasterRepository.GetAllAsync();
            
            //IEnumerable<MainActivityMaster> lstMainActivity = null;
            //if (projectId != 0)
            //{
            //    lstMainActivity = await _mainActivityMasterRepository.GetAllAsync();
            //    lstMainActivity = lstMainActivity.Where(a => a.Main_Activity_Id==1).ToList();
            //}

            if(projectBoqBudgetInfo==null)
            {

                projectPlaningInfo.ToList().ForEach(item =>
                {
                    lstProjectBoqBudgetMasterModel.Add(new ProjectBoqBudgetMasterViewModel
                    {
                        Project_Boq_ID = 0,
                        MainActivity_ID = item.MainActivity_ID,
                        Org_ID = item.Org_ID,
                        Project_ID = item.Project_ID,
                        Activity_ID = item.Activity_ID
                    
                        //FullName = item.FullName,
                        //UserID = item.UserID,
                        //UserName = item.UserName,
                        //JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
                        //ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
                        //ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
                        //OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
                    });
                });
            }
            else
            {
                var activityMasterModels = await _activityMasterHelper.GetAllActivityMasterDetails();

                projectBoqBudgetInfo.Where(x => x.Status == false).ToList().ForEach(item =>
                    {
                        lstProjectBoqBudgetMasterModel.Add(new ProjectBoqBudgetMasterViewModel
                        {
                            Project_Boq_ID = item.Project_Boq_ID,
                            MainActivity_ID = item.MainActivity_ID,
                            Org_ID = item.Org_ID,
                            Project_ID = item.Project_ID,
                            Activity_ID = item.Activity_ID,
                            Unit_ID = item.Unit_ID,
                            Title = item.Title,
                            Description = item.Description,
                            Quantity = item.Quantity,
                            ActivityMasterModels = activityMasterModels.Where(x => x.MainActivityId == item.MainActivity_ID).ToList(),
                            Unit_Cost = item.Unit_Cost,
                            Execution_Cost = item.Execution_Cost,
                            Tax_ID = item.Tax_ID,
                            Tax_Value = item.Tax_Value,
                            Tax_Percentage = item.Tax_Percentage,
                            Tax_Cost = item.Tax_Cost,
                            Total_Builder_Cost = item.Total_Builder_Cost,
                            Markup_ID = item.Markup_ID,
                            Markup_Value = item.Markup_Value,
                            Markup_Percentage = item.Markup_Percentage,
                            Total_Markup = item.Total_Markup,
                            steakholder_Price = item.Steakholder_Price,
                            Notes = item.Notes,
                            IsBudget_Updated=item.IsBudget_Updated
                           
                            //  ActivityMasterModels= activityMasterModels
                            //FullName = item.FullName,
                            //UserID = item.UserID,
                            //UserName = item.UserName,
                            //JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
                            //ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
                            //ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
                            //OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
                        });
                    });
            }
            
            return lstProjectBoqBudgetMasterModel;
        }
        //    /// <summary>
        //    ///  Get All Internal Users and Projects By ID
        //    /// </summary>
        //    /// <param name="projectId"></param>
        //    /// <returns></returns>
        //    public async Task<List<UserMasterViewModel>> GetInternalUserByName(int companyId, string name, string status= "")
        //    {
        //        List<UserMasterViewModel> lstUserMasterModel = new List<UserMasterViewModel>();
        //        var userInfo = await _userMasterRepository.GetAllAsync();
        //        IEnumerable<ProjectUserIntConfigMaster> lstProjectUser = null;
        //        if (name != string.Empty || status != string.Empty)
        //        {
        //            lstProjectUser = await _projectUserIntConfigMasterRepository.GetAllAsync();
        //        }
        //        if (companyId != 0)
        //        {
        //            lstProjectUser = lstProjectUser.Where(a => a.Org_ID == companyId).ToList();
        //        }            
        //        if (name != string.Empty)
        //        {
        //            userInfo = userInfo.Where(a => a.UserName.ToLower().Contains(name)).ToList();
        //        }
        //        if (status != null && status != string.Empty)
        //        {
        //            lstProjectUser = lstProjectUser.Where(a => a.View_Access == Convert.ToBoolean(status)).ToList();
        //        }
        //        userInfo.ToList().ForEach(item =>
        //        {
        //            lstUserMasterModel.Add(new UserMasterViewModel
        //            {
        //                FullName = item.FullName,
        //                UserID = item.UserID,
        //                UserName = item.UserName,
        //                JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
        //                ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
        //                ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
        //                OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
        //            });
        //        });
        //        return lstUserMasterModel;
        //    }
        //    public async Task<List<UserMasterViewModel>> GetUserByUserName(string userName)
        //    {
        //        List<UserMasterViewModel> lstUserMasterModel = new List<UserMasterViewModel>();
        //        IEnumerable<UserMaster> lstUserMaster = null;
        //        lstUserMaster = await _userMasterRepository.GetAllAsync();
        //        lstUserMaster = lstUserMaster.Where(a => a.UserName == userName).ToList();
        //        if(lstUserMaster!=null)
        //        {
        //            foreach(var item in lstUserMaster)
        //            { 
        //                lstUserMasterModel.Add(new UserMasterViewModel
        //                {
        //                    UserName=item.UserName,
        //                    UserPassword=item.Password
        //                });
        //            }
        //        }
        //        return lstUserMasterModel;
        //    }

        public async Task<ProjectBoqBudgetMasterViewModel> GetBoqListByActivityId(int activityId)
        {
            ProjectBoqBudgetMasterViewModel projectBoqBudgetInfo = new ProjectBoqBudgetMasterViewModel();
            var projectBoqBudgetMasterViewModel = await _projectBoqBugetMasterRepository.GetByIdAsync(activityId);
            if (projectBoqBudgetMasterViewModel != null)
            {
                projectBoqBudgetInfo = new ProjectBoqBudgetMasterViewModel
                {
                    Project_Boq_ID=projectBoqBudgetMasterViewModel.Project_Boq_ID,
                    Project_ID = projectBoqBudgetMasterViewModel.Project_ID,
                    MainActivity_ID = projectBoqBudgetMasterViewModel.MainActivity_ID,
                    Activity_ID = projectBoqBudgetMasterViewModel.Activity_ID,
                    Title = projectBoqBudgetMasterViewModel.Title,
                    Description = projectBoqBudgetMasterViewModel.Description,
                    Unit_ID = projectBoqBudgetMasterViewModel.Unit_ID,
                    Unit_Cost = projectBoqBudgetMasterViewModel.Unit_Cost,
                    Org_ID = projectBoqBudgetMasterViewModel.Org_ID,
                    Quantity = projectBoqBudgetMasterViewModel.Quantity,
		    Execution_Cost = projectBoqBudgetMasterViewModel.Execution_Cost,
                    Tax_ID = projectBoqBudgetMasterViewModel.Tax_ID,
                    Tax_Value = projectBoqBudgetMasterViewModel.Tax_Value,
                    Tax_Percentage = projectBoqBudgetMasterViewModel.Tax_Percentage,
                    Tax_Cost = projectBoqBudgetMasterViewModel.Tax_Cost,
                    Total_Builder_Cost = projectBoqBudgetMasterViewModel.Total_Builder_Cost,
                    Markup_ID = projectBoqBudgetMasterViewModel.Markup_ID,
                    Markup_Value = projectBoqBudgetMasterViewModel.Markup_Value,
                    Markup_Percentage = projectBoqBudgetMasterViewModel.Markup_Percentage,
                    Total_Markup = projectBoqBudgetMasterViewModel.Total_Markup,
                    steakholder_Price = projectBoqBudgetMasterViewModel.Steakholder_Price,
                    Notes = projectBoqBudgetMasterViewModel.Notes
                   

                };
            }
            return projectBoqBudgetInfo;
        }

        //    public async Task SaveUserMaterConfig(int orgId, int projectID, List<UserMasterViewModel> lstUserMasterModel)
        //    {
        //        foreach (var item in lstUserMasterModel)
        //        {
        //            ProjectUserIntConfigMaster userConfig = new ProjectUserIntConfigMaster
        //            {
        //                Org_ID = orgId,
        //                Project_ID = projectID,
        //                Recive_Notification = item.JobNotification,
        //                UserID = item.UserID,
        //                View_Access = item.ViewAccess
        //            };
        //            await _projectUserIntConfigMasterRepository.CreateAsync(userConfig);
        //        }

        //    }

        public async Task<bool> UpdateProjectBoqBudgetConfig(ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel)
        {
            try
            {
                var projectBoqBudgetMaster = await _projectBoqBugetMasterRepository.GetByIdAsync(projectBoqBudgetMasterViewModel.Project_Boq_ID);
                //projectBoqBudgetMaster.Project_Boq_ID = projectBoqBudgetMasterViewModel.Project_Boq_ID;
                //projectBoqBudgetMaster.Project_ID = projectBoqBudgetMasterViewModel.Project_ID;
                //projectBoqBudgetMaster.MainActivity_ID = projectBoqBudgetMasterViewModel.MainActivity_ID;
                //projectBoqBudgetMaster.Activity_ID = projectBoqBudgetMasterViewModel.Activity_ID;
                //projectBoqBudgetMaster.Title = projectBoqBudgetMasterViewModel.Title;
                //projectBoqBudgetMaster.Description = projectBoqBudgetMasterViewModel.Description;
                //projectBoqBudgetMaster.Unit_ID = projectBoqBudgetMasterViewModel.Unit_ID;
                //projectBoqBudgetMaster.Tax_ID = projectBoqBudgetMasterViewModel.Tax_ID;
                //projectBoqBudgetMaster.Org_ID = projectBoqBudgetMasterViewModel.Org_ID;
                //projectBoqBudgetMaster.Quantity = projectBoqBudgetMasterViewModel.Quantity;
                projectBoqBudgetMaster.Unit_Cost = projectBoqBudgetMasterViewModel.Unit_Cost;
                projectBoqBudgetMaster.Execution_Cost = projectBoqBudgetMasterViewModel.Execution_Cost;
                projectBoqBudgetMaster.Markup_Percentage = projectBoqBudgetMasterViewModel.Markup_Percentage;
                projectBoqBudgetMaster.Markup_Value = projectBoqBudgetMasterViewModel.Markup_Value;
                projectBoqBudgetMaster.Steakholder_Price = projectBoqBudgetMasterViewModel.steakholder_Price;
                projectBoqBudgetMaster.Tax_Cost = projectBoqBudgetMasterViewModel.Tax_Cost;
                projectBoqBudgetMaster.Tax_Percentage = projectBoqBudgetMasterViewModel.Tax_Percentage;
                projectBoqBudgetMaster.Tax_Unit = projectBoqBudgetMasterViewModel.Tax_Unit;
                projectBoqBudgetMaster.Tax_Value = projectBoqBudgetMasterViewModel.Tax_Value;
                projectBoqBudgetMaster.Total_Builder_Cost = projectBoqBudgetMasterViewModel.Total_Builder_Cost;
                projectBoqBudgetMaster.Total_Markup = projectBoqBudgetMasterViewModel.Total_Markup;
                projectBoqBudgetMaster.Status = projectBoqBudgetMasterViewModel.Status;
                projectBoqBudgetMaster.Notes = projectBoqBudgetMasterViewModel.Notes;
                projectBoqBudgetMaster.IsBudget_Updated = true;
                await _projectBoqBugetMasterRepository.UpdateAsync(projectBoqBudgetMaster);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProjectBoqBudgetMasterViewModel> SavePorjectBOQMaster(ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel)
        {
            ProjectBoqBudgetMaster projectBoqConfig = new ProjectBoqBudgetMaster
            {
                Project_ID = projectBoqBudgetMasterViewModel.Project_ID,
                MainActivity_ID = projectBoqBudgetMasterViewModel.MainActivity_ID,
                Activity_ID = projectBoqBudgetMasterViewModel.Activity_ID,
                Title = projectBoqBudgetMasterViewModel.Title,
                Description = projectBoqBudgetMasterViewModel.Description,
                Unit_ID = projectBoqBudgetMasterViewModel.Unit_ID,
                Unit_Cost = projectBoqBudgetMasterViewModel.Unit_Cost,
                Tax_ID = projectBoqBudgetMasterViewModel.Tax_ID,
                Org_ID = projectBoqBudgetMasterViewModel.Org_ID,
                Quantity = projectBoqBudgetMasterViewModel.Quantity,
                //User_First_Name = userMasterViewModel.UserFirstName,
                //User_Last_Name = userMasterViewModel.UserLastName,
                //User_Email = userMasterViewModel.UserEmail,
                //User_Enabled = userMasterViewModel.UserEnabled,
                //User_Login_Enabled = userMasterViewModel.UserLoginEnabled,
                //User_Phone = userMasterViewModel.UserPhone,
                //User_Cell_Email = userMasterViewModel.UserCellEmail,
                //User_Contact_Info = userMasterViewModel.UserContactInfo,
                //User_Default_Time_Clock = userMasterViewModel.UserDefaultTimeClock,
                //User_Default_Labour_Cost = userMasterViewModel.UserDefaultLabourCost,
                //User_Is_Alert = userMasterViewModel.UserIsAlert,
                //User_Alert_Schedule = userMasterViewModel.UserAlertSchedule,
                //User_Is_Automatic_Access = userMasterViewModel.UserIsAutomaticAccess,
                //UserName = userMasterViewModel.UserName,
                //Password = userMasterViewModel.UserPassword,
                //User_Is_Forum_Handle = userMasterViewModel.UserIsForumHandle,
                //User_Forum_Handle = userMasterViewModel.UserForumHandle,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today,
                Status = false,
                IsBudget_Updated=false

            };
            var projectBoqBudgetObj = await _projectBoqBugetMasterRepository.CreateAsync(projectBoqConfig);
            ProjectBoqBudgetMasterViewModel projectBoqBudgetMasterViewModel1 = new ProjectBoqBudgetMasterViewModel
            {
                Project_Boq_ID = projectBoqBudgetObj.Project_Boq_ID
            };

            return projectBoqBudgetMasterViewModel1;
        }

        public async Task<bool> DeleteProjectBoqBudgetByProjectBoqId(int projectBoqId)
        {
            try
            {
                var projectBoqBudgetMasterViewModel = await _projectBoqBugetMasterRepository.GetByIdAsync(projectBoqId);
                projectBoqBudgetMasterViewModel.Status = true;
                await _projectBoqBugetMasterRepository.UpdateAsync(projectBoqBudgetMasterViewModel);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        //    public async Task<List<UserMasterViewModel>> GetFullUserName()
        //    {
        //        List<UserMasterViewModel> lstUserMasterModel = new List<UserMasterViewModel>();
        //        IEnumerable<UserMaster> lstUserMaster = null;
        //        lstUserMaster = await _userMasterRepository.GetAllAsync();

        //        if (lstUserMaster != null)
        //        {
        //            foreach (var item in lstUserMaster)
        //            {
        //                lstUserMasterModel.Add(new UserMasterViewModel
        //                {
        //                    UserID = item.UserID,
        //                    FullName = item.FullName != null ? item.FullName : string.Empty

        //                });
        //            }
        //        }
        //        return lstUserMasterModel;
        //    }
    }
}
