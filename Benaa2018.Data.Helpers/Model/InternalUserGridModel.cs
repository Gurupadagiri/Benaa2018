using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Helper.Model
{
    public class InternalUserGridModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool AdminAccess { get; set; }
        public bool LoginEnabled { get; set; }
        public bool AutoAccess { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
