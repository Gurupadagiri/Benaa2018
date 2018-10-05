using Benaa2018.Data.Model;
using Benaa2018.Helper.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper.Interface
{
    public interface IPlanningTaskHelper
    {
        Task<List<ProjectTask>> GetPlanningTaskByProjectId(int projectId);
        Task<List<Dependencies>> GetPlanningDependenciesByProjectId(int projectId);
    }
}
