using Benaa2018.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Benaa2018.Helper.ViewModels;
using System.Threading.Tasks;
using Benaa2018.Helper.Model;

namespace Benaa2018.Helper
{
    public class PlanningTaskHelper : IPlanningTaskHelper
    {
        public Task<List<Dependencies>> GetPlanningDependenciesByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }
               
        Task<List<ProjectTask>> IPlanningTaskHelper.GetPlanningTaskByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
