using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ProjectGroupHelper : IProjectGroupHelper
    {
        IProjectGroupRepository _projectGroupRepository;

        public ProjectGroupHelper(IProjectGroupRepository projectGroupRepository)
        {
            _projectGroupRepository = projectGroupRepository;
        }

        public async Task<int> SaveProjectGroup(int userId, string projectGroupName)
        {
            ProjectGroup projectGroup = new ProjectGroup
            {
                Project_Group_Name = projectGroupName,
                User_ID = userId
            };
            var projectGroupInfo = await _projectGroupRepository.CreateAsync(projectGroup);
            return projectGroupInfo.Project_Goup_ID;
        }

        public async Task<List<ProjectGroupViewModel>> GetProjectGroupByUserID(int userID)
        {
            List<ProjectGroupViewModel> lstProjectGroup = new List<ProjectGroupViewModel>();
            var projectGroup = await Task.Factory.StartNew(() => _projectGroupRepository.GetAllAsync().Result.Where(a => a.User_ID == userID).ToList());
            projectGroup.ForEach(item => {
                lstProjectGroup.Add(new ProjectGroupViewModel
                {
                    ProjectGroupID = item.Project_Goup_ID,
                    ProjectGroupName = item.Project_Group_Name,
                    UserID = item.User_ID
                });
            });
            return lstProjectGroup;
        }
    }
}
