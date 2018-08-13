using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.ViewModels
{
    public class CalendarTagViewModel : CommonViewModel
    {
        public int TagId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string TagName { get; set; }
    }
}
