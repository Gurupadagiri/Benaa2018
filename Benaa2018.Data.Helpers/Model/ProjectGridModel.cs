using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
    public class ProjectGridModel
    {
        public int ProjectId { get; set; }
        public string ProjectColor { get; set; }
        public string ProjectName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ManagerName { get; set; }
        public string OwnerName { get; set; }
        public string Telephone { get; set; }
        public string MobileNo { get; set; }
        public bool Active { get; set; }
    }
}
