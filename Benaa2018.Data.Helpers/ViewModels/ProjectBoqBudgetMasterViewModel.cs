using Benaa2018.Helper.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectBoqBudgetMasterViewModel : CommonViewModel
    {
        public ProjectBoqBudgetMasterViewModel()
        {
            MainActivityMasterModels = new List<MainActivityMasterViewModel>();
            ActivityMasterModels = new List<ActivityMasterViewModel>();
            ProjectPlaningViewModels = new List<ProjectPlaningViewModel>();
            UnitMasterViewModels = new List<UnitMasterViewModel>();
        }


        public int Project_Boq_ID { get; set; }
        public int Project_ID { get; set; }
        public int MainActivity_ID { get; set; }
        public int Activity_ID { get; set; }
        public int Org_ID { get; set; }
        public int Unit_ID { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Unit_Cost { get; set; }
        public float Execution_Cost { get; set; }
        public float Tax_ID { get; set; }
        public float Tax_Value { get; set; }
        public float Tax_Percentage { get; set; }
        public float Tax_Unit { get; set; }
        public float Tax_Cost { get; set; }
        public float Total_Builder_Cost { get; set; }
        public float Markup_ID { get; set; }
        public float Markup_Value { get; set; }
        public float Markup_Percentage { get; set; }
        public float Total_Markup { get; set; }
        public float steakholder_Price { get; set; }
        public string Notes { get; set; }
        public bool Status { get; set; }
        public bool IsBudget_Updated { get; set; }
        public List<MainActivityMasterViewModel> MainActivityMasterModels { get; set; }
        public List<ActivityMasterViewModel> ActivityMasterModels { get; set; }
        public List<ProjectPlaningViewModel> ProjectPlaningViewModels { get; set; }
        public List<ProjectBoqBudgetMasterViewModel> ProjectBoqBudgetMasterViewModels { get; set; }
        public List<UnitMasterViewModel> UnitMasterViewModels { get; set; }
    }
}
