using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ProjectScheduleMasterHelper : IProjectScheduleMasterHelper
    {
        IProjectScheduleMasterRepository _projectScheduleMasterRepository;
        public ProjectScheduleMasterHelper(IProjectScheduleMasterRepository projectScheduleMasterRepository)
        {
            _projectScheduleMasterRepository = projectScheduleMasterRepository;
        }

        public async Task<List<ProjectScheduleMasterViewModel>> GetAllSchedules()
        {
            List<ProjectScheduleMasterViewModel> lstProjectScheduleMaster = new List<ProjectScheduleMasterViewModel>();
            var projectScheduleMaster = await _projectScheduleMasterRepository.GetAllAsync();
            projectScheduleMaster.ToList().ForEach(item =>
            {
                lstProjectScheduleMaster.Add(new ProjectScheduleMasterViewModel
                {
                    Project_Schedule_ID = item.Schedule_ID,
                    OrgID = item.Org_ID,
                    ProjectId = item.Project_ID,
                    ActualCompletion = item.Actual_Completion.ToString("dd/MM/yyyy"),
                    ActualStart = item.Actual_Start.ToString("d/MM/yyyy"),
                    JobColorID = item.ProjectColorId,
                    WorkDays = item.Works_Days,
                    ProjectStart = item.Projected_Start.ToString("d/MM/yyyy"),
                    ProjectCompletion = item.Projected_Completion.ToString("d/MM/yyyy")
                });
            });
            return lstProjectScheduleMaster;
        }

        public async Task<ProjectScheduleMasterViewModel> GetProjectScheduleByProjectID(int projectId)
        {
            var projectSchedule = await _projectScheduleMasterRepository.GetAllAsync().ConfigureAwait(true);
            var projectScheduleMaster = projectSchedule.Where(a => a.Project_ID == projectId).FirstOrDefault();
            return projectScheduleMaster != null ? new ProjectScheduleMasterViewModel
            {
                Project_Schedule_ID = projectScheduleMaster.Schedule_ID,
                OrgID = projectScheduleMaster.Org_ID,
                ProjectId = projectScheduleMaster.Project_ID,
                ActualCompletion = projectScheduleMaster.Actual_Completion.ToString("d/MM/yyyy"),
                ActualStart = projectScheduleMaster.Actual_Start.ToString("d/MM/yyyy"),
                JobColorID = projectScheduleMaster.ProjectColorId,
                WorkDays = projectScheduleMaster.Works_Days,
                ProjectStart = projectScheduleMaster.Projected_Start.ToString("d/MM/yyyy"),
                ProjectCompletion = projectScheduleMaster.Projected_Completion.ToString("d/MM/yyyy"),
            } : new ProjectScheduleMasterViewModel();
        }

        public async Task SaveProjectSchedules(int userId, int projectMasterId, ProjectScheduleMasterViewModel projectScheduleMasterModel)
        {
            ProjectScheduleMaster projectScheduleMaster = new ProjectScheduleMaster
            {
                Actual_Completion = Convert.ToDateTime(projectScheduleMasterModel.ActualCompletion),
                Actual_Start = Convert.ToDateTime(projectScheduleMasterModel.ActualStart),
                Projected_Completion = Convert.ToDateTime(projectScheduleMasterModel.ProjectCompletion),
                Org_ID = 1,
                Projected_Start = Convert.ToDateTime(projectScheduleMasterModel.ProjectStart),
                Project_ID = projectMasterId,                
                Works_Days = projectScheduleMasterModel.WorkDays,
                ProjectColorId = projectScheduleMasterModel.JobColorID                
            };
            await _projectScheduleMasterRepository.CreateAsync(projectScheduleMaster);
        }

        public async Task UpdateProjectSchedules(int userId, int projectMasterId, ProjectScheduleMasterViewModel projectScheduleMasterModel)
        {
            //var scheduleInfo = await _projectScheduleMasterRepository.GetProjectSheduleByProjectIdAsync(projectMasterId);
            var projectSchedule = await _projectScheduleMasterRepository.GetAllAsync();
            var scheduleInfo = projectSchedule.Where(a => a.Project_ID == projectMasterId).FirstOrDefault();
            if (scheduleInfo == null) return;
            scheduleInfo.Actual_Completion = Convert.ToDateTime(projectScheduleMasterModel.ActualCompletion);
            scheduleInfo.Actual_Start = Convert.ToDateTime(projectScheduleMasterModel.ActualStart);
            scheduleInfo.Projected_Completion = Convert.ToDateTime(projectScheduleMasterModel.ProjectCompletion);
            scheduleInfo.Org_ID = 1;
            scheduleInfo.Projected_Start = Convert.ToDateTime(projectScheduleMasterModel.ProjectStart);
            scheduleInfo.Project_ID = projectMasterId;
            scheduleInfo.Project_Color_ID = projectScheduleMasterModel.JobColorID;
            scheduleInfo.Works_Days = projectScheduleMasterModel.WorkDays;
            await _projectScheduleMasterRepository.UpdateAsync(scheduleInfo);
        }
    }
}
