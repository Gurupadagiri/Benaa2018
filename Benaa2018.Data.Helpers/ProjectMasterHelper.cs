using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Data.Repository;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ProjectMasterHelper : IProjectMasterHelper
    {
        IProjectMasterRepository _projectMasterRepository;
        IProjectManagerMasterRepository _projectManagerMasterRepoisitory;
        IProjectScheduleMasterHelper _projectScheduleMasterHelper;
        IOwnerMasterHelper _ownerMasterHelper;
        IProjectTypeMasterRepository _projectTypeMasterRepository;
        
        public ProjectMasterHelper(IProjectMasterRepository projectMasterRepository,
            IProjectManagerMasterRepository projectManagerMasterRepoisitory,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectTypeMasterRepository projectTypeMasterRepository,
            IProjectGroupRepository projectGroupRepository)
        {
            _projectMasterRepository = projectMasterRepository;
            _projectManagerMasterRepoisitory = projectManagerMasterRepoisitory;
            _projectScheduleMasterHelper = projectScheduleMasterHelper;
            _ownerMasterHelper = ownerMasterHelper;
            _projectTypeMasterRepository = projectTypeMasterRepository;
        }
        public async Task<int> SaveProjectMaster(int userId, ProjectMasterViewModel projectMasterModel)
        {
            ProjectMaster projectMaster = new ProjectMaster
            {
                User_ID = userId,
                Project_Name = projectMasterModel.ProjectName,
                Address = projectMasterModel.StreetAddress,
                Latitude= projectMasterModel.Latitude,
                Longitude = projectMasterModel.Longitude,
                City = projectMasterModel.City,
                Status_ID = projectMasterModel.ProjectStatusID,
                Project_Type_ID = projectMasterModel.ProjectTypeID,
                Project_Manager_id = projectMasterModel.ProjectManagerID,
                Project_Group_ID = projectMasterModel.ProjectGroupID,
                State = projectMasterModel.State,
                Zip = projectMasterModel.Zip,
                Internal_Notes= projectMasterModel.InternalNotes,
                Lot_Info= projectMasterModel.LotInfo,
                Sub_Notes = projectMasterModel.SubNotes,
                Project_Prefix= projectMasterModel.JobsitePrefix,
                Country_ID = projectMasterModel.CountryID,
                Org_ID = projectMasterModel.OrgID,
                Contract_Price = projectMasterModel.ContractPrice
            };
            projectMaster = await _projectMasterRepository.CreateAsync(projectMaster);
            return projectMaster.Project_ID;
        }

        public async Task<int> UpdateProjectMaster(int userID, ProjectMasterViewModel projectMasterModel)
        {
            ProjectMaster projectMaster = new ProjectMaster
            {
                Project_ID = projectMasterModel.ProjectID,
                User_ID = userID,
                Project_Name = projectMasterModel.ProjectName,
                Address = projectMasterModel.StreetAddress,
                City = projectMasterModel.City,
                Status_ID = projectMasterModel.ProjectStatusID,
                Project_Type_ID = projectMasterModel.ProjectTypeID,
                Project_Manager_id = projectMasterModel.ProjectManagerID,
                Project_Group_ID = projectMasterModel.ProjectGroupID,
                State = projectMasterModel.State,
                Zip = projectMasterModel.Zip,
                Internal_Notes = projectMasterModel.InternalNotes,
                Lot_Info = projectMasterModel.LotInfo,
                Sub_Notes = projectMasterModel.SubNotes,
                Project_Prefix = projectMasterModel.JobsitePrefix,
                Country_ID = projectMasterModel.CountryID,
                Org_ID = projectMasterModel.OrgID,
                Contract_Price = projectMasterModel.ContractPrice
            };
            projectMaster = await _projectMasterRepository.UpdateAsync(projectMaster);
            return projectMaster.Project_ID;
        }

        public async Task<List<ProjectMasterViewModel>> GetAllProjectByUserId(int userId)
        {
            List<ProjectMasterViewModel> lstProjectScheduleMaster = new List<ProjectMasterViewModel>();
            var projectSchedules = _projectMasterRepository.GetProjectByUserID(userId).Result.Where(a=>a.Project_Name != null).ToList();
            foreach(var item in projectSchedules)
            {
                lstProjectScheduleMaster.Add(new ProjectMasterViewModel
                {
                    ProjectID = item.Project_ID,
                    City = item.City,
                    ContractPrice = item.Contract_Price,
                    InternalNotes = item.Internal_Notes,
                    JobsitePrefix = item.Project_Prefix,
                    LotInfo = item.Lot_Info,
                    Permit = item.Permit_No,
                    ProjectGroupID = item.Project_Group_ID,
                    ProjectManagerID = item.Project_Manager_id,
                    ProjectName = item.Project_Name,
                    ProjectStatusID = item.Status_ID,
                    ProjectTypeID = item.Project_Type_ID,
                    State = item.State,
                    StreetAddress = item.Address,
                    SubNotes = item.Sub_Notes,
                    UserID = item.User_ID,
                    Zip = item.Zip,
                    ProjectScheduleMasterModel = await _projectScheduleMasterHelper.GetProjectScheduleByProjectID(item.Project_ID).ConfigureAwait(true),
                    OwnerMasterModel = await _ownerMasterHelper.GetOwnerInfoByInfo(item.Project_ID).ConfigureAwait(true),
                    OrgID = Convert.ToInt32(item.Org_ID),
                    Latitude= item.Latitude,
                    Longitude= item.Longitude
                });
            }            
            return lstProjectScheduleMaster;
        }

        public async Task<ProjectMasterViewModel> GetProjectDetailsProjectId(int projectId)
        {
            var projectSchedules = await _projectMasterRepository.GetByIdAsync(projectId);
            return projectSchedules != null ? new ProjectMasterViewModel
            {
                ProjectID = projectSchedules.Project_ID,
                City = projectSchedules.City,
                ContractPrice = projectSchedules.Contract_Price,
                InternalNotes = projectSchedules.Internal_Notes,
                JobsitePrefix = projectSchedules.Project_Prefix,
                LotInfo = projectSchedules.Lot_Info,
                Permit = projectSchedules.Permit_No,
                ProjectGroupID = projectSchedules.Project_Group_ID,
                ProjectManagerID = projectSchedules.Project_Manager_id,
                ProjectName = projectSchedules.Project_Name,
                ProjectStatusID = projectSchedules.Status_ID,
                ProjectTypeID = projectSchedules.Project_Type_ID,
                State = projectSchedules.State,
                StreetAddress = projectSchedules.Address,
                SubNotes = projectSchedules.Sub_Notes,
                UserID = projectSchedules.User_ID,
                Zip = projectSchedules.Zip,
                ProjectScheduleMasterModel = await _projectScheduleMasterHelper.GetProjectScheduleByProjectID(projectSchedules.Project_ID),
                OwnerMasterModel = await _ownerMasterHelper.GetOwnerInfoByInfo(projectSchedules.Project_ID),
                OrgID = Convert.ToInt32(projectSchedules.Org_ID)
            } : new ProjectMasterViewModel();
        }

        public async Task<string> GetNameByProjectId(int projectId)
        {
            var projectSchedules = await _projectMasterRepository.GetByIdAsync(projectId);
            return projectSchedules != null
                ? projectSchedules.Project_Name
             : string.Empty;
        }

        public async Task<List<ProjectMasterViewModel>> FilterProjectInfo(string[] projectGroupIds, string[] managersIds)
        {
            List<ProjectMasterViewModel> lstProjectMaster = new List<ProjectMasterViewModel>();
            var projectInfo = await _projectMasterRepository.GetAllAsync();
            if (projectInfo == null) return new List<ProjectMasterViewModel>();
            if (projectGroupIds.Length > 0 || managersIds.Length > 0)
            {
                var filteredProjectInfo = projectInfo.Join(
                     projectGroupIds.ToList(),
                    a => a.Project_Group_ID,
                    b => b,
                    (a, b) => new { a = a }).ToList()
                    .Join(
                     managersIds.ToList(),
                    c => c.a.Project_Manager_id,
                    d => d,
                    (c, d) => new { c = c }).ToList();
                if (filteredProjectInfo != null)
                {
                    filteredProjectInfo.ForEach(item =>
                    {
                        lstProjectMaster.Add(new ProjectMasterViewModel
                        {
                            ProjectID = item.c.a.Project_ID,
                            ProjectName = item.c.a.Project_Name
                        });
                    });
                }
            }
            return lstProjectMaster;
        }

        public async Task<List<ProjectMasterViewModel>> FilterProjectResults(string[] projectGroups,
            string[] projectManagers, string[] status, string[] projectTypes,
            string searchKeyWord, string[] mappedStatus, string searchText)
        {
            List<ProjectMaster> lstProjectMasterInfo = new List<ProjectMaster>();
            List<ProjectMasterViewModel> lstProjectMasterModel = new List<ProjectMasterViewModel>();
            var lstManagers = await _projectMasterRepository.GetAllAsync();
            if (lstManagers == null) return new List<ProjectMasterViewModel>();
            if (projectGroups.Length > 0)
            {
                var commonProjectGroupID = lstManagers.Select(a => a.Project_Group_ID).Intersect(projectGroups.Where(a=>a != null).ToList());
                foreach (var item in commonProjectGroupID)
                {
                    lstProjectMasterInfo.Add(lstManagers.Where(a => a.Project_Group_ID == item).FirstOrDefault());
                }
            }

            if (projectManagers.Length > 0)
            {
                var commonProjectManagerID = lstManagers.Select(a => a.Project_Manager_id).Intersect(projectManagers.Where(a => a != null).ToList());
                foreach (var item in commonProjectManagerID)
                {
                    lstProjectMasterInfo.Add(lstManagers.Where(a => a.Project_Manager_id == item).FirstOrDefault());
                }
            }
            if (projectTypes.Length > 0)
            {
                var commonProjectTypeID = lstManagers.Select(a => a.Project_Type_ID.ToString()).Intersect(projectTypes.Where(a => a != null).ToList());
                foreach (var item in commonProjectTypeID)
                {
                    lstProjectMasterInfo.Add(lstManagers.Where(a => a.Project_Type_ID.ToString() == item).FirstOrDefault());
                }
            }

            if (searchKeyWord != null)
            {
                var projectNames = lstManagers.Where(a => a.Project_Name.StartsWith(searchKeyWord)).ToList();
                if(projectNames != null)
                {
                    lstProjectMasterInfo.AddRange(projectNames);
                }                
            }
            lstProjectMasterInfo.ForEach(async item =>
            {
                lstProjectMasterModel.Add(new ProjectMasterViewModel
                {
                    ProjectID = item.Project_ID,
                    City = item.City,
                    ContractPrice = item.Contract_Price,
                    InternalNotes = item.Internal_Notes,
                    JobsitePrefix = item.Project_Prefix,
                    LotInfo = item.Lot_Info,
                    Permit = item.Permit_No,
                    ProjectGroupID = item.Project_Group_ID,
                    ProjectManagerID = item.Project_Manager_id,
                    ProjectName = item.Project_Name,
                    ProjectStatusID = item.Status_ID,
                    ProjectTypeID = item.Project_Type_ID,
                    State = item.State,
                    StreetAddress = item.Address,
                    SubNotes = item.Sub_Notes,
                    UserID = item.User_ID,
                    Zip = item.Zip,
                    ProjectScheduleMasterModel = await _projectScheduleMasterHelper.GetProjectScheduleByProjectID(item.Project_ID)
                });
            });
            return lstProjectMasterModel;
        }

        public async Task<List<ProjectManagerMasterViewModel>> GetAllManagers()
        {
            List<ProjectManagerMasterViewModel> lstProjectManagerMaster = new List<ProjectManagerMasterViewModel>();
            var lstManagers = await _projectManagerMasterRepoisitory.GetAllAsync();
            lstManagers.ToList().ForEach(item => {
                lstProjectManagerMaster.Add(new ProjectManagerMasterViewModel
                {
                    ManagerID = item.Manager_ID,
                    ManagerName = item.Manager_Name,
                    OrgID = item.Org_ID
                });
            });
            return lstProjectManagerMaster;
        }

        public async Task<List<ProjectTypeMasterViewModel>> GetAllProjectType()
        {
            List<ProjectTypeMasterViewModel> ProjectTypeMasterModelLst = new List<ProjectTypeMasterViewModel>();
            var projectTypes = await _projectTypeMasterRepository.GetAllAsync();
            projectTypes.ToList().ForEach(item => {
                ProjectTypeMasterModelLst.Add(new ProjectTypeMasterViewModel
                {
                    Active = item.Active,
                    ProjectTypeID = item.Project_Type_ID,
                    ProjectTypeName = item.Project_Type_Name
                });
            });
            return ProjectTypeMasterModelLst;
        }
    }
}
