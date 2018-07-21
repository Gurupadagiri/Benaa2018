using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class UserMasterHelper : IUserMasterHelper
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly IProjectUserIntConfigMasterRepository _projectUserIntConfigMasterRepository;
        public UserMasterHelper(IUserMasterRepository userMasterRepository,
            IProjectUserIntConfigMasterRepository projectUserIntConfigMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
            _projectUserIntConfigMasterRepository = projectUserIntConfigMasterRepository;
        }

        /// <summary>
        ///  Get All Internal Users and Projects By ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<UserMasterViewModel>> GetAllInternalUsers(int projectId = 0)
        {
            List<UserMasterViewModel> lstUserMasterModel = new List<UserMasterViewModel>();
            var userInfo = await _userMasterRepository.GetAllAsync();
            IEnumerable<ProjectUserIntConfigMaster> lstProjectUser = null;
            if (projectId != 0)
            {
                lstProjectUser = await _projectUserIntConfigMasterRepository.GetAllAsync();
                lstProjectUser = lstProjectUser.Where(a => a.Project_ID == projectId).ToList();
            }
            userInfo.ToList().ForEach(item =>
            {
                lstUserMasterModel.Add(new UserMasterViewModel
                {
                    FullName = item.FullName,
                    UserID = item.UserID,
                    UserName = item.UserName,
                    JobNotification = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Recive_Notification).FirstOrDefault() : false,
                    ViewAccess = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.View_Access).FirstOrDefault() : false,
                    ProjectID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Project_ID).FirstOrDefault() : 0,
                    OrgID = lstProjectUser != null ? lstProjectUser.Where(a => a.UserID == item.UserID).Select(a => a.Org_ID).FirstOrDefault() : 0,
                });
            });
            return lstUserMasterModel;
        }

        public async Task<List<UserMasterViewModel>> GetUserByUserName(string userName)
        {
            List<UserMasterViewModel> lstUserMasterModel = new List<UserMasterViewModel>();
            IEnumerable<UserMaster> lstUserMaster = null;
            lstUserMaster = await _userMasterRepository.GetAllAsync();
            lstUserMaster = lstUserMaster.Where(a => a.UserName == userName).ToList();
            if(lstUserMaster!=null)
            {
                foreach(var item in lstUserMaster)
                { 
                    lstUserMasterModel.Add(new UserMasterViewModel
                    {
                        UserName=item.UserName,
                        UserPassword=item.Password
                    });
                }
            }
            return lstUserMasterModel;
        }

        public async Task<UserMasterViewModel> GetUserByUserId(int userId)
        {
            UserMasterViewModel userInfo = new UserMasterViewModel();
            var user = await _userMasterRepository.GetByIdAsync(userId);
            if (user != null)
            {
                userInfo = new UserMasterViewModel
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    CreatdDate = user.Created_Date
                };
            }
            return userInfo;
        }

        public async Task SaveUserMaterConfig(int orgId, int projectID, List<UserMasterViewModel> lstUserMasterModel)
        {
            foreach (var item in lstUserMasterModel)
            {
                ProjectUserIntConfigMaster userConfig = new ProjectUserIntConfigMaster
                {
                    Org_ID = orgId,
                    Project_ID = projectID,
                    Recive_Notification = item.JobNotification,
                    UserID = item.UserID,
                    View_Access = item.ViewAccess
                };
                await _projectUserIntConfigMasterRepository.CreateAsync(userConfig);
            }

        }

        public async Task UpdateUserMaterConfig(int projectID, List<UserMasterViewModel> lstUserMasterModel)
        {
            foreach (var item in lstUserMasterModel)
            {
                var projetUser = await _projectUserIntConfigMasterRepository.GetAllAsync();
                var projetUserInfo = projetUser.Where(a => a.UserID == item.UserID && a.Project_ID == projectID).FirstOrDefault();
                if (projetUser != null)
                {
                    projetUserInfo.Recive_Notification = item.JobNotification;
                    projetUserInfo.View_Access = item.ViewAccess;
                    await _projectUserIntConfigMasterRepository.UpdateAsync(projetUserInfo);
                }
            }
        }

        public async Task<UserMasterViewModel> SaveUserMaster(UserMasterViewModel userMasterViewModel)
        {
            UserMaster userConfig = new UserMaster
            {
                User_First_Name = userMasterViewModel.UserFirstName,
                User_Last_Name = userMasterViewModel.UserLastName,
                User_Email = userMasterViewModel.UserEmail,
                User_Enabled = userMasterViewModel.UserEnabled,
                User_Login_Enabled = userMasterViewModel.UserLoginEnabled,
                User_Phone = userMasterViewModel.UserPhone,
                User_Cell_Email = userMasterViewModel.UserCellEmail,
                User_Contact_Info = userMasterViewModel.UserContactInfo,
                User_Default_Time_Clock = userMasterViewModel.UserDefaultTimeClock,
                User_Default_Labour_Cost = userMasterViewModel.UserDefaultLabourCost,
                User_Is_Alert = userMasterViewModel.UserIsAlert,
                User_Alert_Schedule = userMasterViewModel.UserAlertSchedule,
                User_Is_Automatic_Access = userMasterViewModel.UserIsAutomaticAccess,
                UserName = userMasterViewModel.UserName,
                Password = userMasterViewModel.UserPassword,
                User_Is_Forum_Handle = userMasterViewModel.UserIsForumHandle,
                User_Forum_Handle = userMasterViewModel.UserForumHandle,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var userObj = await _userMasterRepository.CreateAsync(userConfig);
            UserMasterViewModel userMasterViewModel1 = new UserMasterViewModel
            {
                UserID = Convert.ToInt32(userObj.UserID)
            };

            return userMasterViewModel1;
        }
    }
}
