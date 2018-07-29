using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Data.Repository
{
    public class CustomerContactRepository : Repository<CustomerContactDetails>, ICustomerContactRepository
    {
        public CustomerContactRepository(SBSDbContext context) : base(context) { }
    }
}
