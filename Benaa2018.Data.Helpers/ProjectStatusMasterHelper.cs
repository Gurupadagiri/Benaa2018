using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ProjectStatusMasterHelper : IProjectStatusMasterHelper
    {
        public IProjectStatusMasterRepository _projectStatusMasterRepository;
        public ProjectStatusMasterHelper(IProjectStatusMasterRepository projectStatusMasterRepository)
        {
            _projectStatusMasterRepository = projectStatusMasterRepository;
        }
        public async Task<List<ProjctStatusMasterViewModel>> GetAllProjectStatus()
        {
            List<ProjctStatusMasterViewModel> listStatusMaster = new List<ProjctStatusMasterViewModel>();
            var statusMasters = await _projectStatusMasterRepository.GetAllAsync();
            statusMasters.ToList().ForEach(item =>
            {
                listStatusMaster.Add(new ProjctStatusMasterViewModel
                {
                    StatusID= item.Status_ID,
                    StatusName= item.Status_Name,
                    Active= item.Active
                });
            });
            return listStatusMaster;
        }
    }
}
