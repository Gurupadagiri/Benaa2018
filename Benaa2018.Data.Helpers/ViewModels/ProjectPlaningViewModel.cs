using Benaa2018.Helper.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class ProjectPlaningViewModel : CommonViewModel
    {
        public ProjectPlaningViewModel()
        {
           // ActivityMasterModels = new List<ActivityMasterViewModel>();
        }


        public int Project_Plan_ID { get; set; }
        public int Project_ID { get; set; }
        public int MainActivity_ID { get; set; }
        public double Org_ID { get; set; }
        public int Activity_ID { get; set; }
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_End_Date { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public float Percentage_Complition { get; set; }
        public float Efforts { get; set; }


        //public List<ActivityMasterViewModel> ActivityMasterModels { get; set; }
    }
}
