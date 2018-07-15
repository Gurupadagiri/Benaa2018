using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class ProjectColorHelper : IProjectColorHelper
    {
        private readonly IProjectColorRepoisitory _projectColorRepoisitory;
        public ProjectColorHelper(IProjectColorRepoisitory projectColorRepoisitory)
        {
            _projectColorRepoisitory = projectColorRepoisitory;
        }
        
        public async Task<List<ProjectColorViewModel>> GetAllProjectColor()
        {
            List<ProjectColorViewModel> lstProjectModel = new List<ProjectColorViewModel>();
            var lstProjectColor = await _projectColorRepoisitory.GetAllAsync();
            lstProjectColor.ToList().ForEach(item =>
            {
                lstProjectModel.Add(new ProjectColorViewModel
                {
                    ProjectColorId= item.ProjectColorId,
                    ProjectColorName= item.ProjectColorName,
                    IsDisable= item.IsDisable,
                    ColorCode = item.ColorCode
                });
            });            
            return lstProjectModel;
        }
    }
}
