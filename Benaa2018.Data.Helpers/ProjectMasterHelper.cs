using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Data.Repository;
using Benaa2018.Helper.Model;
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
        IProjectGroupRepository _projectGroupRepository;
        IProjectStatusMasterRepository _projectStatusMasterRepository;

        public ProjectMasterHelper(IProjectMasterRepository projectMasterRepository,
            IProjectManagerMasterRepository projectManagerMasterRepoisitory,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectTypeMasterRepository projectTypeMasterRepository,
            IProjectGroupRepository projectGroupRepository,
            IProjectStatusMasterRepository projectStatusMasterRepository)
        {
            _projectMasterRepository = projectMasterRepository;
            _projectManagerMasterRepoisitory = projectManagerMasterRepoisitory;
            _projectScheduleMasterHelper = projectScheduleMasterHelper;
            _ownerMasterHelper = ownerMasterHelper;
            _projectTypeMasterRepository = projectTypeMasterRepository;
            _projectGroupRepository = projectGroupRepository;
            _projectStatusMasterRepository = projectStatusMasterRepository;
        }
        public async Task<int> SaveProjectMaster(int userId, int companyid, ProjectMasterViewModel projectMasterModel)
        {
            ProjectMaster projectMaster = new ProjectMaster
            {
                User_ID = userId,
                Project_Name = projectMasterModel.ProjectName,
                Address = projectMasterModel.StreetAddress,
                Latitude = projectMasterModel.Latitude,
                Longitude = projectMasterModel.Longitude,
                City = projectMasterModel.City,
                Status_ID = string.Join(",", projectMasterModel.ProjectStatusID),
                Project_Type_ID = string.Join(",", projectMasterModel.ProjectTypeID),
                Project_Manager_id = string.Join(",", projectMasterModel.ProjectManagerID),
                Project_Group_ID = string.Join(",", projectMasterModel.ProjectGroupID),
                State = projectMasterModel.State,
                Zip = projectMasterModel.Zip,
                Internal_Notes = projectMasterModel.InternalNotes,
                Lot_Info = projectMasterModel.LotInfo,
                Sub_Notes = projectMasterModel.SubNotes,
                Project_Prefix = projectMasterModel.JobsitePrefix,
                Country_ID = projectMasterModel.CountryID,
                Org_ID = companyid,
                Permit_No = projectMasterModel.Permit,
                Contract_Price = projectMasterModel.ContractPrice
            };
            projectMaster = await _projectMasterRepository.CreateAsync(projectMaster);
            return projectMaster.Project_ID;
        }

        public async Task<int> UpdateProjectMaster(int userID, int companyid, ProjectMasterViewModel projectMasterModel)
        {
            ProjectMaster projectMaster = new ProjectMaster
            {
                Project_ID = projectMasterModel.ProjectID,
                User_ID = userID,
                Project_Name = projectMasterModel.ProjectName,
                Address = projectMasterModel.StreetAddress,
                City = projectMasterModel.City,
                Status_ID = projectMasterModel.ProjectStatusID != null ? string.Join(",", projectMasterModel.ProjectStatusID) : string.Empty,
                Project_Type_ID = projectMasterModel.ProjectTypeID != null ? string.Join(",", projectMasterModel.ProjectTypeID) : string.Empty,
                Project_Manager_id = projectMasterModel.ProjectManagerID != null ? string.Join(",", projectMasterModel.ProjectManagerID) : string.Empty,
                Project_Group_ID = string.Join(",", projectMasterModel.ProjectGroupID),
                State = projectMasterModel.State,
                Zip = projectMasterModel.Zip,
                Latitude= projectMasterModel.Latitude,
                Longitude= projectMasterModel.Longitude,
                Internal_Notes = projectMasterModel.InternalNotes,
                Lot_Info = projectMasterModel.LotInfo,
                Sub_Notes = projectMasterModel.SubNotes,
                Project_Prefix = projectMasterModel.JobsitePrefix,
                Country_ID = projectMasterModel.CountryID,
                Permit_No = projectMasterModel.Permit,
                Org_ID = companyid,
                Contract_Price = projectMasterModel.ContractPrice
            };
            projectMaster = await _projectMasterRepository.UpdateAsync(projectMaster);
            return projectMaster.Project_ID;
        }

        public async Task<List<ProjectMasterViewModel>> GetAllProjectByUserId(int userId)
        {
            List<ProjectMasterViewModel> lstProjectScheduleMaster = new List<ProjectMasterViewModel>();
            var projectSchedules = _projectMasterRepository.GetProjectByUserID(userId).Result.Where(a => a.Project_Name != null).ToList();
            foreach (var item in projectSchedules)
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
                    ProjectGroupID = item.Project_Group_ID?.Split(","),
                    ProjectManagerID = item.Project_Manager_id?.Split(","),
                    ProjectName = item.Project_Name,
                    ProjectStatusID = item.Status_ID?.Split(","),
                    ProjectTypeID = item.Project_Type_ID?.Split(","),
                    State = item.State,
                    StreetAddress = item.Address,
                    SubNotes = item.Sub_Notes,
                    UserID = item.User_ID,
                    Zip = item.Zip,
                    ProjectScheduleMasterModel = await _projectScheduleMasterHelper.GetProjectScheduleByProjectID(item.Project_ID).ConfigureAwait(true),
                    OwnerMasterModel = await _ownerMasterHelper.GetOwnerInfoByInfo(item.Project_ID).ConfigureAwait(true),
                    OrgID = Convert.ToInt32(item.Org_ID),
                    Latitude = item.Latitude,
                    Longitude = item.Longitude
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
                ProjectGroupID = projectSchedules.Project_Group_ID?.Split(","),
                ProjectManagerID = projectSchedules.Project_Manager_id?.Split(","),
                ProjectName = projectSchedules.Project_Name,
                ProjectStatusID = projectSchedules.Status_ID?.Split(","),
                ProjectTypeID = projectSchedules.Project_Type_ID?.Split(","),
                State = projectSchedules.State,
                StreetAddress = projectSchedules.Address,
                SubNotes = projectSchedules.Sub_Notes,
                UserID = projectSchedules.User_ID,
                Zip = projectSchedules.Zip,
                Latitude= projectSchedules.Latitude,
                Longitude= projectSchedules.Longitude,
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

        public async Task<List<ProjectMasterViewModel>> FilterProjectResults(int compantId, string[] projectGroups,
            string[] projectManagers, string[] status, string[] projectTypes,
            string searchKeyWord, string startDate, string endDate)
        {
            List<ProjectMaster> lstProjectMasterInfo = new List<ProjectMaster>();
            List<ProjectMasterViewModel> lstProjectMasterModel = new List<ProjectMasterViewModel>();
            var lstManagers = await _projectMasterRepository.GetAllAsync();
            lstManagers = lstManagers.Where(a => a.Org_ID == compantId).ToList();
            if (lstManagers == null) return new List<ProjectMasterViewModel>();
            if (projectGroups.Length > 0 && projectGroups[0] != null)
            {
                var lstProjectGroups = await _projectGroupRepository.GetAllAsync();
                var commonProjectGroupID = lstProjectGroups.Select(a => a.Project_Goup_ID).Intersect(projectGroups.Where(a => a != null).Select(b => Convert.ToInt32(b)).ToList());
                foreach (var item in commonProjectGroupID)
                {
                    lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_Group_ID != null && a.Project_Group_ID.Contains(item.ToString())));
                }
            }
            if (projectManagers.Length > 0 && projectManagers[0] != null)
            {
                var lstProjectManagers = await _projectManagerMasterRepoisitory.GetAllAsync();
                var commonProjectManagerID = lstProjectManagers.Select(a => a.Manager_ID).Intersect(projectManagers.Where(a => a != null).Select(b => Convert.ToInt32(b)).ToList());
                foreach (var item in commonProjectManagerID)
                {
                    lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_Manager_id != null && a.Project_Manager_id.Contains(item.ToString())));
                }
            }
            if (status.Length > 0 && status[0] != null)
            {
                var lstProjectStatus = await _projectStatusMasterRepository.GetAllAsync();
                var commonProjectTypeID = lstProjectStatus.Select(a => a.Status_ID.ToString()).Intersect(status.Where(a => a != null).ToList());
                foreach (var item in commonProjectTypeID)
                {
                    lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_Type_ID != null && a.Project_Type_ID.ToString().Contains(item)));
                }
            }
            if (projectTypes.Length > 0 && projectTypes[0] != null)
            {
                var lstProjectTypes = await _projectTypeMasterRepository.GetAllAsync();
                var commonProjectTypeID = lstProjectTypes.Select(a => a.Project_Type_ID.ToString()).Intersect(projectTypes.Where(a => a != null).ToList());
                foreach (var item in commonProjectTypeID)
                {
                    lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_Type_ID != null && a.Project_Type_ID.ToString().Contains(item)));
                }
            }
            if (searchKeyWord != null)
            {
                var projectNames = lstManagers.Where(a => a.Project_Name != null && a.Project_Name.ToLower().StartsWith(searchKeyWord.ToLower())).ToList();
                if (projectNames != null)
                {
                    lstProjectMasterInfo.AddRange(projectNames);
                }
            }
            List<ProjectScheduleMasterViewModel> lstProjectSchedules = null;
            if (startDate != null && endDate != null)
            {
                lstProjectSchedules = await _projectScheduleMasterHelper.GetAllSchedules();
                lstProjectSchedules = lstProjectSchedules.Where(a => a.OrgID == compantId).ToList();
                foreach (var item in lstManagers)
                {
                    var projectInfo = lstProjectSchedules.Where(a => Convert.ToDateTime(a.ProjectStart) >= Convert.ToDateTime(startDate) && Convert.ToDateTime(a.ActualCompletion) <= Convert.ToDateTime(endDate));
                    if (projectInfo != null)
                    {
                        lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_ID == item.Project_ID));
                    }
                }
            }
            else if (startDate != null && endDate == null)
            {
                lstProjectSchedules = await _projectScheduleMasterHelper.GetAllSchedules();
                lstProjectSchedules = lstProjectSchedules.Where(a => a.OrgID == compantId).ToList();
                foreach (var item in lstManagers)
                {
                    var projectInfo = lstProjectSchedules.Where(a => Convert.ToDateTime(a.ProjectStart) >= Convert.ToDateTime(startDate));
                    if (projectInfo != null)
                    {
                        lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_ID == item.Project_ID));
                    }
                }
            }
            else if (startDate == null && endDate != null)
            {
                lstProjectSchedules = await _projectScheduleMasterHelper.GetAllSchedules();
                lstProjectSchedules = lstProjectSchedules.Where(a => a.OrgID == compantId).ToList();
                foreach (var item in lstManagers)
                {
                    var projectInfo = lstProjectSchedules.Where(a => Convert.ToDateTime(a.ActualCompletion) <= Convert.ToDateTime(endDate));
                    if (projectInfo != null)
                    {
                        lstProjectMasterInfo.AddRange(lstManagers.Where(a => a.Project_ID == item.Project_ID));
                    }
                }
            }
            if(lstProjectMasterInfo.Count == 0)
            {
                lstProjectMasterInfo = lstManagers.ToList();
            }
            foreach (var item in lstProjectMasterInfo.Distinct())
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
                    ProjectGroupID = item.Project_Group_ID?.Split(","),
                    ProjectManagerID = item.Project_Manager_id?.Split(","),
                    ProjectName = item.Project_Name,
                    ProjectStatusID = item.Status_ID?.Split(","),
                    ProjectTypeID = item.Project_Type_ID?.Split(","),
                    State = item.State,
                    StreetAddress = item.Address,
                    SubNotes = item.Sub_Notes,
                    UserID = item.User_ID,
                    Zip = item.Zip,
                    ProjectScheduleMasterModel = await _projectScheduleMasterHelper.GetProjectScheduleByProjectID(item.Project_ID),
                    OwnerMasterModel = await _ownerMasterHelper.GetOwnerInfoByInfo(item.Project_ID)
                });
            };
            return lstProjectMasterModel;
        }

        public async Task<List<ProjectManagerMasterViewModel>> GetAllManagers()
        {
            List<ProjectManagerMasterViewModel> lstProjectManagerMaster = new List<ProjectManagerMasterViewModel>();
            var lstManagers = await _projectManagerMasterRepoisitory.GetAllAsync();
            lstManagers.ToList().ForEach(item =>
            {
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
            projectTypes.ToList().ForEach(item =>
            {
                ProjectTypeMasterModelLst.Add(new ProjectTypeMasterViewModel
                {
                    Active = item.Active,
                    ProjectTypeID = item.Project_Type_ID,
                    ProjectTypeName = item.Project_Type_Name
                });
            });
            return ProjectTypeMasterModelLst;
        }

        public List<ProjectGridModel> BindProjectGrid(List<ProjectMasterViewModel> ProjectMasterModels,
           List<ProjectManagerMasterViewModel> ProjectManagerMasterModels)
        {
            List<ProjectGridModel> lstGridModel = new List<ProjectGridModel>();
            ProjectMasterModels.ForEach(a =>
            {
                string managerName = string.Empty;
                foreach (var item in a.ProjectManagerID)
                {
                    managerName = managerName + ProjectManagerMasterModels.Select(b => b.ManagerID == Convert.ToInt32(a)).FirstOrDefault() + ",";
                }
                lstGridModel.Add(new ProjectGridModel
                {
                    ProjectName = a.ProjectName,
                    City = a.City,
                    ManagerName = managerName.TrimEnd(','),
                    MobileNo = a.OwnerMasterModel.MobileNo,
                    OwnerName = a.OwnerMasterModel.OwnerName,
                    ProjectId = a.ProjectID,
                    State = a.State,
                    StreetAddress = a.StreetAddress,
                    Telephone = a.OwnerMasterModel.MobileNo,
                    Zip = a.Zip,
                    Active = a.OwnerMasterModel.Active
                });
            });
            return lstGridModel;
        }
    }
}
