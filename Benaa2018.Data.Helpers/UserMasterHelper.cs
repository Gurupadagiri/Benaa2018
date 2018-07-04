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
        public UserMasterHelper(IUserMasterRepository userMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
        }
        public UserMasterHelper(IProjectUserIntConfigMasterRepository projectUserIntConfigMasterRepository)
        {
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
                lstProjectUser = lstProjectUser. Where(a => a.Project_ID == projectId).ToList();
            }
            userInfo.ToList().ForEach(item =>
            {
                lstUserMasterModel.Add(new UserMasterViewModel
                {
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

        public async Task<LoginViewModel> GetUserByUserName(string userName)
        {
            LoginViewModel userInfo = new LoginViewModel();
            var user = await _userMasterRepository.GetAllAsync();
            user = user.Where(a => a.UserName == userName);
            if (user != null)
            {
                userInfo = new LoginViewModel
                {
                    UserId = user.FirstOrDefault().UserID,
                    Password = user.FirstOrDefault().Password,
                    UserName = user.FirstOrDefault().UserName
                };
            }
            return userInfo;
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

        public async Task SaveUserMaterConfig(int orgId,int projectID, List<UserMasterViewModel> lstUserMasterModel)
        {
            foreach (var item in lstUserMasterModel)
            {
                ProjectUserIntConfigMaster userConfig = new ProjectUserIntConfigMaster
                {
                    Org_ID = orgId,
                    Project_ID = projectID,
                    Recive_Notification = item.JobNotification,
                    UserID = item.UserID,
                    View_Access= item.ViewAccess
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
    }
}
