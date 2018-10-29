using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Benaa2018.Helper.ViewModels
{
   public class UnitMasterViewModel :CommonViewModel
    {
        public int Unit_id { get; set; }
        public String Unit_Name { get; set; }
        public String Description { get; set; }
        public bool Status { get; set; }
        public int Orgid { get; set; }
    }
}
