using Benaa2018.Helper.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class HomeViewModel : CommonViewModel
    {
        public HomeViewModel()
        {          
            ToDoMasterModels = new List<ToDoMasterViewModel>();
            WarrentyAlertModels = new List<WarrentyAlertViewModel>();
        }
        public List<ToDoMasterViewModel> ToDoMasterModels { get; set; }
        public List<WarrentyAlertViewModel> WarrentyAlertModels { get; set; }
    }
}
